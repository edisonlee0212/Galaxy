using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
namespace Galaxy
{
    public class PlanetarySystem : MonoBehaviour
    {
        [SerializeField]
        private PlanetHolder m_PlanetHolderPrefab;
        private StarProperties m_StarProperties;
        private EntityManager m_EntityManager;
        private StarData m_StarData;
        private float m_Time;
        //private Planet[] m_Planets;
        private PlanetHolder[] m_PlanetHolders;
        private int m_MaxPlanetAmount;
        private OrbitProperties[] m_OrbitProperties;
        private PlanetData[] m_PlanetDatas;
        private PlanetOrbits m_PlanetOrbits;
        private Light m_Light;
        //public Planet[] Planets { get => m_Planets; set => m_Planets = value; }
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        public PlanetOrbits PlanetOrbits { get => m_PlanetOrbits; set => m_PlanetOrbits = value; }
        public OrbitProperties[] OrbitProperties { get => m_OrbitProperties; set => m_OrbitProperties = value; }
        public float Time { get => m_Time; set => m_Time = value; }
        public PlanetData[] PlanetProperties { get => m_PlanetDatas; set => m_PlanetDatas = value; }
        public Light Light { get => m_Light; set => m_Light = value; }
        public PlanetHolder[] PlanetHolders { get => m_PlanetHolders; set => m_PlanetHolders = value; }

        public void Start()
        {
            m_EntityManager = World.Active.EntityManager;
        }

        public void Init()
        {
            m_PlanetHolders = new PlanetHolder[m_MaxPlanetAmount];
            m_OrbitProperties = new OrbitProperties[m_MaxPlanetAmount];
            m_PlanetDatas = new PlanetData[m_MaxPlanetAmount];
            for (int i = 0; i < m_MaxPlanetAmount; i++)
            {
                m_PlanetHolders[i] = Instantiate(m_PlanetHolderPrefab, transform);
                m_PlanetHolders[i].Planet.gameObject.SetActive(true);
                m_PlanetHolders[i].gameObject.SetActive(false);
                m_PlanetDatas[i] = default;
            }
        }
        public unsafe void Reset(Entity starEntity)
        {
            if (starEntity != Entity.Null && m_PlanetOrbits != null && m_PlanetHolders != null)
            {
                m_StarProperties = m_EntityManager.GetComponentData<StarProperties>(starEntity);
                Random.seed = m_StarProperties.Index;
                m_StarData = DataSystem.StarDatas[m_StarProperties.Index];

                int planetAmount = m_StarData.PlanetAmount;
                for (int i = 0; i < planetAmount; i++)
                {
                    var planetData = DataSystem.PlanetDatas[m_StarData.PlanetReferences[i]];
                    m_PlanetDatas[i] = planetData;
                    OrbitProperties[i] = new OrbitProperties
                    {
                        tiltX = Random.Next() * 10,
                        tiltZ = Random.Next() * 10,
                        a = m_StarProperties.Mass * planetData.DistanceToStar,
                        b = m_StarProperties.Mass * planetData.DistanceToStar,
                        speedMultiplier = 5
                    };
                    m_PlanetOrbits.Orbits[i].orbit = m_OrbitProperties[i];
                    if(m_PlanetOrbits.Orbits[i] != null) m_PlanetOrbits.Orbits[i].gameObject.SetActive(true);
                    if(m_PlanetHolders[i].Planet != null) m_PlanetHolders[i].Planet.transform.localScale = Vector3.one * 0.1f;
                    m_PlanetHolders[i].gameObject.SetActive(true);
                    m_PlanetOrbits.Orbits[i].CalculateEllipse(0.01f);
                }
                for (int i = planetAmount; i < m_PlanetHolders.Length; i++)
                {
                    m_PlanetHolders[i].gameObject.SetActive(false);
                    m_PlanetOrbits.Orbits[i].gameObject.SetActive(false);
                }
                m_Light.enabled = true;
            }
            else
            {
                m_Light.enabled = false;
                for (int i = 0; i < m_StarData.PlanetAmount; i++)
                {
                    m_PlanetHolders[i].gameObject.SetActive(false);
                    m_PlanetOrbits.Orbits[i].gameObject.SetActive(false);
                }
                m_StarData.PlanetAmount = 0;
            }
        }

        public void Update()
        {
            m_Time += UnityEngine.Time.deltaTime / 300;
            for (int i = 0; i < m_StarData.PlanetAmount; i++)
            {
                m_PlanetHolders[i].transform.position = (float3)m_OrbitProperties[i].GetPoint(m_Time + m_PlanetDatas[i].Seed);
                if(m_PlanetHolders[i].Planet != null) m_PlanetHolders[i].Planet.transform.rotation = Quaternion.AngleAxis(m_Time * 10000, Quaternion.AngleAxis(m_OrbitProperties[i].tiltZ, Vector3.forward) * Quaternion.AngleAxis((float)m_OrbitProperties[i].tiltX, Vector3.right) * Vector3.up);

            }
        }
    }
}
