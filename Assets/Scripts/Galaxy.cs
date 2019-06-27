using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
namespace Galaxy
{
    public static class GalaxyEntityArchetypes
    {
        private static EntityArchetype starEntityArchetype = World.Active.EntityManager.CreateArchetype(
            typeof(StarTag),
            typeof(IsDead),
            typeof(StarProperties),
            typeof(OrbitProperties),
            typeof(Translation),
            typeof(Rotation));

        public static EntityArchetype StarEntityArchetype { get => starEntityArchetype;}
    }



    public class DensityWave
    {
        public DensityWaveProperties properties;

        public DensityWaveProperties DensityWaveProperties { get => properties; set => properties = value; }

        #region Properties setters
        public void SetDensityWaveProperties(DensityWaveProperties densityWaveProperties)
        {
            DensityWaveProperties = densityWaveProperties;
            SetCoreACoreB();
        }

        public void SetRotation(float rotation)
        {
            properties.rotation = rotation;
        }

        public void SetCoreProportion(float proportion)
        {
            properties.coreProportion = proportion;
            SetCoreACoreB();
        }

        public void SetCoreEccentricity(float eccentricity)
        {
            properties.coreEccentricity = eccentricity;
            SetCoreACoreB();
        }

        public void SetMaxA(float maxA)
        {
            properties.diskA = maxA;
            SetCoreACoreB();
        }

        public void SetMaxB(float maxB)
        {
            properties.diskB = maxB;
            SetCoreACoreB();
        }

        public void SetCoreSpeed(float speed)
        {
            properties.coreSpeed = speed;
        }

        public void SetCenterSpeed(float speed)
        {
            properties.centerSpeed = speed;
        }

        public void SetDiskSpeed(float speed)
        {
            properties.diskSpeed = speed;
        }

        public void SetMinRadius(float radius)
        {
            properties.minimumRadius = radius;
            SetCoreACoreB();
        }

        public void SetCenterTiltX(float tiltX)
        {
            properties.centerTiltX = tiltX;
        }

        public void SetCenterTiltY(float tiltY)
        {
            properties.centerTiltY = tiltY;
        }

        public void SetCoreTiltX(float tiltX)
        {
            properties.coreTiltX = tiltX;
        }

        public void SetCoreTiltY(float tiltY)
        {
            properties.coreTiltY = tiltY;
        }

        private void SetCoreACoreB()
        {
            float ab = properties.minimumRadius + properties.minimumRadius +
                ((properties.diskA + properties.diskB) - properties.minimumRadius - properties.minimumRadius)
                * properties.coreProportion;
            properties.CoreA = ab * properties.coreEccentricity;
            properties.CoreB = ab * (1 - properties.coreEccentricity);
        }
        #endregion

        public OrbitProperties GetOrbit(float proportion)
        {
            return properties.GetOrbit(proportion);
        }

        public DensityWave(DensityWaveProperties densityWaveProperties)
        {
            SetDensityWaveProperties(densityWaveProperties);
        }
        public float GetHeightOffset(float proportion)
        {
            return properties.GetHeightOffset(proportion);
        }
    }

    [Serializable]
    public struct DensityWaveProperties
    {
        #region public
        public float diskA;
        public float diskB;
        public float diskSpeed;

        public float coreTiltX;
        public float coreTiltY;
        public float coreEccentricity;
        public float coreProportion;
        public float coreSpeed;
        
        public float minimumRadius;
        public float centerTiltX;
        public float centerTiltY;
        public float centerSpeed;

        public float rotation;
        public float3 centerPosition;
        public float CoreA { get => coreA; set => coreA = value; }
        public float CoreB { get => coreB; set => coreB = value; }
        #endregion
        #region Private
        private float coreA;
        private float coreB;
        #endregion
        /// <summary>
        /// Set the ellipse by the proportion.
        /// </summary>
        /// <param name="proportion">
        /// The position of the ellipse in the density waves, range is from 0 to 1
        /// </param>
        /// <param name="orbit">
        /// The ellipse will be reset by the proportion and the density wave properties.
        /// </param>
        public OrbitProperties GetOrbit(float proportion)
        {
            Debug.Assert(proportion >= 0 && proportion <= 1);
            OrbitProperties orbit;
            if (proportion > coreProportion)
            {
                //If the wave is outside the disk;
                float actualProportion = (proportion - coreProportion) / (1 - coreProportion);
                orbit.a = CoreA + (diskA - CoreA) * actualProportion;
                orbit.b = CoreB + (diskB - CoreB) * actualProportion;
                orbit.tiltX = coreTiltX * (1 - actualProportion);
                orbit.tiltY = coreTiltY * (1 - actualProportion);
                orbit.speedMultiplier = coreSpeed + (diskSpeed - coreSpeed) * actualProportion;
            }
            else
            {
                float actualProportion = proportion / coreProportion;
                orbit.a = (CoreA - minimumRadius) * actualProportion + minimumRadius;
                orbit.b = (CoreB - minimumRadius) * actualProportion + minimumRadius;
                orbit.tiltX = centerTiltX - (centerTiltX - coreTiltX) * actualProportion;
                orbit.tiltY = centerTiltY - (centerTiltY - coreTiltY) * actualProportion;
                orbit.speedMultiplier = (coreSpeed - centerSpeed) * actualProportion + centerSpeed;
            }
            orbit.tiltZ = rotation * proportion;
            orbit.centerPosition = centerPosition * (1 - proportion);
            return orbit;
        }

        public float GetHeightOffset(float proportion)
        {
            float offset;
            if (proportion > coreProportion)
            {
                offset = 1 - ((proportion - coreProportion) / (1 - coreProportion));
            }
            else
            {
                offset = proportion / coreProportion;
            }
            return offset * offset * offset;
        }

    }

    [DisableAutoCreation]
    public class StarPositionCalculationSystem : JobComponentSystem
    {
        public DensityWave m_DensityWave;
        public float m_SimulatedTime;
        public bool m_OrbitChanged;
        CalculateStarPositions calculateStarPositionsJob;
        CalculateStarOrbit calculateStarOrbitJob;
        protected override void OnDestroy()
        {
            Shutdown();
        }

        public void Init()
        {
            calculateStarPositionsJob = new CalculateStarPositions { };
            calculateStarOrbitJob = new CalculateStarOrbit {
                densityWaveProperties = m_DensityWave.DensityWaveProperties
            };
            CalculateOrbits();
        }

        public void CalculateOrbits()
        {
            m_OrbitChanged = true;
        }

        public void SetTimeAndCalculate(float simulatedTime)
        {
            m_SimulatedTime = simulatedTime;
            Update();
        }

        public void AddTimeAndCalculate(float time)
        {
            m_SimulatedTime += time;
            Update();
        }

        public void Shutdown()
        {
        }

        [BurstCompile] //200% speed boost
        struct CalculateStarPositions : IJobForEach<StarProperties, Translation, IsDead, OrbitProperties>
        {
            [ReadOnly] public float currentTime;
            public void Execute([ReadOnly] ref StarProperties c0, [WriteOnly] ref Translation c1, [ReadOnly] ref IsDead c2, [ReadOnly] ref OrbitProperties c3)
            {
                if (!c2.value)
                {
                    float calculatedTime = c0.startingTime + currentTime;
                    c1.Value = c3.GetPoint((c0.startingTime + currentTime));
                    c1.Value.z += c0.heightOffset;
                }
            }
        }


        [BurstCompile]
        struct CalculateStarOrbit : IJobForEach<StarProperties, OrbitProperties>
        {
            [ReadOnly] public DensityWaveProperties densityWaveProperties;
            public void Execute([ReadOnly] ref StarProperties c0, [WriteOnly] ref OrbitProperties c1)
            {
                c1 = densityWaveProperties.GetOrbit(c0.proportion);
            }
        }


        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            calculateStarPositionsJob.currentTime = m_SimulatedTime;
            if (m_OrbitChanged)
            {
                m_OrbitChanged = false;
                calculateStarOrbitJob.densityWaveProperties = m_DensityWave.DensityWaveProperties;
                inputDeps = calculateStarOrbitJob.Schedule(this, inputDeps);
                inputDeps.Complete();
            }
            inputDeps = calculateStarPositionsJob.Schedule(this, inputDeps);
            inputDeps.Complete();
            return inputDeps;
        }
    }

    public class Galaxy
    {
        private DensityWave m_DensityWave;
        private int m_OrbitsAmount;
        private StarPositionCalculationSystem m_StarPositionCalculationSystem;
        public DensityWave DensityWave { get => m_DensityWave; set => m_DensityWave = value; }
        public int OrbitsAmount { get => m_OrbitsAmount; set => m_OrbitsAmount = value; }
        public StarPositionCalculationSystem StarPositionCalculationSystem { get => m_StarPositionCalculationSystem; set => m_StarPositionCalculationSystem = value; }

        public Galaxy(DensityWaveProperties densityWaveProperties)
        {
            DensityWave = new DensityWave(densityWaveProperties);
            StarPositionCalculationSystem = World.Active.GetOrCreateSystem<StarPositionCalculationSystem>();
            StarPositionCalculationSystem.m_DensityWave = DensityWave;
            StarPositionCalculationSystem.Init();
        }

        public void SetTime(float time)
        {
            StarPositionCalculationSystem.SetTimeAndCalculate(time);
        }

        public void AddTime(float time)
        {
            StarPositionCalculationSystem.AddTimeAndCalculate(time);
        }
    }
}
