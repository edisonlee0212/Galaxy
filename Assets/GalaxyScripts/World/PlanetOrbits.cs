using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
namespace Galaxy
{
    public class PlanetOrbits : MonoBehaviour
    {
        [SerializeField]
        private Orbit m_PlanetOrbitPrefab;
        private int m_MaxPlanetAmount;
        private StarProperties m_StarProperties;
        private StarData m_StarData;
        private Orbit[] m_Orbits;
        private Entity m_StarEntity;

        private CameraControl m_CameraControl;

        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        public StarProperties StarProperties { get => m_StarProperties; set => m_StarProperties = value; }
        public Entity StarEntity { get => m_StarEntity; set => m_StarEntity = value; }
        public Orbit[] Orbits { get => m_Orbits; set => m_Orbits = value; }
        public CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }

        public void Init()
        {            
            Orbits = new Orbit[MaxPlanetAmount];

            for (int i = 0; i < MaxPlanetAmount; i++)
            {
                Orbits[i] = Instantiate(m_PlanetOrbitPrefab, transform);
                Orbits[i].gameObject.SetActive(false);
            }
        }
    }
}
