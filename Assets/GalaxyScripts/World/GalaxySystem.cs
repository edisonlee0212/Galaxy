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
        private PlanetGenerator m_PlanetGenerator;
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
        private int m_StarAmount;
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
        private SelectionSystem m_SelectionSystem;
        private CameraControl m_CameraControl;
        private GalaxyPattern m_DensityWave;
        private Galaxy m_Galaxy;
        private int m_MaxPlanetAmount;
        private StarMarker m_StarMarker;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public Galaxy Galaxy { get => m_Galaxy; set => m_Galaxy = value; }
        public CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        public Mesh BeaconMesh { get => m_BeaconMesh; set => m_BeaconMesh = value; }
        public Material BeaconMaterial { get => m_BeaconMaterial; set => m_BeaconMaterial = value; }
        public Material StarIndirectMaterial { get => m_StarIndirectMaterial; set => m_StarIndirectMaterial = value; }
        public SelectionSystem SelectionSystem { get => m_SelectionSystem; set => m_SelectionSystem = value; }
        public StarMarker StarMarker { get => m_StarMarker; set => m_StarMarker = value; }
        #endregion

        #region Managers
        public void Init(GalaxyPatternProperties m_DensityWaveProperties, int maxPlanetAmount = 20)
        {
            m_MaxPlanetAmount = maxPlanetAmount;

            //Create density wave
            DensityWave = new GalaxyPattern(m_DensityWaveProperties);

            //Prepare star system
            Light light = Instantiate(m_Light);
            light.enabled = false;
            PlanetOrbits planetOrbits = Instantiate(m_PlanetOrbits);
            planetOrbits.MaxPlanetAmount = MaxPlanetAmount;
            planetOrbits.Init();
            m_PlanetGenerator.Init();

            //Create nebula system
            m_NebulasSystem.DensityWave = DensityWave;
            m_NebulasSystem.Init();

            //Create galaxy system
            Galaxy = new Galaxy(m_MaxPlanetAmount, m_DensityWave, m_PlanetMesh, m_PlanetGenerator, m_StarAmount, planetOrbits);
            Galaxy.Init();

            //Create selection system
            m_SelectionSystem = World.Active.GetOrCreateSystem<SelectionSystem>();
            m_SelectionSystem.CameraControl = m_CameraControl;
            m_SelectionSystem.Light = light;
            m_SelectionSystem.PlanetOrbits = planetOrbits;
            m_SelectionSystem.StarMarker = m_StarMarker;
            m_SelectionSystem.Init();

            //Create renderer
            m_StarRenderSystem = World.Active.GetOrCreateSystem<StarRenderSystem>();
            m_BeaconRenderSystem = World.Active.GetOrCreateSystem<BeaconRenderSystem>();
            m_StarRenderSystem.Light = light;
            m_StarRenderSystem.PlanetOrbits = planetOrbits;
            m_StarRenderSystem.StarAmount = m_StarAmount;
            m_StarRenderSystem.StarMesh = m_StarMesh;
            m_StarRenderSystem.StarMaterial = m_StarMaterial;
            m_StarRenderSystem.StarIndirectMaterial = m_StarIndirectMaterial;
            m_BeaconRenderSystem.BeaconMaterial = m_BeaconMaterial;
            m_BeaconRenderSystem.BeaconMesh = m_BeaconMesh;
            m_StarRenderSystem.Init();
            m_BeaconRenderSystem.Init();
        }
        #endregion

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
        private PlanetTransformSimulationSystem m_PlanetPositionSimulationSystem;
        
        #endregion

        #region Public
        private float m_Time;
        private int m_StarAmount;
        private int m_OrbitsAmount;
        private GalaxyPattern m_DensityWave;
        private StarTransformSimulationSystem m_StarPositionSimulationSystem;
        private StarEngine m_StarEngine;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarTransformSimulationSystem StarPositionSimulationSystem { get => m_StarPositionSimulationSystem; set => m_StarPositionSimulationSystem = value; }
        public float Time { get => m_Time; }
        public StarEngine StarEngine { get => m_StarEngine; set => m_StarEngine = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }

        #endregion

        #region Managers
        public Galaxy(int maxPlanetAmount, GalaxyPattern densityWave, Mesh planetMesh, PlanetGenerator planetGenerator, int starAmount, PlanetOrbits planetOrbits)
        {
            m_StarAmount = starAmount;

            m_DensityWave = densityWave;
            m_StarPositionSimulationSystem = World.Active.GetOrCreateSystem<StarTransformSimulationSystem>();
            m_PlanetPositionSimulationSystem = World.Active.GetOrCreateSystem<PlanetTransformSimulationSystem>();
            
            m_StarEngine = World.Active.GetOrCreateSystem<StarEngine>();

            
            m_PlanetPositionSimulationSystem.PlanetOrbits = planetOrbits;
            m_StarPositionSimulationSystem.DiscreteSimulationTimeStep = 0.02f;
            m_StarPositionSimulationSystem.ContinuousSimulation = true;

            m_StarPositionSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngine.DensityWave = m_DensityWave;
            m_PlanetPositionSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngine.StarAmount = starAmount;
            
            m_StarEngine.MaxPlanetAmount = maxPlanetAmount;
            m_PlanetPositionSimulationSystem.PlanetGenerator = planetGenerator;
            m_StarEngine.PlanetMesh = planetMesh;
        }

        public void Init()
        {
            m_StarEngine.Init();
            m_StarPositionSimulationSystem.Init();
            m_PlanetPositionSimulationSystem.Init();
            
        }
        #endregion

        #region Methods

        public void SetTime(float time)
        {
            m_Time = time;
            m_StarPositionSimulationSystem.SetTime(Time);
        }

        public void AddTime(float time)
        {
            m_Time += time;
            m_StarPositionSimulationSystem.SetTime(Time);
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

        public void SetMaxA(float maxA)
        {
            properties.DiskA = maxA;
            SetAB();
        }

        public void SetMaxB(float maxB)
        {
            properties.DiskB = maxB;
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

        public void SetMinRadius(float radius)
        {
            properties.CenterAB = radius * 2;
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
            properties.CenterA = properties.CenterAB * (1 - properties.CenterEccentricity);
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
