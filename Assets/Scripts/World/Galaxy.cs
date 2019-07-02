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
    public class Galaxy
    {
        private DensityWave m_DensityWave;
        private int m_OrbitsAmount;
        private StarPositionCalculationSystem m_StarPositionCalculationSystem;
        private StarSpawnerSystem m_StarSpawnerSystem;


        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarPositionCalculationSystem StarPositionCalculationSystem { get => m_StarPositionCalculationSystem; set => m_StarPositionCalculationSystem = value; }
        public StarSpawnerSystem StarSpawnerSystem { get => m_StarSpawnerSystem; set => m_StarSpawnerSystem = value; }

        
        public Galaxy(DensityWaveProperties densityWaveProperties)
        {
            m_DensityWave = new DensityWave(densityWaveProperties);
            m_StarPositionCalculationSystem = World.Active.GetOrCreateSystem<StarPositionCalculationSystem>();
            m_StarSpawnerSystem = World.Active.GetOrCreateSystem<StarSpawnerSystem>();

            m_StarPositionCalculationSystem.DensityWave = m_DensityWave;
            m_StarSpawnerSystem.DensityWave = m_DensityWave;

            m_StarSpawnerSystem.Init();
            m_StarPositionCalculationSystem.Init();
        }

        public void SetTime(float time)
        {
            m_StarPositionCalculationSystem.SetTimeAndCalculate(time);
        }

        public void AddTime(float time)
        {
            m_StarPositionCalculationSystem.AddTimeAndCalculate(time);
        }
    }
}
