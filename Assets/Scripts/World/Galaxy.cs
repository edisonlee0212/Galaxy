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
namespace Galaxy
{
    public class GalaxySystem
    {
        private Nebulas m_NebulasSystem;
        private DensityWave m_DensityWave;
        private int m_OrbitsAmount;
        private StarPositionCalculationSystem m_StarPositionCalculationSystem;
        private StarSpawnerSystem m_StarSpawnerSystem;
        private CameraRayCastSystem m_CameraRayCastSystem;
        private float m_Time;

        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarPositionCalculationSystem StarPositionCalculationSystem { get => m_StarPositionCalculationSystem; set => m_StarPositionCalculationSystem = value; }
        public StarSpawnerSystem StarSpawnerSystem { get => m_StarSpawnerSystem; set => m_StarSpawnerSystem = value; }
        public Nebulas NebulasSystem { get => m_NebulasSystem; set => m_NebulasSystem = value; }
        public CameraRayCastSystem CameraRayCastSystem { get => m_CameraRayCastSystem; set => m_CameraRayCastSystem = value; }

        public GalaxySystem(DensityWaveProperties densityWaveProperties)
        {
            m_DensityWave = new DensityWave(densityWaveProperties);
            m_StarPositionCalculationSystem = World.Active.GetOrCreateSystem<StarPositionCalculationSystem>();
            m_StarSpawnerSystem = World.Active.GetOrCreateSystem<StarSpawnerSystem>();
            m_CameraRayCastSystem = World.Active.GetOrCreateSystem<CameraRayCastSystem>();

            m_StarPositionCalculationSystem.DensityWave = m_DensityWave;
            m_StarSpawnerSystem.DensityWave = m_DensityWave;
            

            m_StarSpawnerSystem.Init();
            m_StarPositionCalculationSystem.Init();

        }

        public void Init()
        {
            if (m_NebulasSystem != null)
            {
                m_NebulasSystem.DensityWave = m_DensityWave;
                m_NebulasSystem.Init();
                //m_NebulasSystem.AddCenterCloud(150, 1000);
            }
        }

        public void CameraRayCast()
        {
            m_CameraRayCastSystem.Update();
        }

        public void SetTime(float time)
        {
            m_Time = time;
            m_StarPositionCalculationSystem.SetTimeAndCalculate(m_Time);
            NebulasSystem.SetTimeAndCalculate(m_Time);
        }

        public void AddTime(float time)
        {
            m_Time += time;
            m_StarPositionCalculationSystem.SetTimeAndCalculate(m_Time);
            NebulasSystem.SetTimeAndCalculate(m_Time);
            
        }
    }
}
