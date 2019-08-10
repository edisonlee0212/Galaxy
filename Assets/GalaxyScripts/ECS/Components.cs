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
    public struct BeaconProperties : IComponentData
    {
        public int Index;
    }


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
        public ushort Index;
        /// <summary>
        /// This will help calculate the orbit. Smaller = close to center, bigger = close to disk
        /// </summary>
        public float Proportion;
        /// <summary>
        /// Mass of the star, use this as a factor of angle speed.
        /// </summary>
        public float Mass;
        /// <summary>
        /// The deviation of its orbit
        /// </summary>
        public float3 OrbitOffset;
        /// <summary>
        /// Color of the surface of the star
        /// </summary>
        public Vector4 Color;
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
    public struct Position : IComponentData {
        public double3 Value;
    }

    [Serializable]
    public struct OrbitProperties : IComponentData
    {
        #region Public
        public float a;
        public float b;
        public float tiltY;
        public float tiltX;
        public float tiltZ;
        public float speedMultiplier;
        public Vector3 centerPosition;
        public Vector3 orbitOffset;
        #endregion

        public void SetPoint(float angle, ref double3 point)
        {
            point.x = Math.Sin(angle) * a;
            point.y = 0;
            point.z = Math.Cos(angle) * b;
            point = Rotate(Quaternion.AngleAxis(angle, Vector3.forward), point);
            point.x += centerPosition.x;
            point.y += centerPosition.y;
            point.z += centerPosition.z;
        }
        public double3 GetPoint(double time, bool star = true)
        {
            double angle = star ? time / Math.Sqrt(a + b) * speedMultiplier : time;

            double3 point = new double3();
            point.x = Math.Sin(angle) * a + orbitOffset.x;
            point.y = orbitOffset.y;
            point.z = Math.Cos(angle) * b + orbitOffset.z;

            point = Rotate(Quaternion.AngleAxis(tiltX, Vector3.right), point);
            point = Rotate(Quaternion.AngleAxis(tiltY, Vector3.up), point);
            point = Rotate(Quaternion.AngleAxis(tiltZ, Vector3.forward), point);

            point.x += centerPosition.x;
            point.y += centerPosition.y;
            point.z += centerPosition.z;
            return point;
        }

        private double3 Rotate(Quaternion rotation, double3 point)
        {
            double x = rotation.x * 2D;
            double y = rotation.y * 2D;
            double z = rotation.z * 2D;
            double xx = rotation.x * x;
            double yy = rotation.y * y;
            double zz = rotation.z * z;
            double xy = rotation.x * y;
            double xz = rotation.x * z;
            double yz = rotation.y * z;
            double wx = rotation.w * x;
            double wy = rotation.w * y;
            double wz = rotation.w * z;
            double3 res;
            res.x = (1D - (yy + zz)) * point.x + (xy - wz) * point.y + (xz + wy) * point.z;
            res.y = (xy + wz) * point.x + (1D - (xx + zz)) * point.y + (yz - wx) * point.z;
            res.z = (xz - wy) * point.x + (yz + wx) * point.y + (1D - (xx + yy)) * point.z;
            return res;
        }
    }

    [Serializable]
    public struct GalaxyPatternProperties
    {
        #region public
        public float YSpread;
        public float XZSpread;

        public float DiskAB;
        public float DiskEccentricity;
        [NonSerialized]
        public float DiskA;
        [NonSerialized]
        public float DiskB;

        public float CoreProportion;
        [NonSerialized]
        public float CoreAB;
        public float CoreEccentricity;
        [NonSerialized]
        public float CoreA;
        [NonSerialized]
        public float CoreB;

        public float CenterAB;
        public float CenterEccentricity;
        [NonSerialized]
        public float CenterA;
        [NonSerialized]
        public float CenterB;
        

        public float DiskSpeed;
        public float CoreSpeed;
        public float CenterSpeed;

        public float DiskTiltX;
        public float DiskTiltZ;
        public float CoreTiltX;
        public float CoreTiltZ;
        public float CenterTiltX;
        public float CenterTiltZ;

        public Color DiskColor;
        public Color CoreColor;
        public Color CenterColor;

        public float Rotation;
        public float3 CenterPosition;
        
        #endregion
        #region Private

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
        public OrbitProperties GetOrbit(float proportion, float3 orbitOffset)
        {
            OrbitProperties orbit;
            if (proportion > CoreProportion)
            {
                //If the wave is outside the disk;
                float actualProportion = (proportion - CoreProportion) / (1 - CoreProportion);
                orbit.a = CoreA + (DiskA - CoreA) * actualProportion;
                orbit.b = CoreB + (DiskB - CoreB) * actualProportion;
                orbit.tiltX = CoreTiltX - (CoreTiltX - DiskTiltX) * actualProportion;
                orbit.tiltZ = CoreTiltZ - (CoreTiltZ - DiskTiltZ) * actualProportion;
                orbit.speedMultiplier = CoreSpeed + (DiskSpeed - CoreSpeed) * actualProportion;
            }
            else
            {
                float actualProportion = proportion / CoreProportion;
                orbit.a = CenterA + (CoreA - CenterA) * actualProportion;
                orbit.b = CenterB + (CoreB - CenterB) * actualProportion;
                orbit.tiltX = CenterTiltX - (CenterTiltX - CoreTiltX) * actualProportion;
                orbit.tiltZ = CenterTiltZ - (CenterTiltZ - CoreTiltZ) * actualProportion;
                orbit.speedMultiplier = CenterSpeed + (CoreSpeed - CenterSpeed) * actualProportion;
            }
            orbit.tiltY = -Rotation * proportion;
            orbit.centerPosition = CenterPosition * (1 - proportion);
            orbit.orbitOffset = orbitOffset;
            return orbit;
        }

        public float3 GetOrbitOffset(float proportion)
        {
            float offset;
            offset = Mathf.Sqrt(1 - proportion);
            float3 orbitOffset;
            orbitOffset.y = (float)Random.NextGaussianDouble(offset) * (DiskA + DiskB) * YSpread;
            orbitOffset.x = (float)Random.NextGaussianDouble(offset) * (DiskA + DiskB) * XZSpread;
            orbitOffset.z = (float)Random.NextGaussianDouble(offset) * (DiskA + DiskB) * XZSpread;
            return orbitOffset;
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