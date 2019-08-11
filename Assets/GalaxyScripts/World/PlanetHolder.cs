using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Galaxy
{
    public class PlanetHolder : MonoBehaviour
    {
        private Planet m_Planet;

        public Planet Planet { get => m_Planet; }

        protected void Awake()
        {
            m_Planet = transform.GetChild(0).GetComponent<Planet>();
        }

    }
}
