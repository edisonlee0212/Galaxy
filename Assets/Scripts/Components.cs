using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
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
        /// Index of the star in the list
        /// </summary>
        public int index;
        /// <summary>
        /// Rotation speed of the star in its orbit
        /// </summary>
        public float angleSpeed;
        /// <summary>
        /// a radius of the ellipse
        /// </summary>
        public float a;
        /// <summary>
        /// b radius of the ellipse
        /// </summary>
        public float b;
        /// <summary>
        /// The deviation angle of the orbit, set when start.
        /// </summary>
        public float angleOffset;
    }

    [Serializable]
    public struct StarTag : IComponentData
    {

    }
}