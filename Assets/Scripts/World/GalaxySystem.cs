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
            Galaxy = new Galaxy(DensityWave);
            Galaxy.Init();

            //Create nebula system
            m_NebulasSystem.DensityWave = DensityWave;
            m_NebulasSystem.Init();

            //Initialize star systems
            int count = m_Galaxy.StarSpawnerSystem.InsatancedEntities.Count;
            m_StarSystems = new StarSystem[count];
            m_ActivitedStarSystems = new List<StarSystem>();
            //m_StarSystemScene = SceneManager.CreateScene("StarSystems");
            /*GameObject holder = Instantiate(m_StarSystemsHolder, Vector3.zero, Quaternion.identity);
            for (int i = 0; i < count; i++)
            {
                m_StarSystems[i] = Instantiate(m_StarSystemPrefab);
                m_StarSystems[i].FollowedStar = m_Galaxy.StarSpawnerSystem.InsatancedEntities.Dequeue();
                m_StarSystems[i].Init();
                //SceneManager.MoveGameObjectToScene(m_StarSystems[i].gameObject, m_StarSystemScene);
                m_StarSystems[i].transform.SetParent(holder.transform);
                m_StarSystems[i].gameObject.SetActive(false);
            }*/
        }

        public void Update()
        {
            m_Galaxy.Update();
            /*for(int i = 0; i < m_ActivitedStarSystems.Count; i++)
            {
                m_ActivitedStarSystems[i].gameObject.SetActive(false);
            }
            m_ActivitedStarSystems.Clear();
            int count = m_Galaxy.StarSelectionSystem.SelectedResultEntitiesIndexList.Count;
            for(int i = 0; i < count; i++)
            {
                int index = m_Galaxy.StarSelectionSystem.SelectedResultEntitiesIndexList.Dequeue();
                m_StarSystems[index].gameObject.SetActive(true);
                m_ActivitedStarSystems.Add(m_StarSystems[index]);
            }*/
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
        private int m_OrbitsAmount;
        private StarPositionCalculationSystem m_StarPositionCalculationSystem;
        private StarSpawnerSystem m_StarSpawnerSystem;
        private StarSelectionSystem m_StarSelectionSystem;
        
        private float m_Time;

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarPositionCalculationSystem StarPositionCalculationSystem { get => m_StarPositionCalculationSystem; set => m_StarPositionCalculationSystem = value; }
        public StarSpawnerSystem StarSpawnerSystem { get => m_StarSpawnerSystem; set => m_StarSpawnerSystem = value; }
        public StarSelectionSystem StarSelectionSystem { get => m_StarSelectionSystem; set => m_StarSelectionSystem = value; }
        public float Time { get => m_Time; }

        public Galaxy(DensityWave densityWave)
        {
            m_DensityWave = densityWave;
            m_StarPositionCalculationSystem = World.Active.GetOrCreateSystem<StarPositionCalculationSystem>();
            m_StarSpawnerSystem = World.Active.GetOrCreateSystem<StarSpawnerSystem>();
            m_StarSelectionSystem = World.Active.GetOrCreateSystem<StarSelectionSystem>();

            m_StarPositionCalculationSystem.DensityWave = m_DensityWave;
            m_StarSpawnerSystem.DensityWave = m_DensityWave;

            m_StarSpawnerSystem.Init();
            m_StarPositionCalculationSystem.Init();
        }

        public void Init()
        {            
        }

        public void Update()
        {
            m_StarSelectionSystem.Update();
        }

        public void SetTime(float time)
        {
            m_Time = time;
            m_StarPositionCalculationSystem.SetTimeAndCalculate(Time);
        }

        public void AddTime(float time)
        {
            m_Time += time;
            m_StarPositionCalculationSystem.SetTimeAndCalculate(Time);            
        }
    }
}
