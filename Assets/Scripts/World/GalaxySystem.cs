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
        private StarSystem m_StarSystemPrefab;
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
        private Material m_PlanetMaterial;
        [SerializeField]
        private int m_StarAmount;
        [SerializeField]
        private Light m_Light;
        [SerializeField]
        private PlanetOrbits m_PlanetOrbits;
        #endregion

        #region Public
        private CameraControl m_CameraControl;
        private DensityWave m_DensityWave;
        private Galaxy m_Galaxy;
        private int m_MaxPlanetAmount;
        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public Galaxy Galaxy { get => m_Galaxy; set => m_Galaxy = value; }
        public CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        #endregion

        #region Managers
        public void Init(DensityWaveProperties m_DensityWaveProperties, int maxPlanetAmount = 20)
        {
            m_MaxPlanetAmount = maxPlanetAmount;
            //Create density wave
            DensityWave = new DensityWave(m_DensityWaveProperties);
            Light light = Instantiate(m_Light);
            PlanetOrbits planetOrbits = Instantiate(m_PlanetOrbits);
            planetOrbits.MaxPlanetAmount = MaxPlanetAmount;
            planetOrbits.Init();
            //Create galaxy system
            Galaxy = new Galaxy(m_MaxPlanetAmount, m_DensityWave, m_StarMesh, m_StarMaterial, m_PlanetMesh, m_PlanetMaterial, m_StarAmount, m_CameraControl, light, planetOrbits);
            Galaxy.Init();

            //Create nebula system
            m_NebulasSystem.DensityWave = DensityWave;
            m_NebulasSystem.Init();

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
        private PlanetRendererSystem m_PlanetRendererSystem;
        #endregion

        #region Public
        private float m_Time;
        private DensityWave m_DensityWave;
        private int m_StarAmount;
        private int m_OrbitsAmount;
        private Mesh m_StarMesh;
        private Material m_StarMaterial;
        private StarPositionSimulationSystem m_StarPositionCalculationSystem;
        private StarEngine m_StarEngineSystem;
        private SelectionSystem m_StarSelectionSystem;
        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarPositionSimulationSystem StarPositionCalculationSystem { get => m_StarPositionCalculationSystem; set => m_StarPositionCalculationSystem = value; }
        public SelectionSystem StarSelectionSystem { get => m_StarSelectionSystem; set => m_StarSelectionSystem = value; }
        public float Time { get => m_Time; }
        public StarEngine StarEngineSystem { get => m_StarEngineSystem; set => m_StarEngineSystem = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public Material Material { get => m_StarMaterial; set => m_StarMaterial = value; }
        public Mesh StarMesh { get => m_StarMesh; set => m_StarMesh = value; }
        #endregion

        #region Managers
        public Galaxy(int maxPlanetAmount, DensityWave densityWave, Mesh starMesh, Material starMaterial, Mesh planetMesh, Material planetMaterial, int starAmount, CameraControl cameraControl, Light light, PlanetOrbits planetOrbits)
        {
            m_StarAmount = starAmount;
            m_StarMaterial = starMaterial;
            m_StarMesh = starMesh;

            m_DensityWave = densityWave;
            m_StarPositionCalculationSystem = World.Active.GetOrCreateSystem<StarPositionSimulationSystem>();
            m_PlanetPositionSimulationSystem = World.Active.GetOrCreateSystem<PlanetPositionSimulationSystem>();
            m_StarSelectionSystem = World.Active.GetOrCreateSystem<SelectionSystem>();
            m_StarEngineSystem = World.Active.GetOrCreateSystem<StarEngine>();
            m_StarRenderSystem = World.Active.GetOrCreateSystem<StarRenderSystem>();
            m_PlanetRendererSystem = World.Active.GetOrCreateSystem<PlanetRendererSystem>();

            m_StarSelectionSystem.CameraControl = cameraControl;
            m_StarSelectionSystem.Light = light;
            m_StarSelectionSystem.PlanetOrbits = planetOrbits;

            m_StarPositionCalculationSystem.DensityWave = m_DensityWave;
            m_StarEngineSystem.DensityWave = m_DensityWave;
            m_PlanetPositionSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngineSystem.StarAmount = starAmount;
            m_StarEngineSystem.MaxPlanetAmount = maxPlanetAmount;

            m_StarRenderSystem.StarMesh = starMesh;
            m_StarRenderSystem.StarMaterial = starMaterial;
            m_PlanetRendererSystem.PlanetMesh = planetMesh;
            m_PlanetRendererSystem.PlanetMaterial = planetMaterial;
        }

        public void Init()
        {
            m_StarEngineSystem.Init();
            m_StarPositionCalculationSystem.Init();
            m_PlanetPositionSimulationSystem.Init();
            m_StarSelectionSystem.Init();
            m_StarRenderSystem.Init();
            m_PlanetRendererSystem.Init();
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
            m_StarPositionCalculationSystem.SetTime(Time);
            m_PlanetPositionSimulationSystem.SetTime(Time);
        }

        public void AddTime(float time)
        {
            m_Time += time;
            m_StarPositionCalculationSystem.SetTime(Time);
            m_PlanetPositionSimulationSystem.SetTime(Time);
        }
        #endregion
    }
}
