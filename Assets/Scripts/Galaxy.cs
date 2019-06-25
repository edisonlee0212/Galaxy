using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
namespace Galaxy
{
    public class Orbit
    {
        #region Private
        [SerializeField]
        private float m_A;
        [SerializeField]
        private float m_B;
        [SerializeField]
        private float m_Rotation;
        [SerializeField]
        private float m_TiltX;
        [SerializeField]
        private float m_TiltY;
        [SerializeField]
        private float3 m_CenterPosition;
        #endregion
        #region Getter and Setters
        public float Rotation { get => m_Rotation; set => m_Rotation = value; }
        public float A { get => m_A; set => m_A = value; }
        public float B { get => m_B; set => m_B = value; }
        public float TiltX { get => m_TiltX; set => m_TiltX = value; }
        public float TiltY { get => m_TiltY; set => m_TiltY = value; }
        public float3 CenterPosition { get => m_CenterPosition; set => m_CenterPosition = value; }
        #endregion
        #region Constructors
        public Orbit(float A, float B, float rotation, float3 centerPosition, float tiltX = 0, float tiltY = 0)
        {
            m_A = A;
            m_B = B;
            m_Rotation = rotation;
            m_TiltX = tiltX;
            m_TiltY = tiltY;
            m_CenterPosition = centerPosition;
        }

        public Orbit() { }
        #endregion
        public void GetPosition(float angle, out float x, out float y, out float z)
        {
            x = Mathf.Sin(angle) * m_A;
            y = Mathf.Cos(angle) * m_B;
            z = 0;
            float tmp = x;
            x = tmp * Mathf.Cos(m_Rotation) - y * Mathf.Sin(m_Rotation);
            y = tmp * Mathf.Sin(m_Rotation) + y * Mathf.Cos(m_Rotation);
            x += m_CenterPosition.x;
            y += m_CenterPosition.y;
            z += m_CenterPosition.z;
        }

    }

    public class DensityWave
    {
        [SerializeField]
        private DensityWaveProperties m_DensityWaveProperties;

        public DensityWaveProperties DensityWaveProperties { get => m_DensityWaveProperties; set => m_DensityWaveProperties = value; }

        public void SetOrbit(float proportion, ref Orbit orbit)
        {
            DensityWaveProperties.SetOrbit(proportion, ref orbit);
        }

        public DensityWave(DensityWaveProperties densityWaveProperties)
        {
            SetDensityWaveProperties(densityWaveProperties);
        }

        public void SetDensityWaveProperties(DensityWaveProperties densityWaveProperties)
        {
            DensityWaveProperties = densityWaveProperties;
            SetCoreACoreB();
        }

        public void SetRotation(float rotation)
        {
            m_DensityWaveProperties.rotation = rotation;
        }

        public void SetCoreProportion(float proportion)
        {
            m_DensityWaveProperties.coreProportion = proportion;
            SetCoreACoreB();
        }

        public void SetCoreEccentricity(float eccentricity)
        {
            m_DensityWaveProperties.coreEccentricity = eccentricity;
            SetCoreACoreB();
        }

        private void SetCoreACoreB()
        {
            float ab = DensityWaveProperties.minimumRadius + DensityWaveProperties.minimumRadius + ((DensityWaveProperties.maximumA + DensityWaveProperties.maximumB) - DensityWaveProperties.minimumRadius - DensityWaveProperties.minimumRadius) * DensityWaveProperties.coreProportion;
            m_DensityWaveProperties.CoreA = ab * DensityWaveProperties.coreEccentricity;
            m_DensityWaveProperties.CoreB = ab * (1 - DensityWaveProperties.coreEccentricity);
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
        public void SetOrbit(float proportion, ref Orbit orbit)
        {
            Debug.Assert(proportion >= 0 && proportion <= 1 && orbit != null);
            if (proportion > coreProportion)
            {
                //If the wave is outside the disk;
                float actualProportion = (proportion - coreProportion) / (1 - coreProportion);
                orbit.A = CoreA + (maximumA - CoreA) * actualProportion;
                orbit.B = CoreB + (maximumB - CoreB) * actualProportion;

                orbit.TiltX = coreTiltX * (1 - actualProportion);
                orbit.TiltY = coreTiltY * (1 - actualProportion);
            }
            else
            {
                float actualProportion = proportion / coreProportion;
                orbit.A = CoreA * actualProportion + minimumRadius;
                orbit.B = CoreB * actualProportion + minimumRadius;
                orbit.TiltX = centerTiltX - (centerTiltX - coreTiltX) * actualProportion;
                orbit.TiltY = centerTiltY - (centerTiltY - coreTiltY) * actualProportion;
            }
            orbit.Rotation = rotation * proportion;
            orbit.CenterPosition = centerPosition * (1 - proportion);
        }
    }

    [DisableAutoCreation]
    public class Galaxy : JobComponentSystem
    {
        private int m_StarAmount;
        private int m_OrbitAmount;
        private Orbit m_MinOrbit, m_MaxOrbit;

        protected override void OnCreate()
        {
            base.OnCreate();

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            throw new System.NotImplementedException();
        }
    }
}
