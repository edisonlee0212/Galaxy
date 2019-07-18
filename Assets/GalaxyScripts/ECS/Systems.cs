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
                    c5.Color = (c0.Color + (Vector4)Color.white).normalized * (2f + (40 - distance) / 20);
                }
                else if (distance > 2000)
                {
                    c5.Color = ((c0.Color * 40 + color * (distance - 40)) / distance).normalized * 1.5f;
                    distance = 2000;
                }
                else
                {
                    c5.Color = ((c0.Color * 20 + (Vector4)Color.white * 20 + color * (distance - 40)) / distance).normalized * 1.8f;
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
            if (m_ContinuousSimulation || m_DiscreteSimulationTimer > m_DiscreteSimulationTimeStep)
            {
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
        private NativeQueue<Entity> m_CircleResultEntities;
        private NativeQueue<float> m_CircleDistances;
        private NativeQueue<Matrix4x4> m_CircledResultMatrices;
        private NativeQueue<Color> m_CircledColors;
        private float m_Timer;
        private Vector3 m_PreviousPosition;
        private Quaternion m_PreviousRotation;
        private PlanetTransformSimulationSystem m_PlanetPositionSimulationSystem;
        private StarRenderSystem m_StarRenderSystem;
        private BeaconRenderSystem m_BeaconRenderSystem;
        #endregion

        #region Public
        private CameraControl m_CameraControl;
        private ViewType m_ViewType;
        private Entity m_SelectedEntity;
        private Entity m_LockedStarEntity;
        private Entity m_MouseSelectionResultEntity;
        private Entity m_LastMouseSelectedEntity;
        private float m_MaxRayCastDistance;
        private bool m_InTransition;
        private Light m_Light;
        private PlanetOrbits m_PlanetOrbits;
        private float m_TransitionTime;
        private Entity m_CircleSelectionResultEntity;

        public Entity MouseSelectionResultEntity { get => m_MouseSelectionResultEntity; set => m_MouseSelectionResultEntity = value; }
        public float MaxRayCastDistance { get => m_MaxRayCastDistance; set => m_MaxRayCastDistance = value; }
        public Entity LastMouseSelectedEntity { get => m_LastMouseSelectedEntity; set => m_LastMouseSelectedEntity = value; }
        public CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }
        public Light Light { get => m_Light; set => m_Light = value; }
        public PlanetOrbits PlanetOrbits { get => m_PlanetOrbits; set => m_PlanetOrbits = value; }
        public float TransitionTime { get => m_TransitionTime; set => m_TransitionTime = value; }
        public ViewType ViewType { get => m_ViewType; set => m_ViewType = value; }
        public Entity SelectedEntity { get => m_SelectedEntity; set => m_SelectedEntity = value; }
        public Entity LockedStarEntity { get => m_LockedStarEntity; set => m_LockedStarEntity = value; }
        public bool InTransition { get => m_InTransition; set => m_InTransition = value; }
        public Entity CircleSelectionResultEntity { get => m_CircleSelectionResultEntity; set => m_CircleSelectionResultEntity = value; }
        #endregion

        #region Managers
        protected override void OnCreateManager()
        {
            m_RayCastResultEntities = new NativeQueue<Entity>(Allocator.Persistent);
            m_Distances = new NativeQueue<float>(Allocator.Persistent);
            m_CircleResultEntities = new NativeQueue<Entity>(Allocator.Persistent);
            m_CircleDistances = new NativeQueue<float>(Allocator.Persistent);
            m_CircledResultMatrices = new NativeQueue<Matrix4x4>(Allocator.Persistent);
            m_CircledColors = new NativeQueue<Color>(Allocator.Persistent);
            m_LastMouseSelectedEntity = Entity.Null;

            ViewType = ViewType.Galaxy;
            m_PlanetPositionSimulationSystem = World.Active.GetOrCreateSystem<PlanetTransformSimulationSystem>();
            m_StarRenderSystem = World.Active.GetOrCreateSystem<StarRenderSystem>();
            m_BeaconRenderSystem = World.Active.GetOrCreateSystem<BeaconRenderSystem>();
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
            m_CircledResultMatrices.Dispose();
            m_CircleResultEntities.Dispose();
            m_CircleDistances.Dispose();
            m_Distances.Dispose();
            m_CircledColors.Dispose();
        }
        #endregion

        #region Methods
        #endregion

        #region Jobs
        [BurstCompile]
        struct StarSelectionJob : IJobForEachWithEntity<Translation, Scale, StarProperties, LocalToWorld>
        {
            [ReadOnly] public Vector3 Start;
            [ReadOnly] public Vector3 End;
            [ReadOnly] public Vector3 CameraControlPosition;
            [ReadOnly] public float RayCastDistance;
            [WriteOnly] public NativeQueue<Entity>.Concurrent RayCastResultEntities;
            [WriteOnly] public NativeQueue<float>.Concurrent RayCastDistances;
            [WriteOnly] public NativeQueue<Entity>.Concurrent CircleResultEntities;
            [WriteOnly] public NativeQueue<float>.Concurrent CircleDistances;

            [WriteOnly] public NativeQueue<Matrix4x4>.Concurrent CircledResultMatrices;
            [WriteOnly] public NativeQueue<Color>.Concurrent CircledResultColors;
            public void Execute([ReadOnly] Entity entity, [ReadOnly] int index, [ReadOnly] ref Translation c0, [ReadOnly] ref Scale c1, [ReadOnly] ref StarProperties c2, [WriteOnly] ref LocalToWorld c3)
            {
                float d;
                if (Vector3.Distance(c0.Value, Start) <= RayCastDistance)
                {
                    d = Vector3.Dot(((Vector3)c0.Value - Start), (End - Start)) / RayCastDistance;
                    float ap = Vector3.Distance(c0.Value, Start);
                    if (ap * ap - d * d < c1.Value * c1.Value)
                    {
                        RayCastResultEntities.Enqueue(entity);
                        RayCastDistances.Enqueue(ap);
                    }
                }
                d = Vector3.Distance(CameraControlPosition, c0.Value);
                //Collect information for beacon.
                if (d < 100 && Mathf.Abs(c0.Value.y - CameraControlPosition.y) < 30)
                {
                    Vector2 a = new Vector2(CameraControlPosition.x, CameraControlPosition.z);
                    Vector2 b = new Vector2(c0.Value.x, c0.Value.z);
                    //Here we try to calculate the LocalToWorld for the beacons.
                    float3 position = c0.Value;
                    position.y = (position.y + CameraControlPosition.y) / 2;
                    float length = Mathf.Abs(position.y - CameraControlPosition.y);
                    float4x4 matrix = new float4x4();
                    matrix.c0.x = 0.05f;
                    matrix.c1.y = length;
                    matrix.c2.z = 0.05f;
                    matrix.c3.x = position.x;
                    matrix.c3.y = position.y;
                    matrix.c3.z = position.z;
                    matrix.c3.w = 1;
                    CircledResultMatrices.Enqueue(matrix);
                    Color color;
                    if (Vector2.Distance(a, b) < 1)
                    {
                        color = Color.white;
                        CircleResultEntities.Enqueue(entity);
                        CircleDistances.Enqueue(Vector2.Distance(a, b));
                    }
                    else color = ((Vector4)Color.white + c2.Color).normalized * 1f;
                    CircledResultColors.Enqueue(color);

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
                    CameraControlPosition = m_CameraControl.transform.position,
                    CircledResultColors = m_CircledColors.ToConcurrent(),
                    CircledResultMatrices = m_CircledResultMatrices.ToConcurrent(),
                    RayCastDistance = m_MaxRayCastDistance,
                    RayCastResultEntities = m_RayCastResultEntities.ToConcurrent(),
                    RayCastDistances = m_Distances.ToConcurrent(),
                    CircleDistances = m_CircleDistances.ToConcurrent(),
                    CircleResultEntities = m_CircleResultEntities.ToConcurrent()
                }.Schedule(this, inputDeps);
                inputDeps.Complete();
                int index = 0;

                while (m_CircledColors.Count > 0)
                {
                    m_BeaconRenderSystem.Matrices[index] = m_CircledResultMatrices.Dequeue();
                    m_BeaconRenderSystem.Colors[index] = m_CircledColors.Dequeue();
                    index++;
                }
                m_CircleSelectionResultEntity = Entity.Null;
                float m = 10;
                while (m_CircleResultEntities.Count > 0)
                {
                    Entity e = m_CircleResultEntities.Dequeue();
                    float f = m_CircleDistances.Dequeue();
                    if (f < m)
                    {
                        m = f;
                        m_CircleSelectionResultEntity = e;
                    }
                }

                m_BeaconRenderSystem.BeaconAmount = index;
            }
            else if (m_ViewType == ViewType.StarSystem || m_ViewType == ViewType.Planet)
            {
                m_BeaconRenderSystem.BeaconAmount = 0;
                inputDeps = new PlanetSelectionJob
                {
                    Start = ray.origin,
                    End = ray.origin + ray.direction * m_MaxRayCastDistance,
                    RayCastDistance = m_MaxRayCastDistance,
                    RayCastResultEntities = m_RayCastResultEntities.ToConcurrent(),
                    RayCastDistances = m_Distances.ToConcurrent(),
                }.Schedule(this, inputDeps);
                inputDeps.Complete();

            }
            m_MouseSelectionResultEntity = Entity.Null;
            float min = MaxRayCastDistance;
            while (m_Distances.Count > 0)
            {
                Entity e = m_RayCastResultEntities.Dequeue();
                float f = m_Distances.Dequeue();
                if (f < min)
                {
                    min = f;
                    m_MouseSelectionResultEntity = e;
                    m_LastMouseSelectedEntity = e;
                }
            }

            #endregion

            #region CameraControl
            if (!m_InTransition)
            {
                if (m_ViewType == ViewType.Galaxy && m_CircleSelectionResultEntity != Entity.Null && Input.GetKeyDown(KeyCode.Space))
                {

                    m_SelectedEntity = m_CircleSelectionResultEntity;
                    m_ViewType = ViewType.StarSystem;
                    m_LockedStarEntity = m_SelectedEntity;
                    m_StarRenderSystem.SelectedStarEntity = m_SelectedEntity;
                    m_PlanetPositionSimulationSystem.ResetEntity(m_LockedStarEntity);
                    m_Light.enabled = true;
                    m_InTransition = true;
                    m_TransitionTime = Mathf.Pow(Vector3.Distance(m_MainCamera.transform.position, EntityManager.GetComponentData<LocalToWorld>(m_SelectedEntity).Position), 0.25f) / 2;
                    m_Timer = m_TransitionTime;
                    m_PreviousPosition = m_CameraControl.transform.position;
                    m_CameraControl.StartTransition(m_TransitionTime, m_ViewType);

                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    if (m_MouseSelectionResultEntity != Entity.Null)
                    {
                        m_SelectedEntity = m_MouseSelectionResultEntity;
                        //If viewtype is galaxy, we need to switch to star system. if in star system, we need to focus on planet or star.
                        if (m_ViewType == ViewType.Galaxy)
                        {
                            m_ViewType = ViewType.StarSystem;
                            m_LockedStarEntity = m_SelectedEntity;
                            m_StarRenderSystem.SelectedStarEntity = m_SelectedEntity;
                            m_PlanetPositionSimulationSystem.ResetEntity(m_LockedStarEntity);
                            m_Light.enabled = true;
                        }
                        else if (m_ViewType == ViewType.StarSystem)
                        {
                            m_ViewType = ViewType.Planet;
                        }
                    }
                    if (m_SelectedEntity != Entity.Null)
                    {
                        m_InTransition = true;
                        m_TransitionTime = Mathf.Pow(Vector3.Distance(m_MainCamera.transform.position, EntityManager.GetComponentData<LocalToWorld>(m_SelectedEntity).Position), 0.25f) / 2;
                        m_Timer = m_TransitionTime;
                        m_PreviousPosition = m_CameraControl.transform.position;
                        m_CameraControl.StartTransition(m_TransitionTime, m_ViewType);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.G))
                {
                    if (m_ViewType == ViewType.StarSystem)
                    {
                        m_ViewType = ViewType.Galaxy;
                        m_SelectedEntity = Entity.Null;
                        m_StarRenderSystem.SelectedStarEntity = m_SelectedEntity;
                        m_PlanetPositionSimulationSystem.ResetEntity(Entity.Null);
                        m_Light.enabled = false;
                        m_CameraControl.StartTransition(0.5f, m_ViewType);
                    }
                    else if (m_ViewType == ViewType.Planet)
                    {
                        m_ViewType = ViewType.StarSystem;
                        m_SelectedEntity = LockedStarEntity;
                        m_PreviousPosition = m_CameraControl.transform.position;
                    }
                    if (m_SelectedEntity != Entity.Null)
                    {
                        m_InTransition = true;
                        m_TransitionTime = Mathf.Pow(Vector3.Distance(m_MainCamera.transform.position, EntityManager.GetComponentData<LocalToWorld>(m_SelectedEntity).Position), 0.25f) / 2;
                        m_Timer = m_TransitionTime;
                        m_PreviousPosition = m_CameraControl.transform.position;
                        m_CameraControl.StartTransition(m_TransitionTime, m_ViewType);
                    }
                }
                else if (m_SelectedEntity != Entity.Null)
                {
                    m_CameraControl.transform.position = EntityManager.GetComponentData<LocalToWorld>(SelectedEntity).Position;
                }
            }
            else
            {
                m_Timer -= Time.deltaTime;
                if (m_Timer < 0)
                {
                    m_Timer = 0;
                    m_InTransition = false;
                }
                float t = Mathf.Pow((m_TransitionTime - m_Timer) / m_TransitionTime, 0.25f);
                m_CameraControl.transform.position = Vector3.Lerp(m_PreviousPosition, EntityManager.GetComponentData<LocalToWorld>(SelectedEntity).Position, t);
            }
            #endregion
            return inputDeps;
        }
    }

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class BeaconRenderSystem : JobComponentSystem
    {
        #region Attributes
        private MaterialPropertyBlock m_MaterialPropertyBlock;
        #endregion

        #region Public
        private Matrix4x4[] m_Matrices;
        private Vector4[] m_Colors;
        private UnityEngine.Mesh m_BeaconMesh;
        private UnityEngine.Material m_BeaconMaterial;
        private int m_BeaconAmount;
        public int BeaconAmount { get => m_BeaconAmount; set => m_BeaconAmount = value; }
        public UnityEngine.Mesh BeaconMesh { get => m_BeaconMesh; set => m_BeaconMesh = value; }
        public UnityEngine.Material BeaconMaterial { get => m_BeaconMaterial; set => m_BeaconMaterial = value; }
        public Matrix4x4[] Matrices { get => m_Matrices; set => m_Matrices = value; }
        public Vector4[] Colors { get => m_Colors; set => m_Colors = value; }
        #endregion

        #region Managers
        protected override void OnCreateManager()
        {
            Enabled = false;
        }

        public void Init()
        {
            Matrices = new Matrix4x4[1023];
            Colors = new Vector4[1023];
            m_MaterialPropertyBlock = new MaterialPropertyBlock();
            Enabled = true;
        }

        protected override void OnDestroyManager()
        {
        }
        #endregion

        #region Methods
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (m_BeaconAmount != 0)
            {
                m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", Colors);
                Graphics.DrawMeshInstanced(m_BeaconMesh, 0, m_BeaconMaterial,
                    Matrices,
                    BeaconAmount, m_MaterialPropertyBlock, 0, false, 0, null);
            }
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
        private float4x4[] m_IndirectMatrices;
        private Vector4[] m_Colors;
        private float4[] m_IndirectColors;
        private MaterialPropertyBlock m_MaterialPropertyBlock;
        private ComputeBuffer m_LocalToWorldBuffer;
        private ComputeBuffer m_EmissionColorBuffer;
        private ComputeBuffer m_ArgsBuffer;
        private uint[] args;
        #endregion

        #region Public
        private int m_StarAmount;
        private bool m_EnableCulling;
        private bool m_InstancedIndirect;
        private UnityEngine.Mesh m_StarMesh;
        private UnityEngine.Material m_StarMaterial;
        private UnityEngine.Material m_StarIndirectMaterial;
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
        public UnityEngine.Material StarIndirectMaterial { get => m_StarIndirectMaterial; set => m_StarIndirectMaterial = value; }
        #endregion

        #region Managers
        protected override void OnCreateManager()
        {
            Enabled = false;
        }

        public void Init()
        {
            m_InstancedIndirect = true;
            m_InstanceQuery = EntityManager.CreateEntityQuery(typeof(LocalToWorld), typeof(StarProperties), typeof(CustomColor));
            //For .Graphics.DrawMeshInstancedIndirect();
            args = new uint[5]{ m_StarMesh.GetIndexCount(0), (uint)m_StarAmount, 0, 0, 0 };
            m_ArgsBuffer = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
            m_ArgsBuffer.SetData(args);
            m_LocalToWorldBuffer = new ComputeBuffer(m_StarAmount, 64);
            m_EmissionColorBuffer = new ComputeBuffer(m_StarAmount, 16);
            m_IndirectMatrices = new float4x4[m_StarAmount];
            m_IndirectColors = new float4[m_StarAmount];

            //For Graphics.DrawMeshInstanced();
            m_Matrices = new Matrix4x4[1023];
            m_Colors = new Vector4[1023];
            m_MaterialPropertyBlock = new MaterialPropertyBlock();
            m_CommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

            //Start
            Enabled = true;
        }

        protected override void OnDestroyManager()
        {
            if (m_InstanceQuery != null) m_InstanceQuery.Dispose();
            if (m_LocalToWorlds.IsCreated) m_LocalToWorlds.Dispose();
            if (m_CustomColors.IsCreated) m_CustomColors.Dispose();
            if (m_LocalToWorldBuffer != null) m_LocalToWorldBuffer.Release();
            if (m_EmissionColorBuffer != null) m_EmissionColorBuffer.Release();
        }
        #endregion

        #region Methods
        public static unsafe void ToArray(NativeSlice<LocalToWorld> transforms, int count, Matrix4x4[] outMatrices, int offset)
        {
            Assert.AreEqual(sizeof(Matrix4x4), sizeof(LocalToWorld));
            fixed (Matrix4x4* resultMatrices = outMatrices)
            {
                LocalToWorld* sourceMatrices = (LocalToWorld*)transforms.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<Matrix4x4>() * count);
            }
        }

        public static unsafe void ToArray(NativeSlice<CustomColor> colors, int count, Vector4[] outMatrices, int offset)
        {
            Assert.AreEqual(sizeof(Vector4), sizeof(CustomColor));
            fixed (Vector4* resultMatrices = outMatrices)
            {
                CustomColor* sourceMatrices = (CustomColor*)colors.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<Vector4>() * count);
            }
        }

        public static unsafe void ToArray(NativeArray<CustomColor> colors, int count, float4[] outMatrices, int offset)
        {
            Assert.AreEqual(sizeof(float4), sizeof(CustomColor));
            fixed (float4* resultMatrices = outMatrices)
            {
                CustomColor* sourceMatrices = (CustomColor*)colors.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<float4>() * count);
            }
        }

        private static unsafe void ToArray(NativeArray<LocalToWorld> transforms, int count, float4x4[] outMatrices, int offset)
        {
            Assert.AreEqual(sizeof(float4x4), sizeof(LocalToWorld));
            fixed (float4x4* resultMatrices = outMatrices)
            {
                LocalToWorld* sourceMatrices = (LocalToWorld*)transforms.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<float4x4>() * count);
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
                ToArray(m_LocalToWorlds, m_StarAmount, m_IndirectMatrices, 0);
                ToArray(m_CustomColors, m_StarAmount, m_IndirectColors, 0);
                m_LocalToWorldBuffer.SetData(m_IndirectMatrices);
                m_EmissionColorBuffer.SetData(m_IndirectColors);
                m_StarIndirectMaterial.SetBuffer("localToWorldBuffer", m_LocalToWorldBuffer);
                m_StarIndirectMaterial.SetBuffer("emissionColorBuffer", m_EmissionColorBuffer);
                Graphics.DrawMeshInstancedIndirect(m_StarMesh, 0, m_StarIndirectMaterial, new Bounds(Vector3.zero, Vector3.one * 3000), m_ArgsBuffer, 0, null, 0, false, 0);
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
                            1023, m_MaterialPropertyBlock, 0, false, 0, null);
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
                            amount, m_MaterialPropertyBlock, 0, false, 0, null);
                        offset += StarAmount - offset;
                    }
                }
            }
            m_LocalToWorlds.Dispose();
            m_CustomColors.Dispose();

            if (m_SelectedStarEntity != Entity.Null)
            {
                Vector3 position = EntityManager.GetComponentData<LocalToWorld>(m_SelectedStarEntity).Position;
                Light.transform.position = position;
                m_PlanetOrbits.transform.position = position;
            }
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
