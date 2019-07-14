using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
namespace Galaxy
{
    [RequireComponent(typeof(Light))]
    public class StarSystem : MonoBehaviour
    {
        [SerializeField]
        private Orbit m_PlanetOrbitPrefab;
        [SerializeField]
        private Planet m_PlanetPrefab;

        private StarSystemProperties m_StarSystemProperties;
        private int m_MaxPlanetAmount;
        private float m_CurrentTime;
        private StarProperties m_StarProperties;
        private Entity m_FollowedStar;
        private Planet[] m_Planets;
        private Orbit[] m_Orbits;
        public StarSystemProperties StarSystemProperties { get => m_StarSystemProperties; set => m_StarSystemProperties = value; }
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        public float CurrentTime { get => m_CurrentTime; set => m_CurrentTime = value; }
        public Entity FollowedStar { get => m_FollowedStar; set => m_FollowedStar = value; }

        public void Init()
        {
            m_MaxPlanetAmount = 15;
            m_StarSystemProperties = World.Active.EntityManager.GetComponentData<StarSystemProperties>(m_FollowedStar);
            m_StarProperties = World.Active.EntityManager.GetComponentData<StarProperties>(m_FollowedStar);
            m_Planets = new Planet[m_MaxPlanetAmount];
            m_Orbits = new Orbit[m_MaxPlanetAmount];

            float a = 10;
            float b = 10;

            for (int i = 0; i < m_MaxPlanetAmount; i++)
            {
                m_Planets[i] = Instantiate(m_PlanetPrefab, transform);
                m_Planets[i].StartingTime = Random.Next() * 360;
                m_Orbits[i] = Instantiate(m_PlanetOrbitPrefab, transform);
                m_Orbits[i].orbit = new OrbitProperties
                {
                    a = a,
                    b = b,
                    speedMultiplier = 3f / a
                };
                a += 5;
                b += 5;
            }

            Reset();
        }

        public void Reset()
        {
            //Material material = GetComponent<MeshRenderer>().material;
            //material.SetColor("_EmissionColor", m_StarProperties.Color);

            GetComponent<Light>().color = m_StarProperties.Color;
            transform.localScale = Vector3.one * m_StarProperties.Mass;
            for (int i = 0; i < m_StarSystemProperties.PlanetAmount; i++)
            {

                m_Planets[i].gameObject.SetActive(true);
                m_Orbits[i].gameObject.SetActive(false);
                m_Orbits[i].CalculateEllipse(0.5f);
            }
            for (int i = m_StarSystemProperties.PlanetAmount; i < m_MaxPlanetAmount; i++)
            {
                m_Planets[i].gameObject.SetActive(false);
                m_Orbits[i].gameObject.SetActive(false);
            }
            Follow();
        }
        float timeStep;
        void Update()
        {

            m_CurrentTime += Time.fixedDeltaTime;
            timeStep += Time.deltaTime;
            if (timeStep > 0.02)
            {
                for (int i = 0; i < m_StarSystemProperties.PlanetAmount; i++)
                {
                    m_Planets[i].transform.localPosition = m_Orbits[i].orbit.GetPoint((m_CurrentTime + m_Planets[i].StartingTime));
                }
                Follow();
                timeStep = 0;
            }
        }

        private void Follow()
        {
            Vector3 position = World.Active.EntityManager.GetComponentData<Translation>(m_FollowedStar).Value;
            transform.position = position;
        }
    }
}
