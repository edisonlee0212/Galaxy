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
        private GameObject m_StarSystemsHolder;
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
        [SerializeField]
        private Planet m_HPlanet;
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
            Galaxy = new Galaxy(m_MaxPlanetAmount, m_DensityWave, m_StarMesh, m_StarMaterial, m_PlanetGenerator, m_StarAmount, m_CameraControl, light, planetOrbits);
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
        private PlanetPositionSimulationSystem m_PlanetPositionSimulationSystem;
        private StarRenderSystem m_StarRenderSystem;
        #endregion

        #region Public
        private float m_Time;
        private GalaxyPattern m_DensityWave;
        private int m_StarAmount;
        private int m_OrbitsAmount;
        private Mesh m_StarMesh;
        private Material m_StarMaterial;
        private StarPositionSimulationSystem m_StarPositionSimulationSystem;
        private StarEngine m_StarEngine;
        private SelectionSystem m_SelectionSystem;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarPositionSimulationSystem StarPositionSimulationSystem { get => m_StarPositionSimulationSystem; set => m_StarPositionSimulationSystem = value; }
        public SelectionSystem SelectionSystem { get => m_SelectionSystem; set => m_SelectionSystem = value; }
        public float Time { get => m_Time; }
        public StarEngine StarEngine { get => m_StarEngine; set => m_StarEngine = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public Material Material { get => m_StarMaterial; set => m_StarMaterial = value; }
        public Mesh StarMesh { get => m_StarMesh; set => m_StarMesh = value; }
        #endregion

        #region Managers
        public Galaxy(int maxPlanetAmount, GalaxyPattern densityWave, Mesh sphereMesh, Material starMaterial, PlanetGenerator planetGenerator, int starAmount, CameraControl cameraControl, Light light, PlanetOrbits planetOrbits)
        {
            m_StarAmount = starAmount;
            m_StarMaterial = starMaterial;
            m_StarMesh = sphereMesh;

            m_DensityWave = densityWave;
            m_StarPositionSimulationSystem = World.Active.GetOrCreateSystem<StarPositionSimulationSystem>();
            m_PlanetPositionSimulationSystem = World.Active.GetOrCreateSystem<PlanetPositionSimulationSystem>();
            m_SelectionSystem = World.Active.GetOrCreateSystem<SelectionSystem>();
            m_StarEngine = World.Active.GetOrCreateSystem<StarEngine>();
            m_StarRenderSystem = World.Active.GetOrCreateSystem<StarRenderSystem>();


            m_SelectionSystem.CameraControl = cameraControl;
            m_SelectionSystem.Light = light;
            m_StarRenderSystem.Light = light;
            m_SelectionSystem.PlanetOrbits = planetOrbits;
            m_PlanetPositionSimulationSystem.PlanetOrbits = planetOrbits;
            m_StarRenderSystem.PlanetOrbits = planetOrbits;
            m_SelectionSystem.MaxRayCastDistance = 28000;

            m_StarPositionSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngine.DensityWave = m_DensityWave;
            m_PlanetPositionSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngine.StarAmount = starAmount;
            m_StarEngine.MaxPlanetAmount = maxPlanetAmount;

            m_StarRenderSystem.StarMesh = sphereMesh;
            m_StarRenderSystem.StarMaterial = starMaterial;
            
            m_PlanetPositionSimulationSystem.PlanetGenerator = planetGenerator;

            m_StarEngine.PlanetMesh = sphereMesh;
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
}
