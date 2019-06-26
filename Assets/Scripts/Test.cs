using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
namespace Galaxy
{
    public class Test : MonoBehaviour
    {

        [SerializeField]
        private OrbitObject m_OrbitPrefab;
        [SerializeField]
        private int m_OrbitsAmount;
        private bool m_DisplayOrbits;

        List<OrbitObject> m_OrbitObjects;

        NativeArray<Orbit> m_Orbits;
        DensityWave m_DensityWave;

        private float m_TimeSpeed;

        [SerializeField]
        private DensityWaveProperties m_DensityWaveProperties;
        [SerializeField]
        private StarFactory m_StarFactory;

        private List<Star> m_StarList;

        Galaxy m_Galaxy;
        // Start is called before the first frame update
        void Start()
        {
            m_TimeSpeed = 0.5f;
            Debug.Assert(m_OrbitsAmount <= 100 && m_OrbitsAmount >= 10);

            m_Galaxy = new Galaxy(m_OrbitsAmount, m_DensityWaveProperties);
            m_Orbits = m_Galaxy.StarPositionCalculationSystem.m_Orbits;
            m_OrbitObjects = new List<OrbitObject>();
            for(int i = 0; i < m_OrbitsAmount; i++)
            {
                OrbitObject instance = Instantiate(m_OrbitPrefab, transform);
                instance.orbit = new Orbit { };
                instance.gameObject.SetActive(false);
                m_OrbitObjects.Add(instance);
            }
            m_DensityWave = m_Galaxy.DensityWave;
            Recalculate();

            m_StarFactory.Start();
            m_StarList = new List<Star>();

            for(int i = 0; i < 2000; i++)
            {
                m_StarList.Add(m_StarFactory.Get(new StarProperties {
                    mass = 1,
                    startingTime = Random.value * 360,
                    index = i,
                    orbitIndex = i % m_OrbitsAmount
                }));
            }
        }

        public void Recalculate()
        {
            m_Galaxy.StarPositionCalculationSystem.CalculateOrbits();
            for(int i = 0; i < m_OrbitsAmount; i++)
            {
                m_OrbitObjects[i].orbit = m_Orbits[i];
                m_OrbitObjects[i].CalculateEllipse();
                m_OrbitObjects[i].gameObject.SetActive(m_DisplayOrbits);
            }
        }

        #region Properties setters
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

        public void SetDisplayOrbits(bool display)
        {
            m_DisplayOrbits = display;
            Recalculate();
        }

        public void SetMaxA(float maxA)
        {
            m_DensityWave.SetMaxA(maxA);
            Recalculate();
        }

        public void SetMaxB(float maxB)
        {
            m_DensityWave.SetMaxB(maxB);
            Recalculate();
        }

        public void SetMinRadius(float radius)
        {
            m_DensityWave.SetMinRadius(radius);
            Recalculate();
        }

        public void SetCenterTiltX(float tiltX)
        {
            m_DensityWave.SetCenterTiltX(tiltX);
            Recalculate();
        }

        public void SetCenterTiltY(float tiltY)
        {
            m_DensityWave.SetCenterTiltY(tiltY);
            Recalculate();
        }

        public void SetCoreTiltX(float tiltX)
        {
            m_DensityWave.SetCoreTiltX(tiltX);
            Recalculate();
        }

        public void SetCoreTiltY(float tiltY)
        {
            m_DensityWave.SetCoreTiltY(tiltY);
            Recalculate();
        }

        public void SetTimeSpeed(float speed)
        {
            m_TimeSpeed = speed;
        }
        #endregion

        public void FixedUpdate()
        {
            m_Galaxy.AddTime(Time.fixedDeltaTime * m_TimeSpeed);
            for(int i = 0; i < 2000; i++)
            {
                m_StarList[i].SyncRigidBody();
            }
        }

    }
}
