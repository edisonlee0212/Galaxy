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
        private StarSystemProperties m_StarSystemProperties;
        private Orbit[] m_Orbits;
        private Entity m_StarEntity;

        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        public StarProperties StarProperties { get => m_StarProperties; set => m_StarProperties = value; }
        public Entity StarEntity { get => m_StarEntity; set => m_StarEntity = value; }
        public Orbit[] Orbits { get => m_Orbits; set => m_Orbits = value; }

        public void Init()
        {            
            Orbits = new Orbit[MaxPlanetAmount];

            for (int i = 0; i < MaxPlanetAmount; i++)
            {
                Orbits[i] = Instantiate(m_PlanetOrbitPrefab, transform);
                Orbits[i].gameObject.SetActive(false);
            }
        }

        public void Reset(Entity starEntity)
        {
            m_StarEntity = starEntity;
            m_StarProperties = World.Active.EntityManager.GetComponentData<StarProperties>(m_StarEntity);
            m_StarSystemProperties = World.Active.EntityManager.GetComponentData<StarSystemProperties>(m_StarEntity);
            for (int i = 0; i < m_StarSystemProperties.PlanetAmount; i++)
            {
                Orbits[i].orbit = new OrbitProperties
                {
                    tiltX = m_StarSystemProperties.Seed * i * 3,
                    tiltZ = m_StarSystemProperties.Seed * i * 3,
                    a = m_StarProperties.Mass * (m_StarProperties.Mass + 2 + i * 0.5f),
                    b = m_StarProperties.Mass * (m_StarProperties.Mass + 2 + i * 0.5f)
                };
                Orbits[i].gameObject.SetActive(true);
                Orbits[i].CalculateEllipse(0.1f);
            }
            for (int i = m_StarSystemProperties.PlanetAmount; i < MaxPlanetAmount; i++)
            {
                Orbits[i].gameObject.SetActive(false);
            }
        }
    }
}
