using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Galaxy
{
    [CreateAssetMenu]
    public class PlanetGenerator : ScriptableObject
    {
        [SerializeField]
        private Planet[] m_PlanetPrefabs;

        private Planet[] m_Planets;
        public Planet[] Planets { get => m_Planets; set => m_Planets = value; }

        public void Init()
        {
            m_Planets = new Planet[m_PlanetPrefabs.Length];
            for(int i = 0; i < m_Planets.Length; i++)
            {
                m_Planets[i] = Instantiate(m_PlanetPrefabs[i]);
                m_Planets[i].gameObject.SetActive(false);
            }
        }

        public Mesh GetMesh(int index)
        {
            return m_Planets[index].GetComponent<MeshFilter>().mesh;
        }

        public Material GetPlanetMaterial(int index, float seed)
        {
            return m_Planets[(int)(seed * index) % m_Planets.Length].GetPlanetMaterial(seed);
        }

        public Material GetAtmosphereMaterial(int index, float seed)
        {
            return m_Planets[(int)(seed * index) % m_Planets.Length].GetAtmosphereMaterial(seed);
        }

    }
}
