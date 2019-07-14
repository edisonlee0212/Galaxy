using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
namespace Galaxy
{
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

        public void SetCenterTiltY(float tiltY)
        {
            properties.CenterTiltY = tiltY;
        }

        public void SetCoreTiltX(float tiltX)
        {
            properties.CoreTiltX = tiltX;
        }

        public void SetCoreTiltY(float tiltY)
        {
            properties.CoreTiltY = tiltY;
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

