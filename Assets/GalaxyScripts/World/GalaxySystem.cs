using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Galaxy
{
    [CreateAssetMenu]
    public class GalaxySystem : ScriptableObject
    {
        #region Attributes
        [SerializeField]
        private NebulasSystem m_NebulasSystem;
        [SerializeField]
        private Mesh m_StarMesh;
        [SerializeField]
        private Mesh m_PlanetMesh;
        [SerializeField]
        private Material m_StarMaterial;
        [SerializeField]
        private Material m_StarIndirectMaterial;
        
        [SerializeField]
        private Light m_Light;
        [SerializeField]
        private PlanetOrbits m_PlanetOrbits;
        [SerializeField]
        private Mesh m_BeaconMesh;
        [SerializeField]
        private Material m_BeaconMaterial;
        
        private StarRenderSystem m_StarRenderSystem;
        private BeaconRenderSystem m_BeaconRenderSystem;
        #endregion

        #region Public
        private int m_StarAmount;
        private PlanetarySystem m_PlanetarySystem;
        private SelectionSystem m_SelectionSystem;
        private CameraControl m_CameraControl;
        private GalaxyPattern m_GalaxyPattern;
        private Galaxy m_Galaxy;
        private int m_MaxPlanetAmount;
        private StarMarker m_StarMarker;
        public GalaxyPattern GalaxyPattern { get => m_GalaxyPattern; set => m_GalaxyPattern = value; }
        public Galaxy Galaxy { get => m_Galaxy; set => m_Galaxy = value; }
        public CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        public Mesh BeaconMesh { get => m_BeaconMesh; set => m_BeaconMesh = value; }
        public Material BeaconMaterial { get => m_BeaconMaterial; set => m_BeaconMaterial = value; }
        public Material StarIndirectMaterial { get => m_StarIndirectMaterial; set => m_StarIndirectMaterial = value; }
        public SelectionSystem SelectionSystem { get => m_SelectionSystem; set => m_SelectionSystem = value; }
        public StarMarker StarMarker { get => m_StarMarker; set => m_StarMarker = value; }
        public PlanetarySystem PlanetarySystem { get => m_PlanetarySystem; set => m_PlanetarySystem = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        #endregion

        #region Managers
        public void Init(GalaxyPatternProperties densityWaveProperties, int starAmount = 10000, int maxPlanetAmount = 20)
        {
            m_StarAmount = starAmount;
            m_MaxPlanetAmount = maxPlanetAmount;
            m_PlanetarySystem.MaxPlanetAmount = maxPlanetAmount;
            //Create density wave
            GalaxyPattern = new GalaxyPattern(densityWaveProperties);

            //Prepare star system
            Light light = Instantiate(m_Light);
            light.enabled = false;
            m_PlanetarySystem.Light = light;
            m_PlanetarySystem.CameraControl = m_CameraControl;
            PlanetOrbits planetOrbits = Instantiate(m_PlanetOrbits);
            planetOrbits.MaxPlanetAmount = MaxPlanetAmount;
            planetOrbits.Init();


            //Create nebula system
            m_NebulasSystem.GalaxyPattern = GalaxyPattern;
            m_NebulasSystem.Init();

            //Create galaxy system
            Galaxy = new Galaxy(m_MaxPlanetAmount, m_GalaxyPattern, m_PlanetMesh, StarAmount, planetOrbits);
            Galaxy.PlanetarySystem = PlanetarySystem;
            Galaxy.Init();

            //Create selection system
            m_SelectionSystem = World.Active.GetOrCreateSystem<SelectionSystem>();
            m_SelectionSystem.CameraControl = m_CameraControl;
            m_SelectionSystem.PlanetarySystem = m_PlanetarySystem;
            m_SelectionSystem.StarMarker = m_StarMarker;
            m_SelectionSystem.Init();

            //Create renderer
            m_StarRenderSystem = World.Active.GetOrCreateSystem<StarRenderSystem>();
            m_BeaconRenderSystem = World.Active.GetOrCreateSystem<BeaconRenderSystem>();
            m_StarRenderSystem.Light = light;
            m_StarRenderSystem.PlanetOrbits = planetOrbits;
            m_StarRenderSystem.StarAmount = StarAmount;
            m_StarRenderSystem.StarMesh = m_StarMesh;
            m_StarRenderSystem.StarMaterial = m_StarMaterial;
            m_StarRenderSystem.StarIndirectMaterial = m_StarIndirectMaterial;
            m_BeaconRenderSystem.BeaconMaterial = m_BeaconMaterial;
            m_BeaconRenderSystem.BeaconMesh = m_BeaconMesh;
            m_StarRenderSystem.Init();
            m_BeaconRenderSystem.Init();
        }
        #endregion

        public void ShutDown()
        {
            
            m_Galaxy.Destroy();
            m_SelectionSystem.Enabled = false;
            m_StarRenderSystem.Enabled = false;
            m_BeaconRenderSystem.Enabled = false;
        }

        #region Methods
        public void AddTime(float time)
        {
            m_Galaxy.AddTime(time);
        }

        public void SetTime(float time)
        {
            m_Galaxy.SetTime(time);
        }
        #endregion
    }
    public class Galaxy
    {
        #region Attributes
        private PlanetarySystem m_PlanetarySystem;
        #endregion

        #region Public
        private float m_Time;
        private int m_StarAmount;
        private int m_OrbitsAmount;
        private GalaxyPattern m_DensityWave;
        private StarTransformSimulationSystem m_StarTransformSimulationSystem;
        private StarEngine m_StarEngine;
        private PlanetOrbits m_PlanetOrbits;
        private DataSystem m_DataSystem;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarTransformSimulationSystem StarTransformSimulationSystem { get => m_StarTransformSimulationSystem; set => m_StarTransformSimulationSystem = value; }
        public float Time { get => m_Time; }
        public StarEngine StarEngine { get => m_StarEngine; set => m_StarEngine = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public PlanetarySystem PlanetarySystem { get => m_PlanetarySystem; set => m_PlanetarySystem = value; }
        public PlanetOrbits PlanetOrbits { get => m_PlanetOrbits; set => m_PlanetOrbits = value; }
        public DataSystem DataSystem { get => m_DataSystem; set => m_DataSystem = value; }

        #endregion

        #region Managers
        public Galaxy(int maxPlanetAmount, GalaxyPattern densityWave, Mesh planetMesh, int starAmount, PlanetOrbits planetOrbits)
        {
            m_StarAmount = starAmount;
            m_PlanetOrbits = planetOrbits;
            m_DensityWave = densityWave;
            m_StarTransformSimulationSystem = World.Active.GetOrCreateSystem<StarTransformSimulationSystem>();
            EntityManager entityManager = World.Active.EntityManager;
            var entitiesArray = entityManager.GetAllEntities(Allocator.Temp);
            entityManager.DestroyEntity(entitiesArray);
            entitiesArray.Dispose();
            m_StarEngine = World.Active.GetOrCreateSystem<StarEngine>();

            m_StarTransformSimulationSystem.DiscreteSimulationTimeStep = 0.02f;
            m_StarTransformSimulationSystem.ContinuousSimulation = true;

            m_StarTransformSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngine.DensityWave = m_DensityWave;
            m_StarEngine.StarAmount = starAmount;
            
            m_StarEngine.MaxPlanetAmount = maxPlanetAmount;
            m_StarEngine.PlanetMesh = planetMesh;

            m_DataSystem = World.Active.GetOrCreateSystem<DataSystem>();
            m_DataSystem.StarAmount = starAmount;
        }

        public void Init()
        {
            m_StarEngine.Init();
            m_DataSystem.Init();
            m_StarTransformSimulationSystem.Init();
            m_PlanetarySystem.PlanetOrbits = m_PlanetOrbits;
            m_PlanetarySystem.Init();
        }
        
        public void Destroy()
        {
            m_StarTransformSimulationSystem.Enabled = false;
        }

        #endregion

        #region Methods

        public void SetTime(float time)
        {
            m_Time = time;
            m_StarTransformSimulationSystem.SetTime(Time);
        }

        public void AddTime(float time)
        {
            m_Time += time;
            m_StarTransformSimulationSystem.SetTime(Time);
        }
        #endregion
    }

    public class GalaxyPattern
    {
        public GalaxyPatternProperties properties;

        public GalaxyPatternProperties DensityWaveProperties { get => properties; set => properties = value; }

        #region Properties setters

        public void SetCenterPositionX(float x)
        {
            properties.CenterPosition.x = x;
        }

        public void SetCenterPositionY(float y)
        {
            properties.CenterPosition.y = y;
        }

        public void SetCenterPositionZ(float z)
        {
            properties.CenterPosition.z = z;
        }

        public void SetDensityWaveProperties(GalaxyPatternProperties densityWaveProperties)
        {
            DensityWaveProperties = densityWaveProperties;
            SetAB();
        }

        public void SetRotation(float rotation)
        {
            properties.Rotation = rotation;
        }

        public void SetCoreProportion(float proportion)
        {
            properties.CoreProportion = proportion;
            SetAB();
        }

        public void SetCoreEccentricity(float eccentricity)
        {
            properties.CoreEccentricity = eccentricity;
            SetAB();
        }

        public void SetCenterEccentricity(float eccentricity)
        {
            properties.CenterEccentricity = eccentricity;
            SetAB();
        }

        public void SetDiskAB(float diskAB)
        {
            properties.DiskAB = diskAB;
            SetAB();
        }

        public void SetDiskEccentricity(float eccentricity)
        {
            properties.DiskEccentricity = eccentricity;
            SetAB();
        }

        public void SetCoreSpeed(float speed)
        {
            properties.CoreSpeed = speed;
        }

        public void SetCenterSpeed(float speed)
        {
            properties.CenterSpeed = speed;
        }

        public void SetDiskSpeed(float speed)
        {
            properties.DiskSpeed = speed;
        }

        public void SetCenterAB(float centerAB)
        {
            properties.CenterAB = centerAB * 2;
            SetAB();
        }

        public void SetCenterTiltX(float tiltX)
        {
            properties.CenterTiltX = tiltX;
        }

        public void SetCenterTiltZ(float tiltZ)
        {
            properties.CenterTiltZ = tiltZ;
        }

        public void SetDiskTiltX(float tiltX)
        {
            properties.DiskTiltX = tiltX;
        }

        public void SetDiskTiltZ(float tiltZ)
        {
            properties.DiskTiltZ = tiltZ;
        }

        public void SetCoreTiltX(float tiltX)
        {
            properties.CoreTiltX = tiltX;
        }

        public void SetCoreTiltZ(float tiltZ)
        {
            properties.CoreTiltZ = tiltZ;
        }

        private void SetAB()
        {
            properties.CoreAB = properties.CenterAB / 2 + properties.CenterAB / 2 +
                ((properties.DiskA + properties.DiskB) - properties.CenterAB / 2 - properties.CenterAB / 2)
                * properties.CoreProportion;
            properties.CoreA = properties.CoreAB * properties.CoreEccentricity;
            properties.CoreB = properties.CoreAB * (1 - properties.CoreEccentricity);
            properties.DiskA = properties.DiskAB * properties.DiskEccentricity;
            properties.DiskB = properties.DiskAB * (1 - properties.DiskEccentricity);
            properties.CenterA = properties.CenterAB * properties.CenterEccentricity;
            properties.CenterB = properties.CenterAB * (1 - properties.CenterEccentricity);
        }
        #endregion

        public OrbitProperties GetOrbit(float proportion, float3 orbitOffset)
        {
            return properties.GetOrbit(proportion, orbitOffset);
        }

        public GalaxyPattern(GalaxyPatternProperties densityWaveProperties)
        {
            SetDensityWaveProperties(densityWaveProperties);
        }
        public float3 GetOrbitOffset(float proportion)
        {
            return properties.GetOrbitOffset(proportion);
        }
    }
}
