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
        /// This keep track of the position of the star in the list.
        /// </summary>
        public int index;
        /// <summary>
        /// Index of the orbit of the star;
        /// </summary>
        public int orbitIndex;
        /// <summary>
        /// Mass of the star, use this as a factor of angle speed.
        /// </summary>
        public float mass;
        /// <summary>
        /// The deviation of height of its orbit
        /// </summary>
        public float heightOffset;
        /// <summary>
        /// the deviation of radius of its orbit
        /// </summary>
        public float radiusOffset;
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