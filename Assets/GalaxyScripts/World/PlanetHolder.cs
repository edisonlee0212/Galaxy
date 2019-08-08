using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Galaxy
{
    public class PlanetHolder : MonoBehaviour
    {
        [NonSerialized]
        public Planet Planet;
        protected void Awake()
        {
            Planet = transform.GetChild(0).GetComponent<Planet>();
        }
    }
}
