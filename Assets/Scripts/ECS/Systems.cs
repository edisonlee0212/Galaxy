using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

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
                        Entity instance = m_Stars.Dequeue();
                        RenderMesh renderMesh = World.Active.EntityManager.GetSharedComponentData<RenderMesh>(instance);
                        float proportion = World.Active.EntityManager.GetComponentData<StarProperties>(instance).Proportion;
                        Material material = new Material(renderMesh.material);
                        Color color = m_DensityWave.DensityWaveProperties.GetColor(proportion);
                        Debug.Log(color);
                        material.SetColor("_EmissionColor", color);
                        renderMesh.material = material;
                        World.Active.EntityManager.SetSharedComponentData(instance, renderMesh);
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

        public void AddTimeAndCalculate(float time)
        {
            m_SimulatedTime += time;
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
                if (distance < 100) distance = 100;
                if (distance > 10000) distance = 10000;
                c4.Value = c0.Mass * distance / 300;
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
}
