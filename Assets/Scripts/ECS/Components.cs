using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace Galaxy
{
    [Serializable]
    public struct CustomRenderMesh : ISharedComponentData, IEquatable<CustomRenderMesh>
    {
        public Mesh Mesh;
        public Material Material;

        public bool Equals(CustomRenderMesh other)
        {
            if (Mesh == other.Mesh && Material == other.Material) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [Serializable]
    public struct SpawnerProperties : IComponentData
    {
        public Entity Prefab;
        public int Count;
    }

    [Serializable]
    public struct StarProperties : IComponentData
    {
        /// <summary>
        /// The start time of the star, use this to calculate initial position.
        /// </summary>
        public float StartingTime;
        /// <summary>
        /// This keep track of the position of the star in the list.
        /// </summary>
        public int Index;
        /// <summary>
        /// This will help calculate the orbit. Smaller = close to center, bigger = close to disk
        /// </summary>
        public float Proportion;
        /// <summary>
        /// Mass of the star, use this as a factor of angle speed.
        /// </summary>
        public float Mass;
        /// <summary>
        /// The deviation of height of its orbit
        /// </summary>
        public float HeightOffset;
        /// <summary>
        /// Color of the surface of the star
        /// </summary>
        public Color Color;
    }

    [Serializable]
    public struct CustomCullingStat : IComponentData
    {
        public bool Culled;
    }

    [Serializable]
    public struct DrawTag : IComponentData
    {

    }

    [Serializable]
    public struct CustomColor : IComponentData
    {
        public Vector4 Color;
    }

    [Serializable]
    public struct StarSystemProperties : IComponentData
    {
        public float Seed;
        public int PlanetAmount;
    }

    [Serializable]
    public struct OrbitProperties : IComponentData
    {
        #region Public
        public float a;
        public float b;
        public float tiltZ;
        public float tiltX;
        public float tiltY;
        public float speedMultiplier;
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
        public Vector3 GetPoint(float time, bool star = true)
        {
            float angle = star ? time / Mathf.Sqrt(a + b) * speedMultiplier : time;

            Vector3 point = new Vector3();
            point.x = Mathf.Sin(angle) * a;
            point.y = Mathf.Cos(angle) * b;
            point.z = 0;
            point = Quaternion.AngleAxis(tiltZ, Vector3.forward) * point;
            point = Quaternion.AngleAxis(tiltX, Vector3.up) * point;
            point = Quaternion.AngleAxis(tiltY, Vector3.right) * point;
            point.x += centerPosition.x;
            point.y += centerPosition.y;
            point.z += centerPosition.z;
            return point;
        }
    }

    [Serializable]
    public struct PlanetProperties : IComponentData
    {
        public float StartTime;
    }

    [Serializable]
    public struct DensityWaveProperties
    {
        #region public
        public float DiskA;
        public float DiskB;
        public float DiskSpeed;
        public Color DiskColor;

        public float CoreTiltX;
        public float CoreTiltY;
        public float CoreEccentricity;
        public float CoreProportion;
        public float CoreSpeed;
        public Color CoreColor;

        public float MinimumRadius;
        public float CenterTiltX;
        public float CenterTiltY;
        public float CenterSpeed;
        public Color CenterColor;

        public float Rotation;
        public float3 CenterPosition;
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
            OrbitProperties orbit;
            if (proportion > CoreProportion)
            {
                //If the wave is outside the disk;
                float actualProportion = (proportion - CoreProportion) / (1 - CoreProportion);
                orbit.a = CoreA + (DiskA - CoreA) * actualProportion;
                orbit.b = CoreB + (DiskB - CoreB) * actualProportion;
                orbit.tiltX = CoreTiltX * (1 - actualProportion);
                orbit.tiltY = CoreTiltY * (1 - actualProportion);
                orbit.speedMultiplier = CoreSpeed + (DiskSpeed - CoreSpeed) * actualProportion;
            }
            else
            {
                float actualProportion = proportion / CoreProportion;
                orbit.a = (CoreA - MinimumRadius) * actualProportion + MinimumRadius;
                orbit.b = (CoreB - MinimumRadius) * actualProportion + MinimumRadius;
                orbit.tiltX = CenterTiltX - (CenterTiltX - CoreTiltX) * actualProportion;
                orbit.tiltY = CenterTiltY - (CenterTiltY - CoreTiltY) * actualProportion;
                orbit.speedMultiplier = (CoreSpeed - CenterSpeed) * actualProportion + CenterSpeed;
            }
            orbit.tiltZ = Rotation * proportion;
            orbit.centerPosition = CenterPosition * (1 - proportion);
            return orbit;
        }

        public float GetHeightOffset(float proportion)
        {
            float offset;
            offset = Mathf.Sqrt(1 - proportion); ;
            return (float)Random.NextGaussianDouble(offset) * (DiskA + DiskB) / 20;
        }

        public Color GetColor(float proportion)
        {
            Color color = new Color { };
            if (proportion > CoreProportion)
            {
                //If the wave is outside the disk;
                float actualProportion = (proportion - CoreProportion) / (1 - CoreProportion);
                color = CoreColor * (1 - actualProportion) + DiskColor * actualProportion;
            }
            else
            {
                float actualProportion = proportion / CoreProportion;
                color = CoreColor * actualProportion + CenterColor * (1 - actualProportion);
            }
            return color;
        }

    }
}