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

    [UpdateBefore(typeof(TransformSystemGroup))]
    public class StarTransformSimulationSystem : JobComponentSystem
    {
        #region Attributes
        private static float m_DiscreteSimulationTimer;
        private UnityEngine.Plane[] planes;
        #endregion

        #region Public
        private static Camera m_Camera;
        private static GalaxyPattern m_DensityWave;
        private static bool m_CalculateOrbit;
        private static float m_SimulatedTime;
        private static bool m_ContinuousSimulation;
        private static float m_DiscreteSimulationTimeStep;
        private static Entity m_FollowedStar;
        private static float m_ScaleFactor;
        private static StarPositionsJob calculateStarPositionsJob;
        private static StarOrbitJob calculateStarOrbitJob;
        public static GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public static bool CalculateOrbit { get => m_CalculateOrbit; set => m_CalculateOrbit = value; }
        public static Camera Camera { get => m_Camera; set => m_Camera = value; }
        public static float SimulatedTime { get => m_SimulatedTime; set => m_SimulatedTime = value; }
        public static bool ContinuousSimulation { get => m_ContinuousSimulation; set => m_ContinuousSimulation = value; }
        public static float DiscreteSimulationTimeStep { get => m_DiscreteSimulationTimeStep; set => m_DiscreteSimulationTimeStep = value; }
        public static Entity FollowedStar { get => m_FollowedStar; set => m_FollowedStar = value; }
        public static float ScaleFactor
        {
            get => m_ScaleFactor;
            set
            {
                if (value >= 1 && value <= 2)
                    m_ScaleFactor = value;
            }
        }

        public static double3 FloatingOrigin;
        #endregion

        #region Managers
        protected override void OnCreate()
        {
            Enabled = false;
        }

        public void Init()
        {
            planes = new UnityEngine.Plane[6];
            m_ScaleFactor = 1;
            m_Camera = Camera.main;
            FloatingOrigin = new double3(0, 0, 0);
            calculateStarPositionsJob = new StarPositionsJob { };
            calculateStarOrbitJob = new StarOrbitJob
            {
                densityWaveProperties = DensityWave.DensityWaveProperties
            };
            m_CalculateOrbit = true;
            Enabled = true;
        }

        public void ShutDown()
        {
            Enabled = false;
            m_FollowedStar = Entity.Null;
            m_ScaleFactor = 1;
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
        struct StarPositionsForIndirectJob : IJobForEach<StarProperties, Position, CustomLocalToWorld, OrbitProperties, Scale, DefaultColor>
        {
            [ReadOnly] public float currentTime;
            [ReadOnly] public double3 floatingOrigin;
            [ReadOnly] public float scaleFactor;
            [ReadOnly] public GalaxyPatternProperties properties;
            [WriteOnly] public NativeQueue<StarRenderInfo>.ParallelWriter starRenderInfos;

            [ReadOnly] public float4 fpls1;
            [ReadOnly] public float4 fpls2;
            [ReadOnly] public float4 fpls3;
            [ReadOnly] public float4 fpls4;
            [ReadOnly] public float4 fpls5;
            [ReadOnly] public float4 fpls6;
            public void Execute([ReadOnly] ref StarProperties c0, [WriteOnly] ref Position c1, [WriteOnly] ref CustomLocalToWorld c2, [ReadOnly] ref OrbitProperties c3, [WriteOnly] ref Scale c4, [WriteOnly] ref DefaultColor c5)
            {
                double3 position = c3.GetPoint((currentTime + c0.StartingTime));
                c1.Value = position;
                position -= floatingOrigin;
                position /= scaleFactor;
                float distance = Vector3.Distance(Vector3.zero, (float3)position);
                Vector4 color = properties.GetColor(c0.Proportion);
                color = color.normalized * 2;
                int factor = 340;
                StarProperties starProperties = c0;
                if (distance < factor)
                {
                    color = (starProperties.Color + (Vector4)Color.white).normalized * (2f + (factor - distance) / factor / 4);
                    c4.Value = c0.Mass * scaleFactor;
                }
                else if (distance > 15000)
                {
                    color = ((starProperties.Color * 40 + color * (distance - 40)) / distance).normalized * 1.5f;
                    distance = 15000;
                    c4.Value = c0.Mass * distance / factor * scaleFactor;
                }
                else
                {
                    color = ((starProperties.Color * 20 + (Vector4)Color.white * 20 + color * (distance - 40)) / distance).normalized * 1.8f;
                    c4.Value = starProperties.Mass * distance / factor * scaleFactor;
                }
                color = color / (1 + (scaleFactor - 1) / 3);
                float4x4 ltw = new float4x4();
                ltw.c0.x = c4.Value;
                ltw.c1.y = c4.Value;
                ltw.c2.z = c4.Value;
                if (position.x < 0.01 && position.x > -0.01 && position.y < 0.01 && position.y > -0.01 && position.z < 0.01 && position.z > -0.01)
                {
                    ltw.c3 = new float4(0, 0, 0, 1);
                }
                else
                {
                    ltw.c3 = new float4((float3)position, 1);
                }
                c5.Color = color;
                c2.Value = ltw;
                bool res = true;
                if (fpls1.x * position.x + fpls1.y * position.y + fpls1.z * position.z + fpls1.w <= c4.Value) res = false;
                if (fpls2.x * position.x + fpls2.y * position.y + fpls2.z * position.z + fpls2.w <= c4.Value) res = false;
                if (fpls3.x * position.x + fpls3.y * position.y + fpls3.z * position.z + fpls3.w <= c4.Value) res = false;
                if (fpls4.x * position.x + fpls4.y * position.y + fpls4.z * position.z + fpls4.w <= c4.Value) res = false;
                if (fpls5.x * position.x + fpls5.y * position.y + fpls5.z * position.z + fpls5.w <= c4.Value) res = false;
                if (fpls6.x * position.x + fpls6.y * position.y + fpls6.z * position.z + fpls6.w <= c4.Value) res = false;
                if (res) starRenderInfos.Enqueue(new StarRenderInfo
                {
                    LocalToWorld = ltw,
                    EmissionColor = color
                });
            }

        }
        [BurstCompile]
        struct StarPositionsJob : IJobForEach<StarProperties, Position, CustomLocalToWorld, OrbitProperties, Scale, DefaultColor>
        {
            [ReadOnly] public float currentTime;
            [ReadOnly] public double3 floatingOrigin;
            [ReadOnly] public float scaleFactor;
            [ReadOnly] public GalaxyPatternProperties properties;
            public void Execute([ReadOnly] ref StarProperties c0, [WriteOnly] ref Position c1, [WriteOnly] ref CustomLocalToWorld c2, [ReadOnly] ref OrbitProperties c3, [WriteOnly] ref Scale c4, [WriteOnly] ref DefaultColor c5)
            {
                double3 position = c3.GetPoint((currentTime + c0.StartingTime));
                c1.Value = position;
                position -= floatingOrigin;
                position /= scaleFactor;
                float distance = Vector3.Distance(Vector3.zero, (float3)position);
                Vector4 color = properties.GetColor(c0.Proportion);
                color = color.normalized * 2;
                int factor = 340;
                StarProperties starProperties = c0;
                if (distance < factor)
                {
                    color = (starProperties.Color + (Vector4)Color.white).normalized * (2f + (factor - distance) / factor / 4);
                    c4.Value = c0.Mass * scaleFactor;
                }
                else if (distance > 15000)
                {
                    color = ((starProperties.Color * 40 + color * (distance - 40)) / distance).normalized * 1.5f;
                    distance = 15000;
                    c4.Value = c0.Mass * distance / factor * scaleFactor;
                }
                else
                {
                    color = ((starProperties.Color * 20 + (Vector4)Color.white * 20 + color * (distance - 40)) / distance).normalized * 1.8f;
                    c4.Value = starProperties.Mass * distance / factor * scaleFactor;
                }
                c5.Color = color / (1 + (scaleFactor - 1) / 3);
                float4x4 ltw = new float4x4();
                ltw.c0.x = c4.Value;
                ltw.c1.y = c4.Value;
                ltw.c2.z = c4.Value;
                if (position.x < 0.01 && position.x > -0.01 && position.y < 0.01 && position.y > -0.01 && position.z < 0.01 && position.z > -0.01)
                {
                    ltw.c3 = new float4(0, 0, 0, 1);
                }
                else
                {
                    ltw.c3 = new float4((float3)position, 1);
                }
                c2.Value = ltw;
            }

        }
        [BurstCompile]
        struct StarOrbitJob : IJobForEachWithEntity<StarProperties, OrbitProperties>
        {
            [ReadOnly] public GalaxyPatternProperties densityWaveProperties;
            public void Execute(Entity entity, int index, [ReadOnly] ref StarProperties c0, [WriteOnly] ref OrbitProperties c1)
            {
                c1 = densityWaveProperties.GetOrbit((float)c0.Proportion, (float3)c0.OrbitOffset);
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            m_DiscreteSimulationTimer += Time.deltaTime;
            if (m_ContinuousSimulation || m_DiscreteSimulationTimer > m_DiscreteSimulationTimeStep)
            {
                if (GalaxyRenderSystem.EnableInstancedIndirect && !GalaxyRenderSystem.EnableGPUFrustumCulling)
                {
                    GeometryUtility.CalculateFrustumPlanes(m_Camera, planes);
                    float4[] fpls = new float4[6];
                    for (int i = 0; i < 6; i++)
                    {
                        fpls[i].x = planes[i].normal.x;
                        fpls[i].y = planes[i].normal.y;
                        fpls[i].z = planes[i].normal.z;
                        fpls[i].w = planes[i].distance;
                    }

                    NativeQueue<StarRenderInfo> queue = new NativeQueue<StarRenderInfo>(Allocator.TempJob);
                    m_DiscreteSimulationTimer = 0;
                    if (m_FollowedStar != Entity.Null) FloatingOrigin = EntityManager.GetComponentData<OrbitProperties>(m_FollowedStar).GetPoint(SimulatedTime + EntityManager.GetComponentData<StarProperties>(m_FollowedStar).StartingTime);
                    var job = new StarPositionsForIndirectJob
                    {
                        currentTime = SimulatedTime,
                        floatingOrigin = FloatingOrigin,
                        scaleFactor = m_ScaleFactor,
                        properties = m_DensityWave.DensityWaveProperties,
                        starRenderInfos = queue.AsParallelWriter(),
                        fpls1 = fpls[0],
                        fpls2 = fpls[1],
                        fpls3 = fpls[2],
                        fpls4 = fpls[3],
                        fpls5 = fpls[4],
                        fpls6 = fpls[5]
                    };

                    if (m_CalculateOrbit)
                    {
                        CalculateOrbit = false;
                        calculateStarOrbitJob.densityWaveProperties = DensityWave.DensityWaveProperties;
                        inputDeps = calculateStarOrbitJob.Schedule(this, inputDeps);
                        inputDeps.Complete();
                    }
                    inputDeps = job.Schedule(this, inputDeps);
                    inputDeps.Complete();
                    int count = queue.Count;
                    var list = GalaxyRenderSystem.m_StarInfoList;
                    for (int i = 0; i < count; i++)
                    {
                        list.Add(queue.Dequeue());
                    }
                    queue.Dispose();
                    return inputDeps;
                }
                else
                {
                    m_DiscreteSimulationTimer = 0;
                    calculateStarPositionsJob.currentTime = SimulatedTime;
                    if (m_FollowedStar != Entity.Null) FloatingOrigin = EntityManager.GetComponentData<OrbitProperties>(m_FollowedStar).GetPoint(SimulatedTime + EntityManager.GetComponentData<StarProperties>(m_FollowedStar).StartingTime);
                    calculateStarPositionsJob.floatingOrigin = FloatingOrigin;
                    calculateStarPositionsJob.scaleFactor = m_ScaleFactor;
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
            }
            return inputDeps;
        }
    }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateBefore(typeof(StarTransformSimulationSystem))]
    public class RaySelectionSystem : JobComponentSystem
    {
        #region Attributes
        private static Camera m_MainCamera;
        private static NativeQueue<Entity> m_RayCastResultEntities;
        private static NativeQueue<float> m_Distances;
        private static NativeQueue<Entity> m_CircleResultEntities;
        private static NativeQueue<float> m_CircleDistances;
        private static NativeQueue<Matrix4x4> m_CircledResultMatrices;
        private static NativeQueue<Color> m_CircledColors;
        private static float m_Timer;
        private static double3 m_PreviousPosition;
        private static Quaternion m_PreviousRotation;
        private static GalaxyRenderSystem m_StarRenderSystem;
        private static BeaconRenderSystem m_BeaconRenderSystem;
        #endregion

        #region Public
        private static CameraControl m_CameraControl;
        private static StarMarker m_StarMarker;
        private static ViewType m_ViewType;
        private static Entity m_SelectedEntity;
        private static Entity m_MouseSelectionResultEntity;
        private static Entity m_LastMouseSelectedEntity;
        private static float m_MaxRayCastDistance;
        private static bool m_InTransition;

        private static PlanetOrbits m_PlanetOrbits;
        private static float m_TransitionTime;
        private static Entity m_CircleSelectionResultEntity;
        private static PlanetarySystem m_PlanetarySystem;
        public static Entity MouseSelectionResultEntity { get => m_MouseSelectionResultEntity; set => m_MouseSelectionResultEntity = value; }
        public static float MaxRayCastDistance { get => m_MaxRayCastDistance; set => m_MaxRayCastDistance = value; }
        public static Entity LastMouseSelectedEntity
        {
            get => m_LastMouseSelectedEntity;
            set
            {
                if (!m_LastMouseSelectedEntity.Equals(value))
                {
                    m_LastMouseSelectedEntity = value;
                    m_StarMarker.Entity = value;
                }
            }
        }
        public static CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }
        public static float TransitionTime { get => m_TransitionTime; set => m_TransitionTime = value; }
        public static Entity SelectedEntity { get => m_SelectedEntity; set => m_SelectedEntity = value; }
        public static bool InTransition { get => m_InTransition; set => m_InTransition = value; }
        public static Entity CircleSelectionResultEntity { get => m_CircleSelectionResultEntity; set => m_CircleSelectionResultEntity = value; }
        public static StarMarker StarMarker { get => m_StarMarker; set => m_StarMarker = value; }
        public static ViewType ViewType { get => m_ViewType; set => m_ViewType = value; }
        public static PlanetarySystem PlanetarySystem { get => m_PlanetarySystem; set => m_PlanetarySystem = value; }
        #endregion

        #region Managers
        protected override void OnCreate()
        {
            m_RayCastResultEntities = new NativeQueue<Entity>(Allocator.Persistent);
            m_Distances = new NativeQueue<float>(Allocator.Persistent);
            m_CircleResultEntities = new NativeQueue<Entity>(Allocator.Persistent);
            m_CircleDistances = new NativeQueue<float>(Allocator.Persistent);
            m_CircledResultMatrices = new NativeQueue<Matrix4x4>(Allocator.Persistent);
            m_CircledColors = new NativeQueue<Color>(Allocator.Persistent);
            m_LastMouseSelectedEntity = Entity.Null;

            ViewType = ViewType.Galaxy;
            m_StarRenderSystem = World.Active.GetOrCreateSystem<GalaxyRenderSystem>();
            m_BeaconRenderSystem = World.Active.GetOrCreateSystem<BeaconRenderSystem>();
            Enabled = false;
        }

        public void Init()
        {
            m_MainCamera = Camera.main;
            m_MaxRayCastDistance = 5000;
            Enabled = true;
        }

        public void ShutDown()
        {
            Enabled = false;
            m_RayCastResultEntities.Clear();
            m_Distances.Clear();
            m_CircleResultEntities.Clear();
            m_CircleDistances.Clear();
            m_CircledResultMatrices.Clear();
            m_CircledColors.Clear();
            m_CircleSelectionResultEntity = Entity.Null;
            m_MouseSelectionResultEntity = Entity.Null;
            m_LastMouseSelectedEntity = Entity.Null;
            ViewType = ViewType.Galaxy;
        }

        protected override void OnDestroy()
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
        struct StarSelectionJob : IJobForEachWithEntity<Scale, StarProperties, CustomLocalToWorld>
        {
            [ReadOnly] public float scaleFactor;
            [ReadOnly] public Vector3 start;
            [ReadOnly] public Vector3 end;
            [ReadOnly] public float rayCastDistance;
            [WriteOnly] public NativeQueue<Entity>.ParallelWriter rayCastResultEntities;
            [WriteOnly] public NativeQueue<float>.ParallelWriter rayCastDistances;
            [WriteOnly] public NativeQueue<Entity>.ParallelWriter circleResultEntities;
            [WriteOnly] public NativeQueue<float>.ParallelWriter circleDistances;

            [WriteOnly] public NativeQueue<Matrix4x4>.ParallelWriter CircledResultMatrices;
            [WriteOnly] public NativeQueue<Color>.ParallelWriter CircledResultColors;
            public void Execute([ReadOnly] Entity entity, [ReadOnly] int index, [ReadOnly] ref Scale c1, [ReadOnly] ref StarProperties c2, [ReadOnly] ref CustomLocalToWorld c3)
            {
                float d;
                float scale = c1.Value;
                float3 position = c3.Position;
                if (Vector3.Distance(position, start) <= rayCastDistance && Vector3.Angle(end - start, position - (float3)start) < 80)
                {
                    d = Vector3.Dot((position - (float3)start), (end - start)) / rayCastDistance;
                    float ap = Vector3.Distance(position, (float3)start);
                    if (ap * ap - d * d < scale * scale)
                    {
                        rayCastResultEntities.Enqueue(entity);
                        rayCastDistances.Enqueue(ap);
                    }
                }
                d = Vector3.Distance(Vector3.zero, position);
                //Collect information for beacon.
                if (d < 150)
                {
                    Vector2 b = new Vector2(position.x, position.z);
                    //Here we try to calculate the LocalToWorld for the beacons.
                    position.y = position.y / 2;
                    float length = Mathf.Abs(position.y);
                    //If beacon is too short to display we return. 
                    if (length < scale) return;
                    float4x4 matrix = new float4x4();
                    matrix.c0.x = Mathf.Clamp(10.0f / d, 0.01f, 0.3f) * scaleFactor * scaleFactor;
                    matrix.c1.y = length;
                    matrix.c2.z = Mathf.Clamp(10.0f / d, 0.01f, 0.3f) * scaleFactor * scaleFactor;
                    matrix.c3.x = position.x;
                    matrix.c3.y = position.y;
                    matrix.c3.z = position.z;
                    matrix.c3.w = 1;
                    CircledResultMatrices.Enqueue(matrix);
                    Color color;
                    if (Vector2.Distance(Vector2.zero, b) < 1)
                    {
                        color = Color.white;
                        circleResultEntities.Enqueue(entity);
                        circleDistances.Enqueue(Vector2.Distance(Vector2.zero, b));
                    }
                    else color = ((Vector4)Color.white + c2.Color).normalized * 1f;
                    CircledResultColors.Enqueue(color);
                }
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (!m_InTransition && m_ViewType == ViewType.Galaxy)
            {
                #region Selection
                UnityEngine.Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
                //If we are in galaxy view, then scan for stars. Else scan for planets.
                inputDeps = new StarSelectionJob
                {
                    scaleFactor = StarTransformSimulationSystem.ScaleFactor,
                    start = ray.origin,
                    end = ray.origin + ray.direction * m_MaxRayCastDistance,
                    CircledResultColors = m_CircledColors.AsParallelWriter(),
                    CircledResultMatrices = m_CircledResultMatrices.AsParallelWriter(),
                    rayCastDistance = m_MaxRayCastDistance,
                    rayCastResultEntities = m_RayCastResultEntities.AsParallelWriter(),
                    rayCastDistances = m_Distances.AsParallelWriter(),
                    circleDistances = m_CircleDistances.AsParallelWriter(),
                    circleResultEntities = m_CircleResultEntities.AsParallelWriter()
                }.Schedule(this, inputDeps);
                inputDeps.Complete();
                int index = 0;

                while (m_CircledColors.Count > 0)
                {
                    BeaconRenderSystem.Matrices[index] = m_CircledResultMatrices.Dequeue();
                    BeaconRenderSystem.Colors[index] = m_CircledColors.Dequeue();
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
                BeaconRenderSystem.BeaconAmount = index;

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
                    }
                }

                if (m_MouseSelectionResultEntity != Entity.Null) LastMouseSelectedEntity = m_MouseSelectionResultEntity;


                #endregion

                #region CameraControl

                if (m_CircleSelectionResultEntity != Entity.Null && Input.GetKeyDown(KeyCode.Space))
                {
                    m_SelectedEntity = m_CircleSelectionResultEntity;
                    ViewType = ViewType.StarSystem;
                    TransitionSetter();
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    if (LastMouseSelectedEntity != Entity.Null)
                    {
                        m_SelectedEntity = LastMouseSelectedEntity;

                        ViewType = ViewType.StarSystem;
                        Debug.Log(m_SelectedEntity);
                        TransitionSetter();

                    }
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (LastMouseSelectedEntity != Entity.Null) LastMouseSelectedEntity = Entity.Null;
                }
                #endregion
            }
            else if (m_InTransition)
            {
                m_Timer -= Time.deltaTime;
                if (m_Timer < 0)
                {
                    m_Timer = 0;
                    m_InTransition = false;
                    LastMouseSelectedEntity = Entity.Null;
                    m_PlanetarySystem.Reset(m_SelectedEntity);
                    StarTransformSimulationSystem.FollowedStar = m_SelectedEntity;
                }
                float t = Mathf.Pow((m_TransitionTime - m_Timer) / m_TransitionTime, 0.25f);
                var tmp = Vector3.Lerp((float3)m_PreviousPosition, (float3)EntityManager.GetComponentData<Position>(SelectedEntity).Value, t);
                StarTransformSimulationSystem.FloatingOrigin = new double3(tmp);
            }

            return inputDeps;
        }
        private void TransitionSetter()
        {
            BeaconRenderSystem.BeaconAmount = 0;
            m_InTransition = true;
            m_TransitionTime = Mathf.Pow(Vector3.Distance(Vector3.zero, EntityManager.GetComponentData<CustomLocalToWorld>(m_SelectedEntity).Position), 0.25f) / 8;
            if (m_TransitionTime < 0.5f) m_TransitionTime = 0.5f;
            m_Timer = m_TransitionTime;
            m_PreviousPosition = StarTransformSimulationSystem.FloatingOrigin;
            m_CameraControl.StartTransition(m_TransitionTime, ViewType);
        }
    }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateAfter(typeof(StarTransformSimulationSystem))]
    public class BoxSelectionSystem : JobComponentSystem
    {
        #region Attributes
        private static Camera m_Camera;
        private static Vector3 m_SavedMousePosition;
        private static Vector3 m_CurrentMousePosition;
        #endregion

        #region Public
        private static float4[] m_ClippingPlanes;
        private static bool m_Selecting;

        public static float4[] ClippingPlanes { get => m_ClippingPlanes; set => m_ClippingPlanes = value; }
        public static bool Selecting
        {
            get => m_Selecting;
            set
            {
                m_Selecting = value;
            }
        }
        #endregion

        #region Managers
        protected override void OnCreate()
        {
            Enabled = false;
        }

        public void Init()
        {
            m_Selecting = false;
            m_Camera = Camera.main;
            m_ClippingPlanes = new float4[6];
            Enabled = true;
        }

        public void ShutDown()
        {
            Enabled = false;
        }

        protected override void OnDestroy()
        {
            ShutDown();
        }

        #endregion

        #region Methods

        private void CalculateClippingPlanes(float farDistance = -1)
        {
            if (farDistance == -1) farDistance = m_Camera.farClipPlane;
            UnityEngine.Plane plane = default;
            Vector3[] points = new Vector3[4];
            if ((m_CurrentMousePosition.x - m_SavedMousePosition.x) * (m_CurrentMousePosition.y - m_SavedMousePosition.y) < 0)
            {
                points[0] = m_Camera.ScreenToWorldPoint(new Vector3(m_SavedMousePosition.x, m_SavedMousePosition.y, farDistance));
                points[1] = m_Camera.ScreenToWorldPoint(new Vector3(m_SavedMousePosition.x, m_CurrentMousePosition.y, farDistance));
                points[2] = m_Camera.ScreenToWorldPoint(new Vector3(m_CurrentMousePosition.x, m_CurrentMousePosition.y, farDistance));
                points[3] = m_Camera.ScreenToWorldPoint(new Vector3(m_CurrentMousePosition.x, m_SavedMousePosition.y, farDistance));
            }
            else
            {
                points[3] = m_Camera.ScreenToWorldPoint(new Vector3(m_SavedMousePosition.x, m_SavedMousePosition.y, farDistance));
                points[2] = m_Camera.ScreenToWorldPoint(new Vector3(m_SavedMousePosition.x, m_CurrentMousePosition.y, farDistance));
                points[1] = m_Camera.ScreenToWorldPoint(new Vector3(m_CurrentMousePosition.x, m_CurrentMousePosition.y, farDistance));
                points[0] = m_Camera.ScreenToWorldPoint(new Vector3(m_CurrentMousePosition.x, m_SavedMousePosition.y, farDistance));
            }
            plane.Set3Points(m_Camera.transform.position, points[0], points[1]);
            m_ClippingPlanes[0] = ToFloat4(plane);
            plane.Set3Points(m_Camera.transform.position, points[1], points[2]);
            m_ClippingPlanes[1] = ToFloat4(plane);
            plane.Set3Points(m_Camera.transform.position, points[2], points[3]);
            m_ClippingPlanes[2] = ToFloat4(plane);
            plane.Set3Points(m_Camera.transform.position, points[3], points[0]);
            m_ClippingPlanes[3] = ToFloat4(plane);
            plane.Set3Points(points[2], points[1], points[0]);
            m_ClippingPlanes[4] = ToFloat4(plane);
        }

        private float4 ToFloat4(UnityEngine.Plane plane)
        {
            float4 ret = default;
            ret.x = plane.normal.x;
            ret.y = plane.normal.y;
            ret.z = plane.normal.z;
            ret.w = plane.distance;
            return ret;
        }
        #endregion

        #region Jobs
        [BurstCompile]
        public struct BoxSelectionJob : IJobForEach<CustomLocalToWorld, BoxSelected, DisplayColor, DefaultColor>
        {
            [ReadOnly] public float4 p0, p1, p2, p3, p4;
            [ReadOnly] public int mode;
            public void Execute([ReadOnly] ref CustomLocalToWorld c0, [WriteOnly] ref BoxSelected c1, [WriteOnly] ref DisplayColor c2, [ReadOnly] ref DefaultColor c3)
            {
                if (mode == 0)
                {
                    float3 pos = c0.Position;
                    float radius = c0.Value.c0.x;
                    bool selected = true;
                    if (p0.x * pos.x + p0.y * pos.y + p0.z * pos.z + p0.w <= radius) selected = false;
                    if (p1.x * pos.x + p1.y * pos.y + p1.z * pos.z + p1.w <= radius) selected = false;
                    if (p2.x * pos.x + p2.y * pos.y + p2.z * pos.z + p2.w <= radius) selected = false;
                    if (p3.x * pos.x + p3.y * pos.y + p3.z * pos.z + p3.w <= radius) selected = false;
                    if (p4.x * pos.x + p4.y * pos.y + p4.z * pos.z + p4.w <= radius) selected = false;
                    c1.Value = selected;
                    if (selected)
                    {
                        c2.Color = Color.red;
                    }
                    else
                    {
                        c2.Color = c3.Color;
                    }
                }
                else if (mode == 1)
                {
                    c1.Value = false;
                    c2.Color = c3.Color;
                }
                else
                {
                    if (c1.Value)
                    {
                        c2.Color = Color.red;
                    }
                    else
                    {
                        c2.Color = c3.Color;
                    }
                }
            }
        }

        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                m_Selecting = true;
                m_SavedMousePosition = Input.mousePosition;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                m_Selecting = false;
            }
            if (m_Selecting)
            {
                m_CurrentMousePosition = Input.mousePosition;
                if (m_Selecting && m_CurrentMousePosition != m_SavedMousePosition)
                {
                    CalculateClippingPlanes();
                }
            }

            inputDeps = new BoxSelectionJob
            {
                mode = m_Selecting && m_CurrentMousePosition != m_SavedMousePosition ? 0 : Input.GetKeyDown(KeyCode.Escape) ? 1 : 2,
                p0 = m_ClippingPlanes[0],
                p1 = m_ClippingPlanes[1],
                p2 = m_ClippingPlanes[2],
                p3 = m_ClippingPlanes[3],
                p4 = m_ClippingPlanes[4]
            }.Schedule(this, inputDeps);
            inputDeps.Complete();
            return inputDeps;
        }
    }


    #endregion

    #region Presentation Systems

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class BeaconRenderSystem : JobComponentSystem
    {
        #region Attributes
        private static MaterialPropertyBlock m_MaterialPropertyBlock;
        #endregion

        #region Public
        private static Matrix4x4[] m_Matrices;
        private static Vector4[] m_Colors;
        private static UnityEngine.Mesh m_BeaconMesh;
        private static UnityEngine.Material m_BeaconMaterial;
        private static int m_BeaconAmount;
        private static bool m_DrawBeacon;
        public static int BeaconAmount { get => m_BeaconAmount; set => m_BeaconAmount = value; }
        public static UnityEngine.Mesh BeaconMesh { get => m_BeaconMesh; set => m_BeaconMesh = value; }
        public static UnityEngine.Material BeaconMaterial { get => m_BeaconMaterial; set => m_BeaconMaterial = value; }
        public static Matrix4x4[] Matrices { get => m_Matrices; set => m_Matrices = value; }
        public static Vector4[] Colors { get => m_Colors; set => m_Colors = value; }
        public static bool DrawBeacon { get => m_DrawBeacon; set => m_DrawBeacon = value; }
        #endregion

        #region Managers
        protected override void OnCreateManager()
        {
            Matrices = new Matrix4x4[1023];
            Colors = new Vector4[1023];
            m_MaterialPropertyBlock = new MaterialPropertyBlock();
            Enabled = false;
        }

        public void Init()
        {
            Enabled = true;
        }

        public void ShutDown()
        {
            Enabled = false;
        }

        protected override void OnDestroyManager()
        {
            ShutDown();
        }
        #endregion

        #region Methods
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (m_DrawBeacon && m_BeaconAmount != 0 && m_BeaconAmount < 1024)
            {
                m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", Colors);
                Graphics.DrawMeshInstanced(m_BeaconMesh, 0, m_BeaconMaterial,
                    Matrices,
                    BeaconAmount, m_MaterialPropertyBlock, 0, false, 0, null);
            }
            if (m_BeaconAmount >= 1024)
            {
                Debug.Log("Too many beacons! [" + m_BeaconAmount + "]");
            }
            return inputDeps;
        }
    }

    public struct StarConnection
    {
        public int FromIndex;
        public int ToIndex;
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
            Random.seed = Game.Seed;
            EntityArchetype starEntityArchetype = EntityManager.CreateArchetype(
                typeof(CustomCullingStat),
                typeof(Position),
                typeof(Rotation),
                typeof(StarProperties),
                typeof(DisplayColor),
                typeof(DefaultColor),
                typeof(OrbitProperties),
                typeof(Scale),
                typeof(CustomLocalToWorld),
                typeof(BoxSelected),
                typeof(RaySelected)
                );

            for (ushort i = 0; i < m_StarAmount; i++)
            {
                Entity instance = EntityManager.CreateEntity(starEntityArchetype);
                m_InsatancedStarEntities.Enqueue(instance);

                float proportion = Random.Next();
                float mass = Random.Next();

                var starProperties = new StarProperties
                {
                    Mass = 0.5f + mass,
                    StartingTime = Random.Next() * 360,
                    Index = i,
                    Proportion = proportion,
                    OrbitOffset = DensityWave.DensityWaveProperties.GetOrbitOffset(proportion),
                    Color = new Color(Random.Next(), Random.Next(), Random.Next(), 1)
                };

                var scale = new Scale { Value = 1 };
                EntityManager.SetComponentData(instance, scale);
                EntityManager.SetComponentData(instance, starProperties);

            }
            return inputDeps;
        }
    }

    public unsafe struct StarData
    {
        public ushort Reference;
        public byte PlanetAmount;
        public float Proportion;
        public int FirstPlanetReference;
    }

    public struct PlanetData
    {
        public int Reference;
        public byte Index;
        public ushort StarReference;
        public float Seed;
        public float DistanceToStar;
    }


    public unsafe struct ResourceData
    {
        public int PlanetReference;
        public fixed uint ResourceList[Game.ElementSize];
    }

    public struct EnergyData
    {
        public ushort StarReference;
    }

    [DisableAutoCreation]
    public class DataSystem : JobComponentSystem
    {
        #region Attribute
        private static EntityQuery m_InstanceQuery;
        #endregion

        #region Public
        private static int m_StarAmount;
        private static int m_PlanetAmount;
        private static NativeArray<StarData> m_StarDatas;
        private static NativeArray<PlanetData> m_PlanetDatas;
        private static NativeArray<ResourceData> m_ResourceDatas;
        public static int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public static int PlanetAmount { get => m_PlanetAmount; set => m_PlanetAmount = value; }
        public static NativeArray<StarData> StarDatas { get => m_StarDatas; }
        public static NativeArray<PlanetData> PlanetDatas { get => m_PlanetDatas; }
        public static NativeArray<ResourceData> ResourceDatas { get => m_ResourceDatas; set => m_ResourceDatas = value; }
        #endregion

        #region Managers

        protected override void OnCreate()
        {
            if (m_InstanceQuery != null) m_InstanceQuery.Dispose();
            m_InstanceQuery = EntityManager.CreateEntityQuery(typeof(StarProperties));
        }

        public void Init()
        {
            if (StarDatas.IsCreated) StarDatas.Dispose();
            if (PlanetDatas.IsCreated) PlanetDatas.Dispose();
            if (ResourceDatas.IsCreated) ResourceDatas.Dispose();
            m_StarDatas = new NativeArray<StarData>(m_StarAmount, Allocator.Persistent);

            Update();
        }

        protected override void OnDestroy()
        {
            if (StarDatas.IsCreated) StarDatas.Dispose();
            if (PlanetDatas.IsCreated) PlanetDatas.Dispose();
            if (ResourceDatas.IsCreated) ResourceDatas.Dispose();
            if (m_InstanceQuery != null) m_InstanceQuery.Dispose();
        }
        #endregion

        #region Methods
        #endregion

        #region Jobs
        public struct StarDataGenerator : IJobParallelFor
        {
            [NativeDisableContainerSafetyRestriction]
            [WriteOnly] public NativeArray<StarData> starDatas;
            [ReadOnly] public NativeArray<StarProperties> starsProperties;

            public void Execute(int index)
            {
                StarData starData = default;
                starData.Reference = starsProperties[index].Index;
                starData.Proportion = starsProperties[index].Proportion;
                starDatas[index] = starData;
            }
        }

        public unsafe struct ResourceDataGenerator : IJobParallelFor
        {
            [ReadOnly] public NativeArray<PlanetData> planetDatas;
            [NativeDisableContainerSafetyRestriction]
            [WriteOnly] public NativeArray<ResourceData> resourceDatas;
            public void Execute(int index)
            {
                ResourceData resourceData = default;
                resourceData.ResourceList[0] = 100;
                //TODO: Calculate resource list;
                resourceDatas[index] = resourceData;
            }
        }

        #endregion
        protected unsafe override JobHandle OnUpdate(JobHandle inputDeps)
        {
            Random.seed = Game.Seed;
            var starProperties = m_InstanceQuery.ToComponentDataArray<StarProperties>(Allocator.TempJob, out inputDeps);
            inputDeps.Complete();
            inputDeps = new StarDataGenerator
            {
                starDatas = StarDatas,
                starsProperties = starProperties
            }.Schedule(m_StarAmount, 100, inputDeps);
            inputDeps.Complete();
            starProperties.Dispose();
            m_PlanetAmount = 0;


            for (int i = 0; i < m_StarAmount; i++)
            {
                var starData = m_StarDatas[i];
                var a = Random.Next();
                var b = Random.Next();
                starData.PlanetAmount = (byte)((a * a * 7) + (b * 3));
                m_PlanetAmount += starData.PlanetAmount;
                m_StarDatas[i] = starData;
            }

            Debug.Log("Total Star Amount: " + m_StarAmount + "\nTotal Planet Amount: " + m_PlanetAmount + ". Average planet amount: " + (float)m_PlanetAmount / m_StarAmount);

            m_PlanetDatas = new NativeArray<PlanetData>(m_PlanetAmount, Allocator.Persistent);

            int index = 0;
            for (int i = 0; i < m_StarAmount; i++)
            {
                StarData starData = m_StarDatas[i];
                int planetAmount = starData.PlanetAmount;
                for (int j = 0; j < planetAmount; j++)
                {
                    PlanetData planetData = default;
                    planetData.DistanceToStar = 6 + 2 * j;
                    planetData.Index = (byte)j;
                    planetData.StarReference = (ushort)i;
                    planetData.Reference = index;
                    planetData.Seed = Random.Next();
                    m_PlanetDatas[index] = planetData;
                    if (j == 0)
                    {
                        starData.FirstPlanetReference = index;
                        m_StarDatas[i] = starData;
                    }
                    index++;
                }
            }

            m_ResourceDatas = new NativeArray<ResourceData>(m_PlanetAmount, Allocator.Persistent);
            inputDeps = new ResourceDataGenerator
            {
                resourceDatas = m_ResourceDatas,
                planetDatas = m_PlanetDatas
            }.Schedule(m_StarAmount, 1000, inputDeps);
            inputDeps.Complete();

            return inputDeps;
        }
    }
    #endregion
}
