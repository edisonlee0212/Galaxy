using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Galaxy
{



    [Serializable]
    public struct StarProperties : IComponentData
    {
        /// <summary>
        /// The start time of the star, use this to calculate initial position.
        /// </summary>
        public float startingTime;
        /// <summary>
        /// This keep track of the position of the star in the list.
        /// </summary>
        public int index;
        /// <summary>
        /// This will help calculate the orbit.;
        /// </summary>
        public float proportion;
        /// <summary>
        /// Mass of the star, use this as a factor of angle speed.
        /// </summary>
        public float mass;
        /// <summary>
        /// The deviation of height of its orbit
        /// </summary>
        public float heightOffset;
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
    public struct StarTag : IComponentData
    {

    }

    [Serializable]
    public struct IsDead : IComponentData
    {
        public bool value;
    }
}