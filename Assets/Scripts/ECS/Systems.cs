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
        private NativeQueue<Entity> m_InsatancedEntities;
        #region Manager
        protected override void OnCreateManager()
        {
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            InsatancedEntities = new NativeQueue<Entity>(Allocator.Persistent);
            m_SpawnJob = new SpawnJob { };
        }

        protected override void OnDestroyManager()
        {
            InsatancedEntities.Dispose();
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
            [WriteOnly] public NativeQueue<Entity>.Concurrent instancedEntities;
            [ReadOnly] public DensityWaveProperties densityWaveProperties;

            public void Execute(Entity entity, int index, [ReadOnly] ref SpawnerProperties c0, [ReadOnly] ref LocalToWorld c1)
            {
                for (int i = 0; i < c0.Count; i++)
                {
                    var instance = commandBuffer.Instantiate(c0.Prefab);
                    instancedEntities.Enqueue(instance);
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
                    var starSystemProperties = new StarSystemProperties
                    {
                        Seed = proportion + mass,
                        PlanetAmount = (int)(Random.Next() * 15)
                    };
                    var scale = new Scale { Value = 1 };
                    commandBuffer.SetComponent(instance, scale);
                    var orbitProperties = densityWaveProperties.GetOrbit(proportion);
                    commandBuffer.SetComponent(instance, starProperties);
                    commandBuffer.SetComponent(instance, orbitProperties);
                    commandBuffer.SetComponent(instance, starSystemProperties);
                }
                commandBuffer.DestroyEntity(entity);
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            SpawnStar();
            return inputDeps;
        }

        public void SpawnStarECS(JobHandle inputDeps)
        {
            EntityCommandBuffer cmdBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer();
            m_SpawnJob = new SpawnJob
            {
                commandBuffer = cmdBuffer,
                instancedEntities = InsatancedEntities.ToConcurrent()
            };
            m_SpawnJob.densityWaveProperties = m_DensityWave.DensityWaveProperties;
            inputDeps = m_SpawnJob.ScheduleSingle(this, inputDeps);
            m_EntityCommandBufferSystem.AddJobHandleForProducer(inputDeps);
            inputDeps.Complete();
        }

        public void SpawnStar()
        {
            EntityQuery entityQuery = World.Active.EntityManager.CreateEntityQuery(typeof(SpawnerProperties));
            var spawners = entityQuery.ToEntityArray(Allocator.TempJob);
            Debug.Log(spawners);
            Debug.Log(spawners.Length);
            int index = 0;
            for(int i = 0; i < spawners.Length; i++)
            {
                int count = World.Active.EntityManager.GetComponentData<SpawnerProperties>(spawners[i]).Count;
                Debug.Log(count);
                var prefab = World.Active.EntityManager.GetComponentData<SpawnerProperties>(spawners[i]).Prefab;
                for (int j = 0; j < count; j++)
                {
                    var instance = World.Active.EntityManager.Instantiate(prefab);
                    m_InsatancedEntities.Enqueue(instance);
                    float proportion = Random.Next();
                    float mass = Random.Next();
                    var starProperties = new StarProperties
                    {
                        Mass = 0.5f + mass / 2,
                        StartingTime = Random.Next() * 360,
                        Index = index,
                        Proportion = proportion,
                        HeightOffset = m_DensityWave.DensityWaveProperties.GetHeightOffset(proportion),
                        Color = m_DensityWave.DensityWaveProperties.GetColor(proportion)
                    };
                    var starSystemProperties = new StarSystemProperties
                    {
                        Seed = proportion + mass,
                        PlanetAmount = (int)(Random.Next() * 10)
                    };
                    
                    var scale = new Scale { Value = 1 };
                    World.Active.EntityManager.SetComponentData(instance, scale);
                    var orbitProperties = m_DensityWave.DensityWaveProperties.GetOrbit(proportion);
                    World.Active.EntityManager.SetComponentData(instance, starProperties);
                    World.Active.EntityManager.SetComponentData(instance, orbitProperties);
                    World.Active.EntityManager.SetComponentData(instance, starSystemProperties);
                    index++;
                }
                World.Active.EntityManager.DestroyEntity(spawners[i]);
            }
            spawners.Dispose();
            entityQuery.Dispose();
        }

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public NativeQueue<Entity> InsatancedEntities { get => m_InsatancedEntities; set => m_InsatancedEntities = value; }
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
                        var star = m_Stars.Dequeue();
                        
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
        struct CalculateStarPositionsJob : IJobForEach<StarProperties, Translation, OrbitProperties, Scale>
        {
            [ReadOnly] public float currentTime;
            [ReadOnly] public Vector3 cameraPosition;
            public void Execute([ReadOnly] ref StarProperties c0, [WriteOnly] ref Translation c1, [ReadOnly] ref OrbitProperties c3, [ReadOnly] ref Scale c4)
            {
                float calculatedTime = c0.StartingTime + currentTime;
                c1.Value = c3.GetPoint((c0.StartingTime + currentTime));
                c1.Value.z += c0.HeightOffset;
                float distance = Vector3.Distance(cameraPosition, c1.Value);
                if (distance < 200) distance = 200;
                if (distance > 7500) distance = 7500;
                c4.Value = c0.Mass * distance / 200;
            }

        }

        struct CalculateStarOrbitJob : IJobForEachWithEntity<StarProperties, OrbitProperties>
        {
            [ReadOnly] public DensityWaveProperties densityWaveProperties;
            public void Execute(Entity entity, int index, [ReadOnly] ref StarProperties c0, [WriteOnly] ref OrbitProperties c1)
            {
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
    public class StarSelectionSystem : JobComponentSystem
    {
        #region Attributes
        private Camera m_MainCamera;
        private NativeQueue<Entity> m_RayCastResultEntities;
        private NativeQueue<float> m_Distances;
        private NativeQueue<int> m_SelectedResultEntitiesIndexList;
        private Entity m_ResultEntity;
        private Entity m_LastResultEntity;
        private float m_MaxRayCastDistance;
        private float m_MaxSelectionDistance;
        #endregion

        #region Public
        public Entity ResultEntity { get => m_ResultEntity; set => m_ResultEntity = value; }
        public float MaxRayCastDistance { get => m_MaxRayCastDistance; set => m_MaxRayCastDistance = value; }
        public Entity LastResultEntity { get => m_LastResultEntity; set => m_LastResultEntity = value; }
        public float MaxSelectionDistance { get => m_MaxSelectionDistance; set => m_MaxSelectionDistance = value; }
        public NativeQueue<int> SelectedResultEntitiesIndexList { get => m_SelectedResultEntitiesIndexList; set => m_SelectedResultEntitiesIndexList = value; }
        #endregion

        protected override void OnCreateManager()
        {
            MaxRayCastDistance = 2000;
            m_MaxSelectionDistance = 500;
            m_RayCastResultEntities = new NativeQueue<Entity>(Allocator.Persistent);
            SelectedResultEntitiesIndexList = new NativeQueue<int>(Allocator.Persistent);
            m_Distances = new NativeQueue<float>(Allocator.Persistent);
            m_MainCamera = Camera.main;
            m_LastResultEntity = Entity.Null;
        }

        protected override void OnDestroyManager()
        {
            m_RayCastResultEntities.Dispose();
            SelectedResultEntitiesIndexList.Dispose();
            m_Distances.Dispose();
        }

        [BurstCompile]
        struct CalculateStarPositionsJob : IJobForEachWithEntity<StarProperties, Translation, Scale>
        {
            [ReadOnly] public Vector3 Start;
            [ReadOnly] public Vector3 End;
            [ReadOnly] public float RayCastDistance;
            [ReadOnly] public float SelectionDistance;
            [WriteOnly] public NativeQueue<Entity>.Concurrent RayCastResultEntities;
            [WriteOnly] public NativeQueue<float>.Concurrent RayCastDistances;
            [WriteOnly] public NativeQueue<int>.Concurrent SelectionResultEntities;
            public void Execute([ReadOnly] Entity entity, [ReadOnly] int index, [ReadOnly] ref StarProperties c0, [ReadOnly] ref Translation c1, [ReadOnly] ref Scale c2)
            {
                if (Vector3.Distance(c1.Value, Start) <= RayCastDistance)
                {
                    if (Vector3.Distance(c1.Value, Start) <= SelectionDistance && Vector3.Angle(End - Start, (Vector3)c1.Value - Start) < 70) SelectionResultEntities.Enqueue(c0.Index);
                    float d = Mathf.Abs(Vector3.Dot(((Vector3)c1.Value - Start), (End - Start))) / RayCastDistance;
                    float ap = Vector3.Distance(c1.Value, Start);
                    if (Mathf.Sqrt(ap * ap - d * d) < c2.Value)
                    {
                        RayCastResultEntities.Enqueue(entity);
                        RayCastDistances.Enqueue(ap);
                    }
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {

            SelectedResultEntitiesIndexList.Clear();
            UnityEngine.Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            inputDeps = new CalculateStarPositionsJob
            {
                Start = ray.origin,
                End = ray.origin + ray.direction * m_MaxRayCastDistance,
                RayCastDistance = m_MaxRayCastDistance,
                SelectionDistance = m_MaxSelectionDistance,
                RayCastResultEntities = m_RayCastResultEntities.ToConcurrent(),
                RayCastDistances = m_Distances.ToConcurrent(),
                SelectionResultEntities = SelectedResultEntitiesIndexList.ToConcurrent()
            }.Schedule(this, inputDeps);
            inputDeps.Complete();

            m_ResultEntity = Entity.Null;
            float min = MaxRayCastDistance;
            while(m_Distances.Count > 0)
            {
                Entity e = m_RayCastResultEntities.Dequeue();
                float f = m_Distances.Dequeue();
                if (f < min)
                {
                    min = f;
                    m_ResultEntity = e;
                    m_LastResultEntity = e;
                }
            }
            return inputDeps;
        }
    }

    [DisableAutoCreation]
    public class CameraRayCastSystem : JobComponentSystem
    {

        private BuildPhysicsWorld m_PhysicsWorldSystem;
        private Camera m_MainCamera;
        private RaycastInput m_RaycastInput;
        private NativeArray<bool> m_HaveHit;

        private NativeArray<Unity.Physics.RaycastHit> m_HitResult;
        private NativeArray<RaycastInput> m_Inputs;
        private Vector3 m_SelectedStarPosition;
        public NativeArray<Unity.Physics.RaycastHit> HitResults { get => m_HitResult; set => m_HitResult = value; }
        public NativeArray<RaycastInput> Inputs { get => m_Inputs; set => m_Inputs = value; }
        public Vector3 SelectedStarPosition { get => m_SelectedStarPosition; set => m_SelectedStarPosition = value; }

        protected override void OnCreateManager()
        {
            m_PhysicsWorldSystem = World.Active.GetExistingSystem<BuildPhysicsWorld>();
            m_Inputs = new NativeArray<RaycastInput>(1, Allocator.Persistent);
            m_MainCamera = Camera.main;
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
            m_HitResult = new NativeArray<Unity.Physics.RaycastHit>(1, Allocator.Persistent);
            m_HaveHit = new NativeArray<bool>(1, Allocator.Persistent);

        }

        protected override void OnDestroyManager()
        {
            m_HitResult.Dispose();
            m_Inputs.Dispose();
            m_HaveHit.Dispose();
        }

        [BurstCompile]
        public struct RaycastJob : IJobParallelFor
        {
            [ReadOnly] public CollisionWorld world;
            [ReadOnly] public NativeArray<RaycastInput> inputs;
            [WriteOnly] public NativeArray<bool> haveHit;
            public NativeArray<Unity.Physics.RaycastHit> results;

            public unsafe void Execute(int index)
            {
                Unity.Physics.RaycastHit hit;
                haveHit[index] = world.CastRay(inputs[index], out hit);
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
                world = m_PhysicsWorldSystem.PhysicsWorld.CollisionWorld,
                haveHit = m_HaveHit
            }.Schedule(Inputs.Length, 5);
            inputDeps.Complete();

            if (m_HaveHit[0])
            {
                m_SelectedStarPosition = World.Active.EntityManager.GetComponentData<Translation>(m_PhysicsWorldSystem.PhysicsWorld.Bodies[m_HitResult[0].RigidBodyIndex].Entity).Value;
            }
            else
            {
                m_SelectedStarPosition = Vector3.zero;
            }
            return inputDeps;
        }
    }

}
