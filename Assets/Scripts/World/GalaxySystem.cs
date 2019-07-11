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


        private DensityWave m_DensityWave;
        private Galaxy m_Galaxy;
        private StarSystem[] m_StarSystems;
        private List<StarSystem> m_ActivitedStarSystems;

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public Galaxy Galaxy { get => m_Galaxy; set => m_Galaxy = value; }
        public StarSystem[] StarSystems { get => m_StarSystems; set => m_StarSystems = value; }
        
        Scene m_StarSystemScene;

        public void Init(DensityWaveProperties m_DensityWaveProperties)
        {
            
            //Create density wave
            DensityWave = new DensityWave(m_DensityWaveProperties);

            //Create galaxy system
            Galaxy = new Galaxy(DensityWave, m_StarMesh, m_StarMaterial, m_PlanetMesh, m_PlanetMaterial, m_StarAmount);
            Galaxy.Init();

            //Create nebula system
            m_NebulasSystem.DensityWave = DensityWave;
            m_NebulasSystem.Init();

        }

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
    }
    public class Galaxy
    {
        private DensityWave m_DensityWave;
        private int m_StarAmount;
        private int m_OrbitsAmount;
        private Mesh m_StarMesh;
        private Material m_StarMaterial;
        private StarPositionSimulationSystem m_StarPositionCalculationSystem;
        private StarEngine m_StarEngineSystem;
        private StarSelectionSystem m_StarSelectionSystem;
        private PlanetPositionSimulationSystem m_PlanetPositionSimulationSystem;
        private StarRenderSystem m_StarRenderSystem;
        private PlanetRendererSystem m_PlanetRendererSystem;
        private float m_Time;

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarPositionSimulationSystem StarPositionCalculationSystem { get => m_StarPositionCalculationSystem; set => m_StarPositionCalculationSystem = value; }
        public StarSelectionSystem StarSelectionSystem { get => m_StarSelectionSystem; set => m_StarSelectionSystem = value; }
        public float Time { get => m_Time; }
        public StarEngine StarEngineSystem { get => m_StarEngineSystem; set => m_StarEngineSystem = value; }
        public int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public Material Material { get => m_StarMaterial; set => m_StarMaterial = value; }
        public Mesh StarMesh { get => m_StarMesh; set => m_StarMesh = value; }

        public Galaxy(DensityWave densityWave, Mesh starMesh, Material starMaterial, Mesh planetMesh, Material planetMaterial, int starAmount)
        {
            m_StarAmount = starAmount;
            m_StarMaterial = starMaterial;
            m_StarMesh = starMesh;

            m_DensityWave = densityWave;
            m_StarPositionCalculationSystem = World.Active.GetOrCreateSystem<StarPositionSimulationSystem>();
            m_PlanetPositionSimulationSystem = World.Active.GetOrCreateSystem<PlanetPositionSimulationSystem>();
            m_StarSelectionSystem = World.Active.GetOrCreateSystem<StarSelectionSystem>();
            m_StarEngineSystem = World.Active.GetOrCreateSystem<StarEngine>();
            m_StarRenderSystem = World.Active.GetOrCreateSystem<StarRenderSystem>();
            m_PlanetRendererSystem = World.Active.GetOrCreateSystem<PlanetRendererSystem>();

            m_StarPositionCalculationSystem.DensityWave = m_DensityWave;
            m_StarEngineSystem.DensityWave = m_DensityWave;
            m_PlanetPositionSimulationSystem.DensityWave = m_DensityWave;
            m_StarEngineSystem.StarAmount = starAmount;
            m_StarEngineSystem.MaxPlanetAmount = 20;

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
    }
}
