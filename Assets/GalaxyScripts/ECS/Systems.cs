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
    #region Enums
    public enum ViewType
    {
        Galaxy = 1,
        StarSystem = 2,
        Planet = 3
    }
    #endregion

    #region Initialization Systems
    #endregion

    #region Simulation Systems
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class StarTransformSimulationSystem : JobComponentSystem
    {
        #region Attributes
        private float m_DiscreteSimulationTimer;
        #endregion

        #region Public
        private Camera m_MainCamera;
        private GalaxyPattern m_DensityWave;
        private bool m_CalculateOrbit;
        private float m_SimulatedTime;
        private bool m_ContinuousSimulation;
        private float m_DiscreteSimulationTimeStep;
        private StarPositionsJob calculateStarPositionsJob;
        private StarOrbitJob calculateStarOrbitJob;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public bool CalculateOrbit { get => m_CalculateOrbit; set => m_CalculateOrbit = value; }
        public Camera MainCamera { get => m_MainCamera; set => m_MainCamera = value; }
        public float SimulatedTime { get => m_SimulatedTime; set => m_SimulatedTime = value; }
        public bool ContinuousSimulation { get => m_ContinuousSimulation; set => m_ContinuousSimulation = value; }
        public float DiscreteSimulationTimeStep { get => m_DiscreteSimulationTimeStep; set => m_DiscreteSimulationTimeStep = value; }
        #endregion

        #region Managers
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
        #endregion

        #region Methods
        public void SetTime(float simulatedTime)
        {
            SimulatedTime = simulatedTime;
        }
        #endregion

        #region Jobs
        [BurstCompile]
        struct StarPositionsJob : IJobForEach<StarProperties, Translation, OrbitProperties, Scale, CustomColor>
        {
            [ReadOnly] public float currentTime;
            [ReadOnly] public Vector3 cameraPosition;
            [ReadOnly] public GalaxyPatternProperties properties;
            public void Execute([ReadOnly] ref StarProperties c0, [WriteOnly] ref Translation c1, [ReadOnly] ref OrbitProperties c3, [ReadOnly] ref Scale c4, [WriteOnly] ref CustomColor c5)
            {
                float calculatedTime = c0.StartingTime + currentTime;
                c1.Value = c3.GetPoint((c0.StartingTime + currentTime));
                float distance = Vector3.Distance(cameraPosition, c1.Value);
                Vector4 color = properties.GetColor(c0.Proportion);
                color = color.normalized * 2;
                //Color color = Color.white;
                if (distance < 40)
                {
                    distance = 40;
                    c5.Color = (c0.Color.normalized + (Vector4)Color.white).normalized * 2.5f;
                }
                else if (distance > 2000)
                {
                    c5.Color = color;
                    distance = 2000;
                }
                else
                {
                    c5.Color = ((c0.Color * 50 + color * (distance - 50) / 2) / (50 + (distance - 50) / 2)).normalized * 2;
                }
                c4.Value = c0.Mass * distance / 40;
            }

        }
        [BurstCompile]
        struct StarOrbitJob : IJobForEachWithEntity<StarProperties, OrbitProperties>
        {
            [ReadOnly] public GalaxyPatternProperties densityWaveProperties;
            public void Execute(Entity entity, int index, [ReadOnly] ref StarProperties c0, [WriteOnly] ref OrbitProperties c1)
            {
                c1 = densityWaveProperties.GetOrbit(c0.Proportion, c0.OrbitOffset);
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            m_DiscreteSimulationTimer += Time.deltaTime;
            if (m_ContinuousSimulation || m_DiscreteSimulationTimer > m_DiscreteSimulationTimeStep) {
                m_DiscreteSimulationTimer = 0;
                calculateStarPositionsJob.currentTime = SimulatedTime;
                calculateStarPositionsJob.cameraPosition = m_MainCamera.transform.position;
                calculateStarPositionsJob.properties = m_DensityWave.DensityWaveProperties;
                if (m_CalculateOrbit)
                {
                    CalculateOrbit = false;
                    calculateStarOrbitJob.densityWaveProperties = DensityWave.DensityWaveProperties;
                    inputDeps = calculateStarOrbitJob.Schedule(this, inputDeps);
                    inputDeps.Complete();
                }
                inputDeps = calculateStarPositionsJob.Schedule(this, inputDeps);
                inputDeps.Complete();
            }
            return inputDeps;
        }
    }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class PlanetTransformSimulationSystem : JobComponentSystem
    {
        #region Attributes
        private Entity m_StarEntity;
        private StarSystemProperties starSystemProperties;
        #endregion

        #region Public
        private float m_Time;
        private GalaxyPattern m_DensityWave;
        private PlanetGenerator m_PlanetGenerator;
        private PlanetOrbits m_PlanetOrbits;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public float Time { get => m_Time; set => m_Time = value; }
        public PlanetOrbits PlanetOrbits { get => m_PlanetOrbits; set => m_PlanetOrbits = value; }
        public PlanetGenerator PlanetGenerator { get => m_PlanetGenerator; set => m_PlanetGenerator = value; }
        #endregion

        #region Managers
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
        #endregion

        #region Methods
        public void SetTime(float Time)
        {
            this.Time = Time;
        }

        public void ResetEntity(Entity e)
        {
            NativeArray<Entity> planets = EntityManager.CreateEntityQuery(typeof(PlanetProperties)).ToEntityArray(Allocator.TempJob);
            m_StarEntity = e;
            if (e != Entity.Null)
            {
                int index = 0;
                starSystemProperties = EntityManager.GetComponentData<StarSystemProperties>(m_StarEntity);
                FastRandom random = new FastRandom((int)starSystemProperties.Seed * 10000);
                var starProperties = EntityManager.GetComponentData<StarProperties>(m_StarEntity);
                int planetAmount = starSystemProperties.PlanetAmount;
                for (int i = 0; i < planetAmount && i < planets.Length; i++)
                {
                    EntityManager.SetComponentData(planets[i], new Parent { Value = e });
                    OrbitProperties orbitProperties = new OrbitProperties
                    {
                        tiltX = (float)random.NextDouble() * 10,
                        tiltZ = (float)random.NextDouble() * 10,
                        a = starProperties.Mass + 5 + index * 0.5f,
                        b = starProperties.Mass + 5 + index * 0.5f,
                        speedMultiplier = 5
                    };
                    EntityManager.SetComponentData(planets[i], orbitProperties);
                    orbitProperties.a *= starProperties.Mass;
                    orbitProperties.b *= starProperties.Mass;
                    PlanetOrbits.Orbits[i].orbit = orbitProperties;
                    PlanetOrbits.Orbits[i].gameObject.SetActive(true);
                    PlanetOrbits.Orbits[i].CalculateEllipse(0.01f);
                    var renderMesh = EntityManager.GetSharedComponentData<RenderMesh>(planets[i]);
                    renderMesh.material = m_PlanetGenerator.GetPlanetMaterial(index, starSystemProperties.Seed);
                    EntityManager.SetSharedComponentData(planets[i], renderMesh);

                    //Set up material for atmosphere.
                    /*Entity atmosphere = EntityManager.GetBuffer<Child>(planets[i])[0].Value;
                    renderMesh = EntityManager.GetSharedComponentData<RenderMesh>(atmosphere);
                    renderMesh.material = m_PlanetGenerator.GetAtmosphereMaterial(index, m_StarSystemProperties.Seed);
                    EntityManager.SetSharedComponentData(atmosphere, renderMesh);
                    */
                    EntityManager.RemoveComponent<PreviousParent>(planets[i]);
                    index++;
                }
                for (int i = planetAmount; i < planets.Length; i++)
                {
                    EntityManager.SetEnabled(planets[i], false);
                    PlanetOrbits.Orbits[i].gameObject.SetActive(false);
                }
                if (planetAmount > planets.Length)
                {
                    NativeArray<Entity> disabledPlanets = EntityManager.CreateEntityQuery(typeof(Disabled), typeof(PlanetProperties)).ToEntityArray(Allocator.TempJob);
                    for (int i = 0; i < planetAmount - planets.Length; i++)
                    {
                        EntityManager.SetEnabled(disabledPlanets[i], true);
                        EntityManager.SetComponentData(disabledPlanets[i], new Parent { Value = e });
                        OrbitProperties orbitProperties = new OrbitProperties
                        {
                            tiltX = (float)random.NextDouble() * 10,
                            tiltZ = (float)random.NextDouble() * 10,
                            a = starProperties.Mass + 5 + index * 0.5f,
                            b = starProperties.Mass + 5 + index * 0.5f,
                            speedMultiplier = 5
                        };
                        EntityManager.SetComponentData(disabledPlanets[i], orbitProperties);
                        orbitProperties.a *= starProperties.Mass;
                        orbitProperties.b *= starProperties.Mass;
                        PlanetOrbits.Orbits[i].orbit = orbitProperties;
                        PlanetOrbits.Orbits[i].gameObject.SetActive(true);
                        PlanetOrbits.Orbits[i].CalculateEllipse(0.01f);
                        var renderMesh = EntityManager.GetSharedComponentData<RenderMesh>(disabledPlanets[i]);
                        renderMesh.material = m_PlanetGenerator.GetPlanetMaterial(index, starSystemProperties.Seed);
                        EntityManager.SetSharedComponentData(disabledPlanets[i], renderMesh);

                        //Set up material for atmosphere.
                        /*Entity atmosphere = EntityManager.GetBuffer<Child>(disabledPlanets[i])[0].Value;
                        renderMesh = EntityManager.GetSharedComponentData<RenderMesh>(atmosphere);
                        renderMesh.material = m_PlanetGenerator.GetAtmosphereMaterial(index, m_StarSystemProperties.Seed);
                        EntityManager.SetSharedComponentData(atmosphere, renderMesh);
                        */
                        EntityManager.RemoveComponent<PreviousParent>(disabledPlanets[i]);
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
                    m_PlanetOrbits.Orbits[i].gameObject.SetActive(false);
                }
            }
            planets.Dispose();
        }
        #endregion

        #region Jobs
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

                    c2.Value = Quaternion.AngleAxis(time * 10000, Quaternion.AngleAxis(c4.tiltZ, Vector3.forward) * Quaternion.AngleAxis(c4.tiltX, Vector3.right) * Vector3.up);
                }
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            inputDeps = new PlanetPositionsJob
            {
                planetAmount = starSystemProperties.PlanetAmount,
                time = Time
            }.Schedule(this, inputDeps);
            return inputDeps;
        }
    }
    #endregion

    #region Presentation Systems
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    //If we update the selection system in simulation system group, position will be laggy and orbits and planets will be placed in wrong position.
    public class SelectionSystem : JobComponentSystem
    {
        #region Attributes
        private Camera m_MainCamera;
        private NativeQueue<Entity> m_RayCastResultEntities;
        private NativeQueue<float> m_Distances;
        private float m_Timer;
        private Vector3 m_PreviousPosition;
        private Vector3 m_PreviousCameraPosition;
        private Quaternion m_PreviousCameraRotation;
        private PlanetTransformSimulationSystem m_PlanetPositionSimulationSystem;
        private Vector3 m_DefaultCameraLocalPosition;
        private Quaternion m_DefaultCameraLocalRotation;
        #endregion

        #region Public
        private CameraControl m_CameraControl;
        private ViewType m_ViewType;
        private Entity m_SelectedEntity;
        private Entity m_SelectedStarEntity;
        private Entity m_ResultEntity;
        private Entity m_LastResultEntity;
        private float m_MaxRayCastDistance;
        private bool m_InTransition;
        private Light m_Light;
        private PlanetOrbits m_PlanetOrbits;
        private float m_TransitionTime;
        private StarRenderSystem m_StarRenderSystem;
        public Entity ResultEntity { get => m_ResultEntity; set => m_ResultEntity = value; }
        public float MaxRayCastDistance { get => m_MaxRayCastDistance; set => m_MaxRayCastDistance = value; }
        public Entity LastResultEntity { get => m_LastResultEntity; set => m_LastResultEntity = value; }
        public CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }
        public Light Light { get => m_Light; set => m_Light = value; }
        public PlanetOrbits PlanetOrbits { get => m_PlanetOrbits; set => m_PlanetOrbits = value; }
        public float TransitionTime { get => m_TransitionTime; set => m_TransitionTime = value; }
        public ViewType ViewType { get => m_ViewType; set => m_ViewType = value; }
        public Entity SelectedEntity { get => m_SelectedEntity; set => m_SelectedEntity = value; }
        public Entity SelectedStarEntity { get => m_SelectedStarEntity; set => m_SelectedStarEntity = value; }
        public bool InTransition { get => m_InTransition; set => m_InTransition = value; }
        #endregion

        #region Managers
        protected override void OnCreateManager()
        {
            m_DefaultCameraLocalPosition = new Vector3(0, 0, -10);
            m_DefaultCameraLocalRotation = Quaternion.identity;
            m_RayCastResultEntities = new NativeQueue<Entity>(Allocator.Persistent);
            m_Distances = new NativeQueue<float>(Allocator.Persistent);
            m_LastResultEntity = Entity.Null;
            ViewType = ViewType.Galaxy;
            m_PlanetPositionSimulationSystem = World.Active.GetOrCreateSystem<PlanetTransformSimulationSystem>();
            m_StarRenderSystem = World.Active.GetOrCreateSystem<StarRenderSystem>();
            Enabled = false;
        }

        public void Init()
        {
            m_MainCamera = Camera.main;
            m_MaxRayCastDistance = m_MainCamera.farClipPlane;
            Enabled = true;
        }

        protected override void OnDestroyManager()
        {
            m_RayCastResultEntities.Dispose();

            m_Distances.Dispose();
        }
        #endregion

        #region Methods
        #endregion

        #region Jobs
        [BurstCompile]
        struct StarSelectionJob : IJobForEachWithEntity<Translation, Scale, StarProperties>
        {
            [ReadOnly] public Vector3 Start;
            [ReadOnly] public Vector3 End;
            [ReadOnly] public float RayCastDistance;
            [WriteOnly] public NativeQueue<Entity>.Concurrent RayCastResultEntities;
            [WriteOnly] public NativeQueue<float>.Concurrent RayCastDistances;
            public void Execute([ReadOnly] Entity entity, [ReadOnly] int index, [ReadOnly] ref Translation c0, [ReadOnly] ref Scale c1, [ReadOnly] ref StarProperties c2)
            {
                if (Vector3.Distance(c0.Value, Start) <= RayCastDistance && Vector3.Angle(End - Start, (Vector3)c0.Value - Start) < 90)
                {
                    float d = Vector3.Dot(((Vector3)c0.Value - Start), (End - Start)) / RayCastDistance;
                    float ap = Vector3.Distance(c0.Value, Start);
                    if (ap * ap - d * d < c1.Value * c1.Value)
                    {
                        RayCastResultEntities.Enqueue(entity);
                        RayCastDistances.Enqueue(ap);
                    }
                }
            }
        }

        [BurstCompile]
        struct PlanetSelectionJob : IJobForEachWithEntity<LocalToWorld, Scale, PlanetProperties>
        {
            [ReadOnly] public Vector3 Start;
            [ReadOnly] public Vector3 End;
            [ReadOnly] public float RayCastDistance;
            [WriteOnly] public NativeQueue<Entity>.Concurrent RayCastResultEntities;
            [WriteOnly] public NativeQueue<float>.Concurrent RayCastDistances;
            public void Execute([ReadOnly]Entity entity, [ReadOnly]int index, [ReadOnly]ref LocalToWorld c0, [ReadOnly]ref Scale c1, [ReadOnly]ref PlanetProperties c2)
            {
                if (Vector3.Angle(End - Start, (Vector3)c0.Position - Start) < 90 && Vector3.Distance(c0.Position, Start) <= RayCastDistance)
                {
                    float d = Vector3.Dot(((Vector3)c0.Position - Start), (End - Start)) / RayCastDistance;
                    float ap = Vector3.Distance(c0.Position, Start);
                    if (ap * ap - d * d < c1.Value * c1.Value * 1.5f)
                    {
                        RayCastResultEntities.Enqueue(entity);
                        RayCastDistances.Enqueue(ap);
                    }
                }
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            #region Selection
            UnityEngine.Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            //If we are in galaxy view, then scan for stars. Else scan for planets.
            if (m_ViewType == ViewType.Galaxy)
            {
                inputDeps = new StarSelectionJob
                {
                    Start = ray.origin,
                    End = ray.origin + ray.direction * m_MaxRayCastDistance,
                    RayCastDistance = m_MaxRayCastDistance,
                    RayCastResultEntities = m_RayCastResultEntities.ToConcurrent(),
                    RayCastDistances = m_Distances.ToConcurrent(),
                }.Schedule(this, inputDeps);
            }
            else if (m_ViewType == ViewType.StarSystem || m_ViewType == ViewType.Planet)
            {
                inputDeps = new PlanetSelectionJob
                {
                    Start = ray.origin,
                    End = ray.origin + ray.direction * m_MaxRayCastDistance,
                    RayCastDistance = m_MaxRayCastDistance,
                    RayCastResultEntities = m_RayCastResultEntities.ToConcurrent(),
                    RayCastDistances = m_Distances.ToConcurrent(),
                }.Schedule(this, inputDeps);
            }
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
            #endregion

            #region CameraControl
            if (!m_InTransition)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (m_ResultEntity != Entity.Null)
                    {
                        m_SelectedEntity = m_ResultEntity;
                        //If viewtype is galaxy, we need to switch to star system. if in star system, we need to focus on planet or star.
                        if (m_ViewType == ViewType.Galaxy)
                        {
                            m_ViewType = ViewType.StarSystem;
                            m_CameraControl.DefaultCameraMoveSpeed /= 10;
                            m_DefaultCameraLocalPosition = new Vector3(0, 0, -2);
                            m_SelectedStarEntity = m_SelectedEntity;
                            m_StarRenderSystem.SelectedStarEntity = m_SelectedEntity;
                            m_PlanetPositionSimulationSystem.ResetEntity(m_SelectedStarEntity);
                            m_Light.enabled = true;
                        }
                        else if (m_ViewType == ViewType.StarSystem)
                        {
                            m_ViewType = ViewType.Planet;
                            m_DefaultCameraLocalPosition = new Vector3(0, 0, -0.2f);
                            m_CameraControl.DefaultCameraMoveSpeed /= 10;
                        }
                    }
                    if (m_SelectedEntity != Entity.Null)
                    {
                        m_InTransition = true;
                        m_TransitionTime = Mathf.Pow(Vector3.Distance(m_MainCamera.transform.position, EntityManager.GetComponentData<LocalToWorld>(m_SelectedEntity).Position), 0.25f) / 5;
                        m_Timer = m_TransitionTime;
                        m_PreviousPosition = m_CameraControl.transform.position;
                        m_PreviousCameraPosition = m_MainCamera.transform.localPosition;
                        m_PreviousCameraRotation = m_MainCamera.transform.localRotation;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.G))
                {
                    if (m_ViewType == ViewType.StarSystem)
                    {
                        m_ViewType = ViewType.Galaxy;
                        //m_DefaultCameraLocalPosition = new Vector3(0, 0, -5);
                        m_CameraControl.DefaultCameraMoveSpeed *= 10;
                        m_SelectedEntity = Entity.Null;
                        m_StarRenderSystem.SelectedStarEntity = m_SelectedEntity;
                        m_PlanetPositionSimulationSystem.ResetEntity(Entity.Null);
                        m_Light.enabled = false;
                    }
                    else if (m_ViewType == ViewType.Planet)
                    {
                        m_ViewType = ViewType.StarSystem;
                        m_DefaultCameraLocalPosition = new Vector3(0, 0, -2);
                        m_CameraControl.DefaultCameraMoveSpeed *= 10;
                        m_SelectedEntity = SelectedStarEntity;
                        m_InTransition = true;
                        m_TransitionTime = Mathf.Pow(Vector3.Distance(m_MainCamera.transform.position, EntityManager.GetComponentData<LocalToWorld>(m_SelectedEntity).Position), 0.25f) / 5;
                        m_Timer = m_TransitionTime;
                        m_PreviousPosition = m_CameraControl.transform.position;
                        m_PreviousCameraPosition = m_MainCamera.transform.localPosition;
                        m_PreviousCameraRotation = m_MainCamera.transform.localRotation;
                    }
                }
            }
            if (m_SelectedEntity != Entity.Null)
            {
                Vector3 position = EntityManager.GetComponentData<LocalToWorld>(SelectedEntity).Position;
                if (!InTransition)
                {
                    m_CameraControl.transform.position = position;
                }
                else
                {
                    m_Timer -= Time.deltaTime;
                    if (m_Timer < 0)
                    {
                        m_Timer = 0;
                        InTransition = false;
                    }
                    float t = Mathf.Pow((m_TransitionTime - m_Timer) / m_TransitionTime, 0.25f);
                    m_CameraControl.transform.position = Vector3.Lerp(m_PreviousPosition, position, t);
                    m_MainCamera.transform.localPosition = Vector3.Lerp(m_PreviousCameraPosition, m_DefaultCameraLocalPosition, t);
                    m_MainCamera.transform.localRotation = Quaternion.Lerp(m_PreviousCameraRotation, m_DefaultCameraLocalRotation, t);
                }
            }
            #endregion

            

            return inputDeps;
        }
    }

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class StarRenderSystem : JobComponentSystem
    {
        #region Attributes
        private EndSimulationEntityCommandBufferSystem m_CommandBufferSystem;
        private EntityQuery m_InstanceQuery;
        private NativeArray<LocalToWorld> m_LocalToWorlds;
        private NativeArray<CustomColor> m_CustomColors;
        private Matrix4x4[] m_Matrices;
        private Matrix4x4[] m_IndirectMatrices;
        private Vector4[] m_Colors;
        private Vector4[] m_IndirectColors;
        private MaterialPropertyBlock m_MaterialPropertyBlock;
        private Camera m_Camera;

        #endregion

        #region Public
        private int m_StarAmount;
        private bool m_EnableCulling;
        private bool m_InstancedIndirect;
        private UnityEngine.Mesh m_StarMesh;
        private UnityEngine.Material m_StarMaterial;
        private Light m_Light;
        private Entity m_SelectedStarEntity;
        private PlanetOrbits m_PlanetOrbits;
        public UnityEngine.Mesh StarMesh { get => m_StarMesh; set => m_StarMesh = value; }
        public UnityEngine.Material StarMaterial { get => m_StarMaterial; set => m_StarMaterial = value; }
        public bool EnableCulling { get => m_EnableCulling; set => m_EnableCulling = value; }
        public bool InstancedIndirect { get => m_InstancedIndirect; set => m_InstancedIndirect = value; }
        public Light Light { get => m_Light; set => m_Light = value; }
        public Entity SelectedStarEntity { get => m_SelectedStarEntity; set => m_SelectedStarEntity = value; }
        public PlanetOrbits PlanetOrbits { get => m_PlanetOrbits; set => m_PlanetOrbits = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        #endregion

        #region Managers
        protected override void OnCreateManager()
        {
            Enabled = false;
        }
    
        public void Init()
        {
            m_InstanceQuery = EntityManager.CreateEntityQuery(typeof(LocalToWorld), typeof(StarProperties), typeof(CustomColor));
            m_Camera = Camera.main;
            m_Matrices = new Matrix4x4[1023];
            m_Colors = new Vector4[1023];
            m_IndirectMatrices = new Matrix4x4[m_StarAmount];
            m_IndirectColors = new Vector4[m_StarAmount];
            m_MaterialPropertyBlock = new MaterialPropertyBlock();
            m_CommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            Enabled = true;
        }

        protected override void OnDestroyManager()
        {
            if(m_InstanceQuery != null)m_InstanceQuery.Dispose();
            if (m_LocalToWorlds.IsCreated) m_LocalToWorlds.Dispose();
            if (m_CustomColors.IsCreated) m_CustomColors.Dispose();
        }
        #endregion

        #region Methods
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
        #endregion

        #region Jobs
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
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (m_SelectedStarEntity != Entity.Null)
            {
                Vector3 position = EntityManager.GetComponentData<LocalToWorld>(m_SelectedStarEntity).Position;
                Light.transform.position = position;
                m_PlanetOrbits.transform.position = position;
            }
            m_LocalToWorlds = new NativeArray<LocalToWorld>(m_StarAmount, Allocator.TempJob);
            m_CustomColors = new NativeArray<CustomColor>(m_StarAmount, Allocator.TempJob);

            inputDeps = new ExtractionDataJob
            {
                localToWorlds = m_LocalToWorlds,
                customColors = m_CustomColors
            }.Schedule(this, inputDeps);
            inputDeps.Complete();
            if (InstancedIndirect)
            {
                NativeSlice<LocalToWorld> slice = m_LocalToWorlds.Slice(0, m_StarAmount);
                NativeSlice<CustomColor> colorSlice = m_CustomColors.Slice(0, m_StarAmount);
                ToArray(slice, m_StarAmount, m_Matrices, 0);
                ToArray(colorSlice, m_StarAmount, m_Colors, 0);
                m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", m_Colors);


                //Graphics.DrawMeshInstancedIndirect(m_StarMesh, 0, m_StarMaterial, m_StarMesh.bounds, argsBuffer, 0, m_MaterialPropertyBlock, false, false);
            }
            else
            {
                //Here we use the normal Graphics.DrawMeshInstanced. It only support 1023 instances for 1 drawcall.
                int offset = 0;
                while (offset < StarAmount)
                {
                    if (StarAmount - offset > 1023)
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
                        int amount = StarAmount - offset;
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
                        offset += StarAmount - offset;
                    }
                }
            }
            m_LocalToWorlds.Dispose();
            m_CustomColors.Dispose();

            
            return inputDeps;
        }
    }
    #endregion

    #region Other Systems
    [DisableAutoCreation]
    public class StarEngine : JobComponentSystem
    {
        #region Attributes
        #endregion

        #region Public
        private GalaxyPattern m_DensityWave;
        private Queue<Entity> m_InsatancedStarEntities;
        private int m_StarAmount;
        private int m_MaxPlanetAmount;
        private UnityEngine.Mesh m_PlanetMesh;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public Queue<Entity> InsatancedStarEntities { get => m_InsatancedStarEntities; set => m_InsatancedStarEntities = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        public UnityEngine.Mesh PlanetMesh { get => m_PlanetMesh; set => m_PlanetMesh = value; }
        #endregion

        #region Managers
        public void Init()
        {
            m_InsatancedStarEntities = new Queue<Entity>();
            Update();
        }
        #endregion

        #region Methods
        #endregion

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
                typeof(CustomCullingStat),
                typeof(Translation),
                typeof(Rotation),
                typeof(Scale),
                typeof(LocalToWorld),
                typeof(LocalToParent),
                typeof(RenderMesh),
                typeof(OrbitProperties),
                typeof(PlanetProperties),
                typeof(Parent)
                );
            EntityArchetype planetAtmosphereArchetype = EntityManager.CreateArchetype(
                typeof(Translation),
                typeof(Rotation),
                typeof(Scale),
                typeof(LocalToWorld),
                typeof(LocalToParent),
                typeof(RenderMesh),
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
                        EntityManager.SetComponentData(planet, new Scale { Value = 0.1f });
                        EntityManager.SetComponentData(planet, new PlanetProperties { StartTime = Random.Next() * 360 });
                        RenderMesh renderMesh = new RenderMesh { mesh = m_PlanetMesh };
                        EntityManager.SetSharedComponentData(planet, renderMesh);
                        
                        /*Entity planetAtmosphere = EntityManager.CreateEntity(planetAtmosphereArchetype);
                        EntityManager.SetComponentData(planetAtmosphere, new Parent { Value = planet });
                        EntityManager.SetComponentData(planetAtmosphere, new Scale { Value = 1 });
                        RenderMesh renderMesh2 = new RenderMesh { mesh = m_PlanetMesh };
                        EntityManager.SetSharedComponentData(planetAtmosphere, renderMesh2);*/
                    }
                }
                m_InsatancedStarEntities.Enqueue(instance);
                float proportion = Random.Next();
                float mass = Random.Next();

                var starProperties = new StarProperties
                {
                    Mass = (0.5f + mass * 2) / 10f,
                    StartingTime = Random.Next() * 360,
                    Index = i,
                    Proportion = proportion,
                    OrbitOffset = DensityWave.DensityWaveProperties.GetOrbitOffset(proportion),
                    Color = new Color(Random.Next(), Random.Next(), Random.Next(), 1)
                };

                var color = new CustomColor { };

                var starSystemProperties = new StarSystemProperties
                {
                    Seed = proportion + mass,
                    PlanetAmount = (int)(Random.Next() * 10) + (int)(Random.Next() * 5)
                };

                var scale = new Scale { Value = 1 };
                EntityManager.SetComponentData(instance, scale);
                EntityManager.SetComponentData(instance, starProperties);
                EntityManager.SetComponentData(instance, starSystemProperties);
                EntityManager.SetComponentData(instance, color);
            }
            return inputDeps;
        }
    }
    #endregion
}
