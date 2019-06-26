using System;
using System.Collections;
using System.Collections.Generic;
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
            typeof(Translation),
            typeof(Rotation));

        public static EntityArchetype StarEntityArchetype { get => starEntityArchetype;}
    }

    public struct Orbit
    {
        #region Public
        public float a;
        public float b;
        public float rotation;
        public float tiltX;
        public float tiltY;
        public float3 centerPosition;
        #endregion



        public void SetPoint(float angle, ref Vector3 point)
        {
            point.x = Mathf.Sin(angle) * a;
            point.y = Mathf.Cos(angle) * b;
            point.z = 0;
            point = Quaternion.AngleAxis(angle, Vector3.forward) * point;
            point.x += centerPosition.x;
            point.y += centerPosition.y;
            point.z += centerPosition.z;
            
        }
        public Vector3 GetPoint(float angle)
        {
            Vector3 point = new Vector3();
            point.x = Mathf.Sin(angle) * a;
            point.y = Mathf.Cos(angle) * b;
            point.z = 0;
            point = Quaternion.AngleAxis(rotation, Vector3.forward) * point;
            point = Quaternion.AngleAxis(tiltX, Vector3.up) * point;
            point = Quaternion.AngleAxis(tiltY, Vector3.right) * point;
            point.x += centerPosition.x;
            point.y += centerPosition.y;
            point.z += centerPosition.z;
            return point;
        }
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
            properties.maximumA = maxA;
            SetCoreACoreB();
        }

        public void SetMaxB(float maxB)
        {
            properties.maximumB = maxB;
            SetCoreACoreB();
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
                ((properties.maximumA + properties.maximumB) - properties.minimumRadius - properties.minimumRadius)
                * properties.coreProportion;
            properties.CoreA = ab * properties.coreEccentricity;
            properties.CoreB = ab * (1 - properties.coreEccentricity);
        }
        #endregion

        public Orbit GetOrbit(float proportion)
        {
            return properties.GetOrbit(proportion);
        }

        public DensityWave(DensityWaveProperties densityWaveProperties)
        {
            SetDensityWaveProperties(densityWaveProperties);
        }
        
    }

    [Serializable]
    public struct DensityWaveProperties
    {
        #region public
        public float minimumRadius;
        public float maximumA;
        public float maximumB;
        public float coreProportion;
        public float coreEccentricity;
        public float rotation;
        public float centerTiltX;
        public float centerTiltY;
        public float coreTiltX;
        public float coreTiltY;
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
        public Orbit GetOrbit(float proportion)
        {
            Debug.Assert(proportion >= 0 && proportion <= 1);
            Orbit orbit;
            if (proportion > coreProportion)
            {
                //If the wave is outside the disk;
                float actualProportion = (proportion - coreProportion) / (1 - coreProportion);
                orbit.a = CoreA + (maximumA - CoreA) * actualProportion;
                orbit.b = CoreB + (maximumB - CoreB) * actualProportion;

                orbit.tiltX = coreTiltX * (1 - actualProportion);
                orbit.tiltY = coreTiltY * (1 - actualProportion);
            }
            else
            {
                float actualProportion = proportion / coreProportion;
                orbit.a = (CoreA - minimumRadius) * actualProportion + minimumRadius;
                orbit.b = (CoreB - minimumRadius) * actualProportion + minimumRadius;
                orbit.tiltX = centerTiltX - (centerTiltX - coreTiltX) * actualProportion;
                orbit.tiltY = centerTiltY - (centerTiltY - coreTiltY) * actualProportion;
            }
            orbit.rotation = rotation * proportion;
            orbit.centerPosition = centerPosition * (1 - proportion);
            return orbit;
        }
    }

    [DisableAutoCreation]
    public class StarPositionCalculationSystem : JobComponentSystem
    {
        public NativeArray<Orbit> m_Orbits;
        public DensityWave m_DensityWave;
        public int m_OrbitsAmount;
        public float m_SimulatedTime;

        protected override void OnDestroy()
        {
            Shutdown();
        }

        public void Init()
        {
            m_Orbits = new NativeArray<Orbit>(m_OrbitsAmount, Allocator.Persistent);
            CalculateOrbits();
        }

        public NativeArray<Orbit> GetOrbitsArray()
        {
            if (m_Orbits.IsCreated) return m_Orbits;
            return default;
        }

        public void CalculateOrbits()
        {
            for (int i = 0; i < m_OrbitsAmount; i++)
            {
                m_Orbits[i] = m_DensityWave.GetOrbit((float)i / (m_OrbitsAmount - 1));
            }
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
            if (m_Orbits.IsCreated)
            {
                m_Orbits.Dispose();
            }
        }


        struct CalculateStarPositions : IJobForEach<StarProperties, Translation, IsDead>
        {
            public float currentTime;
            [ReadOnly] public NativeArray<Orbit> orbits;

            public void Execute(ref StarProperties c0, ref Translation c1, ref IsDead c2)
            {
                if (!c2.value)
                {
                    float calculatedTime = c0.startingTime + currentTime;
                    c1.Value = orbits[c0.orbitIndex].GetPoint(c0.startingTime + currentTime);
                }
            }
        }


        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {

            var calculateStarPositionsJob = new CalculateStarPositions
            {
                currentTime = m_SimulatedTime,
                orbits = m_Orbits
            };
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

        public Galaxy(int orbitAmount, DensityWaveProperties densityWaveProperties)
        {
            DensityWave = new DensityWave(densityWaveProperties);
            OrbitsAmount = orbitAmount;
            StarPositionCalculationSystem = World.Active.GetOrCreateSystem<StarPositionCalculationSystem>();
            StarPositionCalculationSystem.m_OrbitsAmount = OrbitsAmount;
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
