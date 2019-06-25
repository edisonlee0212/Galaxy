using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Galaxy
{
    public class Test : MonoBehaviour
    {

        [SerializeField]
        private OrbitObject m_OrbitPrefab;
        [SerializeField]
        private int m_OrbitsAmount;

        private OrbitObject[] m_Orbits;
        [SerializeField]
        private DensityWaveProperties m_DensityWaveProperties;

        private DensityWave m_DensityWave;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Assert(m_OrbitsAmount <= 100 && m_OrbitsAmount >= 10);
            m_Orbits = new OrbitObject[100];
            for(int i = 0; i < 100; i++)
            {
                OrbitObject instance = Instantiate(m_OrbitPrefab, transform);
                instance.orbit = new Orbit();
                instance.gameObject.SetActive(false);
                m_Orbits[i] = instance;
            }
            m_DensityWave = new DensityWave(m_DensityWaveProperties);
            Recalculate();
        }

        

        public void SetRotation(float rotation)
        {
            m_DensityWave.SetRotation(rotation);
            Recalculate();
        }

        public void SetOrbitAmount(float amount)
        {
            m_OrbitsAmount = (int)amount;
            Recalculate();
        }

        public void SetCoreProportion(float proportion)
        {
            m_DensityWave.SetCoreProportion(proportion);
            Recalculate();
        }

        public void SetCoreEccentricity(float coreEccentricity)
        {
            m_DensityWave.SetCoreEccentricity(coreEccentricity);
            Recalculate();
        }

        public void Recalculate()
        {
            for(int i = 0; i < m_OrbitsAmount; i++)
            {
                Orbit orbit = m_Orbits[i].orbit;
                m_DensityWave.SetOrbit((float)i / (m_OrbitsAmount - 1), ref orbit);
                m_Orbits[i].CalculateEllipse();
                m_Orbits[i].gameObject.SetActive(true);
            }
            for(int i = m_OrbitsAmount; i < 100; i++)
            {
                m_Orbits[i].gameObject.SetActive(false);
            }
        }
    }
}
