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
        private int m_StarAmount;
        [SerializeField]
        private Light m_Light;
        [SerializeField]
        private PlanetOrbits m_PlanetOrbits;
        #endregion

        #region Public
        private CameraControl m_CameraControl;
        private GalaxyPattern m_DensityWave;
        private Galaxy m_Galaxy;
        private int m_MaxPlanetAmount;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public Galaxy Galaxy { get => m_Galaxy; set => m_Galaxy = value; }
        public CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        #endregion

        #region Managers
        public void Init(GalaxyPatternProperties m_DensityWaveProperties, int maxPlanetAmount = 20)
        {
            m_MaxPlanetAmount = maxPlanetAmount;

            //Create density wave
            DensityWave = new GalaxyPattern(m_DensityWaveProperties);

            //Prepare star system
            Light light = Instantiate(m_Light);
            PlanetOrbits planetOrbits = Instantiate(m_PlanetOrbits);
            planetOrbits.MaxPlanetAmount = MaxPlanetAmount;
            planetOrbits.Init();
            m_PlanetGenerator.Init();

            //Create nebula system
            m_NebulasSystem.DensityWave = DensityWave;
            m_NebulasSystem.Init();

            //Create galaxy system
            Galaxy = new Galaxy(m_MaxPlanetAmount, m_DensityWave, m_StarMesh, m_PlanetMesh, m_StarMaterial, m_PlanetGenerator, m_StarAmount, m_CameraControl, light, planetOrbits);
            Galaxy.Init();
        }
        #endregion

        #region Methods
        public void FocusOnStar(Entity entity)
        {
            m_Galaxy.SetStarSystem(entity);
        }

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
        private StarRenderSystem m_StarRenderSystem;
        #endregion

        #region Public
        private float m_Time;
        private GalaxyPattern m_DensityWave;
        private int m_StarAmount;
        private int m_OrbitsAmount;
        private Mesh m_StarMesh;
        private Material m_StarMaterial;
        private StarTransformSimulationSystem m_StarPositionSimulationSystem;
        private StarEngine m_StarEngine;
        private SelectionSystem m_SelectionSystem;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarTransformSimulationSystem StarPositionSimulationSystem { get => m_StarPositionSimulationSystem; set => m_StarPositionSimulationSystem = value; }
        public SelectionSystem SelectionSystem { get => m_SelectionSystem; set => m_SelectionSystem = value; }
        public float Time { get => m_Time; }
        public StarEngine StarEngine { get => m_StarEngine; set => m_StarEngine = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public Material Material { get => m_StarMaterial; set => m_StarMaterial = value; }
        public Mesh StarMesh { get => m_StarMesh; set => m_StarMesh = value; }
        #endregion

        #region Managers
        public Galaxy(int maxPlanetAmount, GalaxyPattern densityWave, Mesh starMesh, Mesh planetMesh, Material starMaterial, PlanetGenerator planetGenerator, int starAmount, CameraControl cameraControl, Light light, PlanetOrbits planetOrbits)
        {
            m_StarAmount = starAmount;
            m_StarMaterial = starMaterial;
            m_StarMesh = starMesh;

            m_DensityWave = densityWave;
            m_StarPositionSimulationSystem = World.Active.GetOrCreateSystem<StarTransformSimulationSystem>();
            m_PlanetPositionSimulationSystem = World.Active.GetOrCreateSystem<PlanetTransformSimulationSystem>();
            m_SelectionSystem = World.Active.GetOrCreateSystem<SelectionSystem>();
            m_StarEngine = World.Active.GetOrCreateSystem<StarEngine>();
            m_StarRenderSystem = World.Active.GetOrCreateSystem<StarRenderSystem>();


            m_SelectionSystem.CameraControl = cameraControl;
            m_SelectionSystem.Light = light;
            m_StarRenderSystem.Light = light;
            m_SelectionSystem.PlanetOrbits = planetOrbits;
            m_PlanetPositionSimulationSystem.PlanetOrbits = planetOrbits;
            m_StarRenderSystem.PlanetOrbits = planetOrbits;
            m_StarPositionSimulationSystem.DiscreteSimulationTimeStep = 0.02f;
            m_StarPositionSimulationSystem.ContinuousSimulation = true;

            m_StarPositionSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngine.DensityWave = m_DensityWave;
            m_PlanetPositionSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngine.StarAmount = starAmount;
            m_StarRenderSystem.StarAmount = starAmount;
            m_StarEngine.MaxPlanetAmount = maxPlanetAmount;

            m_StarRenderSystem.StarMesh = starMesh;
            m_StarRenderSystem.StarMaterial = starMaterial;
            
            m_PlanetPositionSimulationSystem.PlanetGenerator = planetGenerator;
            m_StarEngine.PlanetMesh = planetMesh;
        }

        public void Init()
        {
            m_StarEngine.Init();
            m_StarPositionSimulationSystem.Init();
            m_PlanetPositionSimulationSystem.Init();
            m_SelectionSystem.Init();
            m_StarRenderSystem.Init();

        }
        #endregion

        #region Methods
        public void SetStarSystem(Entity entity)
        {
            m_PlanetPositionSimulationSystem.ResetEntity(entity);
        }

        public void SetTime(float time)
        {
            m_Time = time;
            m_StarPositionSimulationSystem.SetTime(Time);
            m_PlanetPositionSimulationSystem.SetTime(Time);
        }

        public void AddTime(float time)
        {
            m_Time += time;
            m_StarPositionSimulationSystem.SetTime(Time);
            m_PlanetPositionSimulationSystem.SetTime(Time);
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
            SetCoreACoreB();
        }

        public void SetRotation(float rotation)
        {
            properties.Rotation = rotation;
        }

        public void SetCoreProportion(float proportion)
        {
            properties.CoreProportion = proportion;
            SetCoreACoreB();
        }

        public void SetCoreEccentricity(float eccentricity)
        {
            properties.CoreEccentricity = eccentricity;
            SetCoreACoreB();
        }

        public void SetMaxA(float maxA)
        {
            properties.DiskA = maxA;
            SetCoreACoreB();
        }

        public void SetMaxB(float maxB)
        {
            properties.DiskB = maxB;
            SetCoreACoreB();
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
            properties.MinimumRadius = radius;
            SetCoreACoreB();
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

        private void SetCoreACoreB()
        {
            float ab = properties.MinimumRadius + properties.MinimumRadius +
                ((properties.DiskA + properties.DiskB) - properties.MinimumRadius - properties.MinimumRadius)
                * properties.CoreProportion;
            properties.CoreA = ab * properties.CoreEccentricity;
            properties.CoreB = ab * (1 - properties.CoreEccentricity);
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
