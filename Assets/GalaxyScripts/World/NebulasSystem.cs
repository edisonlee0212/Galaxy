using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Galaxy
{
    [CreateAssetMenu]
    public class NebulasSystem : ScriptableObject
    {
        [SerializeField]
        private GameObject m_MeshVertexParticleSystemPrefab;

        private List<GameObject> m_MeshVertexParticleSystems;
        private GalaxyPattern m_DensityWave;
        public GalaxyPattern DensityWave { get => m_DensityWave; set => m_DensityWave = value; }

        private float m_Time;
        private List<float[]> m_MeshVertexStartTimes;

        public void Init()
        {
            m_MeshVertexStartTimes = new List<float[]>();
            m_MeshVertexParticleSystems = new List<GameObject>();
        }

        public int AddCenterCloud(int verticeAmount, int thickness = 400)
        {
            //Set up the mesh
            Mesh mesh = new Mesh();
            mesh.name = "Nebula Vertices";
            var vertices = new Vector3[verticeAmount];
            var startTimes = new float[verticeAmount];
            for(int i = 0; i < verticeAmount; i++)
            {
                var proportion = Random.Next();
                var orbit = m_DensityWave.GetOrbit(proportion * proportion, float3.zero);
                float startTime = Random.Next();
                startTimes[i] = startTime;
                vertices[i] = orbit.GetPoint((startTime) * 100);
                vertices[i].z += m_DensityWave.GetOrbitOffset(proportion).z;
            }
            mesh.vertices = vertices;
            //Set up the particle system
            GameObject instance = Instantiate(m_MeshVertexParticleSystemPrefab, Vector3.zero, Quaternion.identity);
            var particleSystem = instance.GetComponent<ParticleSystem>();
            var mainModule = particleSystem.main;
            mainModule.maxParticles = thickness * 5;
            var emissionModule = particleSystem.emission;
            emissionModule.rateOverTime = thickness;
            var shape = particleSystem.shape;
            shape.mesh = mesh;
            


            m_MeshVertexParticleSystems.Add(instance);
            m_MeshVertexStartTimes.Add(startTimes);

            return m_MeshVertexParticleSystems.Count - 1;
        }

        public int AddSphereCloud(float radius, int thickness, Vector3 scale, OrbitProperties orbitProperties)
        {
            return 0;
        }

        public void SetTimeAndCalculate(float time)
        {

        }
    }
}
