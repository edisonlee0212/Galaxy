using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Mathematics;

namespace Galaxy
{
    [DisableAutoCreation]
    public class StarSpawnerSystem : JobComponentSystem
    {
        private EndSimulationEntityCommandBufferSystem m_EntityCommandBufferSystem;
        private DensityWave m_DensityWave;
        private SpawnJob m_SpawnJob;

        #region Manager
        protected override void OnCreateManager()
        {
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            m_SpawnJob = new SpawnJob { };

        }

        public void Init()
        {
            Update();
        }
        #endregion

        #region Jobs
        protected struct SpawnJob : IJobForEachWithEntity<SpawnerProperties, LocalToWorld>
        {
            public EntityCommandBuffer commandBuffer;
            [ReadOnly] public DensityWaveProperties densityWaveProperties;

            public void Execute(Entity entity, int index, [ReadOnly] ref SpawnerProperties c0, [ReadOnly] ref LocalToWorld c1)
            {
                for (int i = 0; i < c0.Count; i++)
                {
                    var instance = commandBuffer.Instantiate(c0.Prefab);
                    float proportion = Random.Next();
                    float mass = Random.Next();
                    var starProperties = new StarProperties
                    {
                        Mass = 0.5f + mass / 2,
                        StartingTime = Random.Next() * 360,
                        Index = i,
                        Proportion = proportion,
                        HeightOffset = densityWaveProperties.GetHeightOffset(proportion),
                        Color = densityWaveProperties.GetColor(proportion)
                    };
                    var scale = new Scale { Value = 1 };
                    commandBuffer.AddComponent(instance, scale);
                    var orbitProperties = densityWaveProperties.GetOrbit(proportion);
                    commandBuffer.SetComponent(instance, starProperties);
                    commandBuffer.SetComponent(instance, orbitProperties);
                }
                commandBuffer.DestroyEntity(entity);
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            m_SpawnJob.commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer();
            m_SpawnJob.densityWaveProperties = m_DensityWave.DensityWaveProperties;
            inputDeps = m_SpawnJob.ScheduleSingle(this, inputDeps);
            m_EntityCommandBufferSystem.AddJobHandleForProducer(inputDeps);
            return inputDeps;
        }

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
    }

    [DisableAutoCreation]
    public class StarColorCalculationSystem : JobComponentSystem
    {
        private NativeQueue<Entity> m_Stars;
        private GetAllStarsJob m_GetAllStarsJob;
        private DensityWave m_DensityWave;
        private bool m_Calculate;
        #region Manager
        protected override void OnCreateManager()
        {
            m_Stars = new NativeQueue<Entity>(Allocator.Persistent);
            m_GetAllStarsJob = new GetAllStarsJob { };
            m_Calculate = false;
        }

        protected override void OnDestroyManager()
        {
            m_Stars.Dispose();
        }
        #endregion

        public void Init()
        {
            m_Calculate = true;
        }

        #region Jobs
        protected struct GetAllStarsJob : IJobForEachWithEntity<StarProperties>
        {
            [WriteOnly] public NativeQueue<Entity>.Concurrent stars;
            public void Execute(Entity entity, int index, ref StarProperties c0)
            {
                stars.Enqueue(entity);
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (m_Calculate)
            {
                inputDeps.Complete();
                m_GetAllStarsJob.stars = m_Stars.ToConcurrent();
                inputDeps = m_GetAllStarsJob.Schedule(this, inputDeps);
                inputDeps.Complete();

                int count = m_Stars.Count;
                if (count != 0)
                {
                    m_Calculate = false;
                    Debug.Log("Calculating colors");
                    for (int i = 0; i < count; i++)
                    {
                        //TODO
                    }
                }
            }
            return inputDeps;
        }

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
    }

    [DisableAutoCreation]
    public class StarPositionCalculationSystem : JobComponentSystem
    {
        private Camera m_MainCamera;
        private DensityWave m_DensityWave;
        private bool m_CalculateOrbit;
        private float m_SimulatedTime;
        private CalculateStarPositionsJob calculateStarPositionsJob;
        private CalculateStarOrbitJob calculateStarOrbitJob;

        public void Init()
        {
            m_MainCamera = Camera.main;
            calculateStarPositionsJob = new CalculateStarPositionsJob { };
            calculateStarOrbitJob = new CalculateStarOrbitJob
            {
                densityWaveProperties = DensityWave.DensityWaveProperties
            };
            m_CalculateOrbit = true;
        }

        public void SetTimeAndCalculate(float simulatedTime)
        {
            m_SimulatedTime = simulatedTime;
            Update();
        }

        #region Jobs
        struct CullStarJob : IJobForEachWithEntity<StarProperties, Translation>
        {
            public EntityCommandBuffer CommandBuffer;
            [ReadOnly] public Vector3 cameraPosition;
            [ReadOnly] public Quaternion cameraRotation;
            public void Execute(Entity entity, int index, ref StarProperties c0, ref Translation c1)
            {
                if (true)
                {

                }
            }
        }

        [BurstCompile]
        struct CalculateStarPositionsJob : IJobForEach<StarProperties, Translation, OrbitProperties, Scale, PhysicsCollider>
        {
            [ReadOnly] public float currentTime;
            [ReadOnly] public Vector3 cameraPosition;
            public void Execute([ReadOnly] ref StarProperties c0, [WriteOnly] ref Translation c1, [ReadOnly] ref OrbitProperties c3, [ReadOnly] ref Scale c4, [ReadOnly] ref PhysicsCollider c5)
            {
                float calculatedTime = c0.StartingTime + currentTime;
                c1.Value = c3.GetPoint((c0.StartingTime + currentTime));
                c1.Value.z += c0.HeightOffset;
                float distance = Vector3.Distance(cameraPosition, c1.Value);
                if (distance < 200) distance = 200;
                if (distance > 7500) distance = 7500;
                c4.Value = c0.Mass * distance / 200;
                //c5.Value = Unity.Physics.SphereCollider.Create(float3.zero, c4.Value);
            }

        }

        struct CalculateStarOrbitJob : IJobForEachWithEntity<StarProperties, OrbitProperties>
        {
            [ReadOnly] public DensityWaveProperties densityWaveProperties;
            public void Execute(Entity entity, int index, [ReadOnly] ref StarProperties c0, [WriteOnly] ref OrbitProperties c1)
            {
                c0.HeightOffset = densityWaveProperties.GetHeightOffset(c0.Proportion);
                c0.Color = densityWaveProperties.GetColor(c0.Proportion);
                c1 = densityWaveProperties.GetOrbit(c0.Proportion);
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            calculateStarPositionsJob.currentTime = m_SimulatedTime;
            calculateStarPositionsJob.cameraPosition = m_MainCamera.transform.position;
            if (m_CalculateOrbit)
            {
                CalculateOrbit = false;
                calculateStarOrbitJob.densityWaveProperties = DensityWave.DensityWaveProperties;
                inputDeps = calculateStarOrbitJob.Schedule(this, inputDeps);
                inputDeps.Complete();
            }
            inputDeps = calculateStarPositionsJob.Schedule(this, inputDeps);
            inputDeps.Complete();
            return inputDeps;
        }

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public bool CalculateOrbit { get => m_CalculateOrbit; set => m_CalculateOrbit = value; }
        public Camera MainCamera { get => m_MainCamera; set => m_MainCamera = value; }
    }

    [DisableAutoCreation]
    public class CameraRayCastSystem : JobComponentSystem
    {
        private NativeArray<Unity.Physics.RaycastHit> m_HitResults;
        private NativeArray<RaycastInput> m_Inputs;
        private BuildPhysicsWorld m_PhysicsWorld;
        private Camera m_MainCamera;
        private RaycastInput m_RaycastInput;

        public NativeArray<Unity.Physics.RaycastHit> HitResults { get => m_HitResults; set => m_HitResults = value; }
        public NativeArray<RaycastInput> Inputs { get => m_Inputs; set => m_Inputs = value; }

        protected override void OnCreateManager()
        {
            m_PhysicsWorld = World.Active.GetExistingSystem<BuildPhysicsWorld>();
            m_Inputs = new NativeArray<RaycastInput>(1, Allocator.Persistent);
            m_MainCamera = Camera.main;
            Debug.Log(m_MainCamera);
            m_RaycastInput = new RaycastInput()
            {
                Start = m_MainCamera.transform.position,
                End = new Unity.Mathematics.float3(0, 0, 0),
                Filter = new CollisionFilter()
                {
                    BelongsTo = ~0u, // all 1s, so all layers, collide with everything 
                    CollidesWith = ~0u,
                    GroupIndex = 0
                }
            };


            m_HitResults = new NativeArray<Unity.Physics.RaycastHit>(1, Allocator.Persistent);


        }

        protected override void OnDestroyManager()
        {
            m_HitResults.Dispose();
            m_Inputs.Dispose();
        }

        [BurstCompile]
        public struct RaycastJob : IJobParallelFor
        {
            [ReadOnly] public CollisionWorld world;
            [ReadOnly] public NativeArray<RaycastInput> inputs;
            public NativeArray<Unity.Physics.RaycastHit> results;

            public unsafe void Execute(int index)
            {
                Unity.Physics.RaycastHit hit;
                world.CastRay(inputs[index], out hit);
                results[index] = hit;
            }
        }
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            UnityEngine.Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            m_RaycastInput.Start = ray.origin;
            m_RaycastInput.End = ray.origin + ray.direction * 2000;
            m_Inputs[0] = m_RaycastInput;

            inputDeps = new RaycastJob
            {
                inputs = Inputs,
                results = HitResults,
                world = m_PhysicsWorld.PhysicsWorld.CollisionWorld
            }.Schedule(Inputs.Length, 5);
            inputDeps.Complete();
            return inputDeps;
        }
    }
}
