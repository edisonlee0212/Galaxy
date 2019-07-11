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
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Assertions;

namespace Galaxy
{
    [DisableAutoCreation]
    public class StarEngine : JobComponentSystem
    {
        private DensityWave m_DensityWave;
        private Queue<Entity> m_InsatancedStarEntities;
        private int m_StarAmount;
        private int m_MaxPlanetAmount;

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public Queue<Entity> InsatancedStarEntities { get => m_InsatancedStarEntities; set => m_InsatancedStarEntities = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }

        public void Init()
        {
            m_InsatancedStarEntities = new Queue<Entity>();
            Update();
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            EntityArchetype starEntityArchetype = EntityManager.CreateArchetype(
                typeof(CustomCullingStat),
                typeof(Translation),
                typeof(Rotation),
                typeof(StarProperties),
                typeof(CustomColor),
                typeof(OrbitProperties),
                typeof(StarSystemProperties),
                typeof(Scale),
                typeof(LocalToWorld)
                );
            EntityArchetype planetEntityArchetype = EntityManager.CreateArchetype(
                            typeof(Translation),
                            typeof(Rotation),
                            typeof(Scale),
                            typeof(LocalToWorld),
                            typeof(LocalToParent),
                            typeof(CustomColor),
                            typeof(OrbitProperties),
                            typeof(PlanetProperties),
                            typeof(Parent)
                            );


            for (int i = 0; i < m_StarAmount; i++)
            {
                Entity instance = EntityManager.CreateEntity(starEntityArchetype);
                m_InsatancedStarEntities.Enqueue(instance);
                //entityManager.SetName(instance, "Star" + i);
                if (i == 0)
                {
                    for (int j = 0; j < m_MaxPlanetAmount; j++)
                    {
                        Entity planet = EntityManager.CreateEntity(planetEntityArchetype);
                        //entityManager.SetName(planet, "Planet");
                        EntityManager.SetEnabled(planet, false);
                        EntityManager.SetComponentData(planet, new Parent { Value = instance });
                        EntityManager.SetComponentData(planet, new Scale { Value = 0.2f });
                        EntityManager.SetComponentData(planet, new PlanetProperties { StartTime = Random.Next() * 360 });
                    }
                }
                m_InsatancedStarEntities.Enqueue(instance);
                float proportion = Random.Next();
                float mass = Random.Next();

                var starProperties = new StarProperties
                {
                    Mass = 0.5f + mass * 2,
                    StartingTime = Random.Next() * 360,
                    Index = i,
                    Proportion = proportion,
                    HeightOffset = DensityWave.DensityWaveProperties.GetHeightOffset(proportion),
                    Color = new Color(Random.Next(), Random.Next(), Random.Next(), 1)
                    //Color = m_DensityWave.DensityWaveProperties.GetColor(proportion)
                };

                var color = new CustomColor { };

                var starSystemProperties = new StarSystemProperties
                {
                    Seed = proportion + mass,
                    PlanetAmount = (int)(Random.Next() * 15)
                };

                var scale = new Scale { Value = 1 };
                EntityManager.SetComponentData(instance, scale);
                var orbitProperties = DensityWave.DensityWaveProperties.GetOrbit(proportion);
                EntityManager.SetComponentData(instance, starProperties);
                EntityManager.SetComponentData(instance, orbitProperties);
                EntityManager.SetComponentData(instance, starSystemProperties);
                EntityManager.SetComponentData(instance, color);
            }
            return inputDeps;
        }
    }

    public class StarPositionSimulationSystem : JobComponentSystem
    {
        private Camera m_MainCamera;
        private DensityWave m_DensityWave;
        private bool m_CalculateOrbit;
        private float m_SimulatedTime;
        private StarPositionsJob calculateStarPositionsJob;
        private StarOrbitJob calculateStarOrbitJob;

        protected override void OnCreateManager()
        {
            Enabled = false;
        }

        public void Init()
        {
            m_MainCamera = Camera.main;
            calculateStarPositionsJob = new StarPositionsJob { };
            calculateStarOrbitJob = new StarOrbitJob
            {
                densityWaveProperties = DensityWave.DensityWaveProperties
            };
            m_CalculateOrbit = true;
            Enabled = true;
        }

        public void SetTime(float simulatedTime)
        {
            m_SimulatedTime = simulatedTime;
        }

        #region Jobs
        [BurstCompile]
        struct StarPositionsJob : IJobForEach<StarProperties, Translation, OrbitProperties, Scale, CustomColor>
        {
            [ReadOnly] public float currentTime;
            [ReadOnly] public Vector3 cameraPosition;
            public void Execute([ReadOnly] ref StarProperties c0, [WriteOnly] ref Translation c1, [ReadOnly] ref OrbitProperties c3, [ReadOnly] ref Scale c4, [WriteOnly] ref CustomColor c5)
            {
                float calculatedTime = c0.StartingTime + currentTime;
                c1.Value = c3.GetPoint((c0.StartingTime + currentTime));
                c1.Value.z += c0.HeightOffset;
                float distance = Vector3.Distance(cameraPosition, c1.Value);
                if (distance < 250)
                {
                    distance = 250;
                    c5.Color = c0.Color;
                }
                else if (distance > 10000)
                {
                    c5.Color = Color.white;
                    distance = 10000;
                }
                else
                {
                    c5.Color = (c0.Color * 500 + Color.white * (distance - 250) / 2) / (500 + (distance - 250) / 2);
                }
                c4.Value = c0.Mass * distance / 250;
            }

        }
        [BurstCompile]
        struct StarOrbitJob : IJobForEachWithEntity<StarProperties, OrbitProperties>
        {
            [ReadOnly] public DensityWaveProperties densityWaveProperties;
            public void Execute(Entity entity, int index, [ReadOnly] ref StarProperties c0, [WriteOnly] ref OrbitProperties c1)
            {
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

    public class PlanetPositionSimulationSystem : JobComponentSystem
    {
        private float m_Time;
        private Entity m_StarEntity;
        private DensityWave m_DensityWave;
        private StarSystemProperties m_StarSystemProperties;

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }

        protected override void OnCreateManager()
        {
            Enabled = false;
        }

        public void Init()
        {
            Enabled = true;
        }

        protected override void OnDestroyManager()
        {
        }

        public void SetTime(float Time)
        {
            m_Time = Time;
        }

        public void ResetEntity(Entity e)
        {
            NativeArray<Entity> planets = EntityManager.CreateEntityQuery(typeof(PlanetProperties)).ToEntityArray(Allocator.TempJob);
            m_StarEntity = e;
            if (e != Entity.Null)
            {
                int index = 0;
                m_StarSystemProperties = EntityManager.GetComponentData<StarSystemProperties>(m_StarEntity);
                int planetAmount = m_StarSystemProperties.PlanetAmount;
                Debug.Log(planetAmount);
                for (int i = 0; i < planetAmount && i < planets.Length; i++)
                {
                    EntityManager.SetComponentData(planets[i], new Parent { Value = e });
                    EntityManager.SetComponentData(planets[i], new OrbitProperties
                    {
                        a = 1 + index * 1,
                        b = 1 + index * 1,
                        speedMultiplier = 5
                    });
                    index++;
                }
                for (int i = planetAmount; i < planets.Length; i++)
                {
                    EntityManager.SetEnabled(planets[i], false);
                }
                if (planetAmount > planets.Length)
                {
                    NativeArray<Entity> disabledPlanets = EntityManager.CreateEntityQuery(typeof(Disabled), typeof(PlanetProperties)).ToEntityArray(Allocator.TempJob);
                    for (int i = 0; i < planetAmount - planets.Length; i++)
                    {
                        EntityManager.SetEnabled(disabledPlanets[i], true);
                        EntityManager.SetComponentData(disabledPlanets[i], new Parent { Value = e });
                        EntityManager.SetComponentData(disabledPlanets[i], new OrbitProperties
                        {
                            a = 1 + index * 1,
                            b = 1 + index * 1,
                            speedMultiplier = 5
                        });
                        index++;
                    }
                    disabledPlanets.Dispose();
                }
            }
            else
            {
                for (int i = 0; i < planets.Length; i++)
                {
                    EntityManager.SetEnabled(planets[i], false);
                }
            }
            planets.Dispose();
        }

        [BurstCompile]
        private struct PlanetPositionsJob : IJobForEachWithEntity<PlanetProperties, Translation, Rotation, Scale, OrbitProperties>
        {
            [ReadOnly] public int planetAmount;
            [ReadOnly] public float time;
            public void Execute([ReadOnly] Entity entity, [ReadOnly] int index, [ReadOnly] ref PlanetProperties c0, [WriteOnly] ref Translation c1, [WriteOnly] ref Rotation c2, [WriteOnly]  ref Scale c3, [ReadOnly] ref OrbitProperties c4)
            {
                if (index < planetAmount)
                {
                    c1.Value = c4.GetPoint(time + c0.StartTime);
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            inputDeps = new PlanetPositionsJob
            {
                planetAmount = m_StarSystemProperties.PlanetAmount,
                time = m_Time
            }.Schedule(this, inputDeps);
            return inputDeps;
        }
    }

    public class StarSelectionSystem : JobComponentSystem
    {
        #region Attributes
        private Camera m_MainCamera;
        private NativeQueue<Entity> m_RayCastResultEntities;
        private NativeQueue<float> m_Distances;

        private Entity m_ResultEntity;
        private Entity m_LastResultEntity;
        private float m_MaxRayCastDistance;
        #endregion

        #region Public
        public Entity ResultEntity { get => m_ResultEntity; set => m_ResultEntity = value; }
        public float MaxRayCastDistance { get => m_MaxRayCastDistance; set => m_MaxRayCastDistance = value; }
        public Entity LastResultEntity { get => m_LastResultEntity; set => m_LastResultEntity = value; }


        #endregion

        protected override void OnCreateManager()
        {
            m_RayCastResultEntities = new NativeQueue<Entity>(Allocator.Persistent);
            m_Distances = new NativeQueue<float>(Allocator.Persistent);
            m_LastResultEntity = Entity.Null;
            Enabled = false;
        }

        public void Init()
        {
            m_MainCamera = Camera.main;
            MaxRayCastDistance = m_MainCamera.farClipPlane;
            Enabled = true;
        }

        protected override void OnDestroyManager()
        {
            m_RayCastResultEntities.Dispose();

            m_Distances.Dispose();
        }

        [BurstCompile]
        struct CalculateStarPositionsJob : IJobForEachWithEntity<StarProperties, Translation, Scale>
        {
            [ReadOnly] public Vector3 Start;
            [ReadOnly] public Vector3 End;
            [ReadOnly] public float RayCastDistance;
            [WriteOnly] public NativeQueue<Entity>.Concurrent RayCastResultEntities;
            [WriteOnly] public NativeQueue<float>.Concurrent RayCastDistances;
            public void Execute(Entity entity, [ReadOnly] int index, [ReadOnly] ref StarProperties c0, [ReadOnly] ref Translation c1, [ReadOnly] ref Scale c2)
            {
                if (Vector3.Distance(c1.Value, Start) <= RayCastDistance)
                {
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

            UnityEngine.Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            inputDeps = new CalculateStarPositionsJob
            {
                Start = ray.origin,
                End = ray.origin + ray.direction * m_MaxRayCastDistance,
                RayCastDistance = m_MaxRayCastDistance,
                RayCastResultEntities = m_RayCastResultEntities.ToConcurrent(),
                RayCastDistances = m_Distances.ToConcurrent(),
            }.Schedule(this, inputDeps);
            inputDeps.Complete();

            m_ResultEntity = Entity.Null;
            float min = MaxRayCastDistance;
            while (m_Distances.Count > 0)
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

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class StarRenderSystem : JobComponentSystem
    {
        private EndSimulationEntityCommandBufferSystem m_CommandBufferSystem;
        private EntityQuery m_InstanceQuery;
        private NativeArray<LocalToWorld> m_LocalToWorlds;
        private NativeArray<CustomColor> m_CustomColors;
        private Matrix4x4[] m_Matrices;
        private Vector4[] m_Colors;
        private MaterialPropertyBlock m_MaterialPropertyBlock;
        private UnityEngine.Mesh m_StarMesh;
        private UnityEngine.Material m_StarMaterial;
        private Camera m_Camera;
        private int m_StarAmount;
        private bool m_EnableCulling;
        private bool m_InstancedIndirect;
        public UnityEngine.Mesh StarMesh { get => m_StarMesh; set => m_StarMesh = value; }
        public UnityEngine.Material StarMaterial { get => m_StarMaterial; set => m_StarMaterial = value; }

        protected override void OnCreateManager()
        {
            m_EnableCulling = false;
            m_InstancedIndirect = false;
            if (m_EnableCulling) m_InstanceQuery = EntityManager.CreateEntityQuery(typeof(LocalToWorld), typeof(StarProperties), typeof(CustomColor), typeof(DrawTag));
            else m_InstanceQuery = EntityManager.CreateEntityQuery(typeof(LocalToWorld), typeof(StarProperties), typeof(CustomColor));
            m_StarAmount = 0;
            m_Camera = Camera.main;
            m_Matrices = new Matrix4x4[1023];
            m_Colors = new Vector4[1023];
            m_MaterialPropertyBlock = new MaterialPropertyBlock();
            m_CommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            Enabled = false;
        }

        public void Init()
        {
            Enabled = true;
        }

        protected override void OnDestroyManager()
        {
            m_InstanceQuery.Dispose();
            if (m_LocalToWorlds.IsCreated) m_LocalToWorlds.Dispose();
            if (m_CustomColors.IsCreated) m_CustomColors.Dispose();
        }

        private static unsafe void ToArray(NativeSlice<LocalToWorld> transforms, int count, Matrix4x4[] outMatrices, int offset)
        {
            Assert.AreEqual(sizeof(Matrix4x4), sizeof(LocalToWorld));
            fixed (Matrix4x4* resultMatrices = outMatrices)
            {
                LocalToWorld* sourceMatrices = (LocalToWorld*)transforms.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<Matrix4x4>() * count);
            }
        }

        private static unsafe void ToArray(NativeSlice<CustomColor> colors, int count, Vector4[] outMatrices, int offset)
        {
            Assert.AreEqual(sizeof(Vector4), sizeof(CustomColor));
            fixed (Vector4* resultMatrices = outMatrices)
            {
                CustomColor* sourceMatrices = (CustomColor*)colors.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<Vector4>() * count);
            }
        }

        private static unsafe void ToArray(NativeArray<LocalToWorld> transforms, int count, Matrix4x4[] outMatrices, int offset)
        {
            Assert.AreEqual(sizeof(Matrix4x4), sizeof(LocalToWorld));
            fixed (Matrix4x4* resultMatrices = outMatrices)
            {
                LocalToWorld* sourceMatrices = (LocalToWorld*)transforms.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<Matrix4x4>() * count);
            }
        }

        [BurstCompile]
        struct CalculateCullingJob : IJobForEach<Translation, CustomCullingStat>
        {
            [ReadOnly] public Vector3 Direction;
            [ReadOnly] public Vector3 Start;
            [ReadOnly] public float Distance;
            public void Execute([ReadOnly] ref Translation c1, [ReadOnly] ref CustomCullingStat c3)
            {
                if (Vector3.Angle(Direction, (Vector3)c1.Value - Start) < 20)
                {
                    c3.Culled = false;
                }
                else
                {
                    c3.Culled = true;
                }
            }
        }

        private struct CullingJob : IJobForEachWithEntity<CustomCullingStat>
        {
            public EntityCommandBuffer.Concurrent commandBuffer;
            public void Execute(Entity entity, int index, ref CustomCullingStat c0)
            {
                if (!c0.Culled)
                {
                    commandBuffer.AddComponent(index, entity, new DrawTag { });
                }
                else
                {
                    commandBuffer.RemoveComponent<DrawTag>(index, entity);
                }
            }
        }

        [BurstCompile]
        private struct ExtractionDataJob : IJobForEach<LocalToWorld, StarProperties, CustomColor>
        {
            [NativeDisableContainerSafetyRestriction]
            [WriteOnly] public NativeArray<LocalToWorld> localToWorlds;
            [NativeDisableContainerSafetyRestriction]
            [WriteOnly] public NativeArray<CustomColor> customColors;
            public void Execute([ReadOnly] ref LocalToWorld c0, [ReadOnly] ref StarProperties c1, [ReadOnly] ref CustomColor c2)
            {
                localToWorlds[c1.Index] = c0;
                customColors[c1.Index] = c2;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (m_EnableCulling)
            {
                inputDeps = new CalculateCullingJob
                {
                    Direction = m_Camera.transform.forward,
                    Start = m_Camera.transform.position,
                    Distance = m_Camera.farClipPlane
                }.Schedule(this, inputDeps);
                inputDeps.Complete();
                inputDeps = new CullingJob
                {
                    commandBuffer = m_CommandBufferSystem.CreateCommandBuffer().ToConcurrent()
                }.Schedule(this, inputDeps);
                inputDeps.Complete();
            }

            m_StarAmount = m_InstanceQuery.CalculateLength();
            m_LocalToWorlds = new NativeArray<LocalToWorld>(m_StarAmount, Allocator.TempJob);
            m_CustomColors = new NativeArray<CustomColor>(m_StarAmount, Allocator.TempJob);

            inputDeps = new ExtractionDataJob
            {
                localToWorlds = m_LocalToWorlds,
                customColors = m_CustomColors
            }.Schedule(this, inputDeps);
            inputDeps.Complete();
            if (m_InstancedIndirect)
            {
                //Comp
                //Graphics.DrawMeshInstancedIndirect(m_StarMesh, 0, m_StarMaterial, new Bounds(Vector3.zero, new Vector3(12000, 12000, 12000)), argsBuffer);
            }
            else
            {
                //Here we use the normal Graphics.DrawMeshInstanced. It only support 1023 instances for 1 drawcall.
                int offset = 0;
                while (offset < m_StarAmount)
                {
                    if (m_StarAmount - offset > 1023)
                    {
                        NativeSlice<LocalToWorld> slice = m_LocalToWorlds.Slice(offset, 1023);
                        NativeSlice<CustomColor> colorSlice = m_CustomColors.Slice(offset, 1023);

                        ToArray(slice, 1023, m_Matrices, 0);
                        ToArray(colorSlice, 1023, m_Colors, 0);

                        m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", m_Colors);
                        Graphics.DrawMeshInstanced(m_StarMesh, 0, m_StarMaterial,
                            m_Matrices,
                            1023, m_MaterialPropertyBlock, 0, false, 0, m_Camera);
                        offset += 1023;
                    }
                    else
                    {
                        int amount = m_StarAmount - offset;
                        NativeSlice<LocalToWorld> slice = m_LocalToWorlds.Slice(offset, amount);
                        NativeSlice<CustomColor> colorSlice = m_CustomColors.Slice(offset, amount);

                        Matrix4x4[] matrices = new Matrix4x4[amount];
                        Vector4[] colors = new Vector4[amount];
                        ToArray(slice, amount, matrices, 0);
                        ToArray(colorSlice, amount, colors, 0);
                        m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", colors);

                        Graphics.DrawMeshInstanced(m_StarMesh, 0, m_StarMaterial,
                            matrices,
                            amount, m_MaterialPropertyBlock, 0, false, 0, m_Camera);
                        offset += m_StarAmount - offset;
                    }
                }
            }
            m_LocalToWorlds.Dispose();
            m_CustomColors.Dispose();
            return inputDeps;
        }
    }

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class PlanetRendererSystem : JobComponentSystem
    {
        private UnityEngine.Mesh m_PlanetMesh;
        private UnityEngine.Material m_PlanetMaterial;
        private EntityQuery m_InstanceQuery;
        private Camera m_Camera;
        public UnityEngine.Mesh PlanetMesh { get => m_PlanetMesh; set => m_PlanetMesh = value; }
        public UnityEngine.Material PlanetMaterial { get => m_PlanetMaterial; set => m_PlanetMaterial = value; }
        
        protected override void OnCreateManager()
        {
            m_Camera = Camera.main;
            m_InstanceQuery = EntityManager.CreateEntityQuery(typeof(LocalToWorld), typeof(PlanetProperties));
            Enabled = false;
        }

        public void Init()
        {
            Enabled = true;
        }

        protected override void OnDestroyManager()
        {
            m_InstanceQuery.Dispose();
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var planets = m_InstanceQuery.ToEntityArray(Allocator.TempJob);
            for(int i = 0; i < planets.Length; i++)Graphics.DrawMesh(m_PlanetMesh, EntityManager.GetComponentData<LocalToWorld>(planets[i]).Value, m_PlanetMaterial, 0, m_Camera);
            planets.Dispose();
            return inputDeps;
        }
    }

    #region Unused Systems
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
            EntityQuery entityQuery = EntityManager.CreateEntityQuery(typeof(SpawnerProperties));
            var spawners = entityQuery.ToEntityArray(Allocator.TempJob);
            Debug.Log(spawners);
            Debug.Log(spawners.Length);
            int index = 0;
            for (int i = 0; i < spawners.Length; i++)
            {
                int count = EntityManager.GetComponentData<SpawnerProperties>(spawners[i]).Count;
                Debug.Log(count);
                var prefab = EntityManager.GetComponentData<SpawnerProperties>(spawners[i]).Prefab;
                for (int j = 0; j < count; j++)
                {
                    var instance = EntityManager.Instantiate(prefab);
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
                    EntityManager.SetComponentData(instance, scale);
                    var orbitProperties = m_DensityWave.DensityWaveProperties.GetOrbit(proportion);
                    EntityManager.SetComponentData(instance, starProperties);
                    EntityManager.SetComponentData(instance, orbitProperties);
                    EntityManager.SetComponentData(instance, starSystemProperties);
                    index++;
                }
                EntityManager.DestroyEntity(spawners[i]);
            }
            spawners.Dispose();
            entityQuery.Dispose();
        }

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public NativeQueue<Entity> InsatancedEntities { get => m_InsatancedEntities; set => m_InsatancedEntities = value; }
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
                m_SelectedStarPosition = EntityManager.GetComponentData<Translation>(m_PhysicsWorldSystem.PhysicsWorld.Bodies[m_HitResult[0].RigidBodyIndex].Entity).Value;
            }
            else
            {
                m_SelectedStarPosition = Vector3.zero;
            }
            return inputDeps;
        }
    }
    #endregion
}
