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
        [SerializeField]
        private int m_StarAmount;

        private bool m_DisplayOrbits;

        List<OrbitObject> m_OrbitObjects;

        DensityWave m_DensityWave;

        private float m_TimeSpeed;

        [SerializeField]
        private DensityWaveProperties m_DensityWaveProperties;
        [SerializeField]
        private StarFactory m_StarFactory;

        bool m_Running = true;

        private List<Star> m_StarList;

        Galaxy m_Galaxy;
        // Start is called before the first frame update
        void Start()
        {
            m_TimeSpeed = 0.5f;
            Debug.Assert(m_OrbitsAmount <= 100 && m_OrbitsAmount >= 10);

            m_Galaxy = new Galaxy(m_DensityWaveProperties);
            m_OrbitObjects = new List<OrbitObject>();
            for(int i = 0; i < m_OrbitsAmount; i++)
            {
                OrbitObject instance = Instantiate(m_OrbitPrefab, transform);
                instance.gameObject.SetActive(false);
                m_OrbitObjects.Add(instance);
            }
            m_DensityWave = m_Galaxy.DensityWave;
            Recalculate();

            m_StarFactory.Start();
            m_StarList = new List<Star>();
            for(int i = 0; i < m_StarAmount; i++)
            {
                float proportion = Random.Next();
                float mass = Random.Next();
                m_StarList.Add(m_StarFactory.Get(new StarProperties {
                    mass = 0.5f + mass / 2,
                    startingTime = Random.Next() * 360,
                    index = i,
                    proportion = proportion,
                    heightOffset = (float)Random.NextGaussianDouble(m_DensityWave.GetHeightOffset(proportion) * 100)
                }
                , m_DensityWave.GetOrbit(proportion)));
            }
        }

        

        public void Recalculate()
        {
            m_Galaxy.StarPositionCalculationSystem.CalculateOrbits();
            for(int i = 0; i < m_OrbitsAmount; i++)
            {
                m_OrbitObjects[i].orbit = m_DensityWave.GetOrbit((float)i / (m_OrbitsAmount - 1));
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

        public void SetCoreSpeed(float speed)
        {
            m_DensityWave.SetCoreSpeed(speed);
            Recalculate();
        }

        public void SetCenterSpeed(float speed)
        {
            m_DensityWave.SetCenterSpeed(speed);
            Recalculate();
        }

        public void SetDiskSpeed(float speed)
        {
            m_DensityWave.SetDiskSpeed(speed);
            Recalculate();
        }

        public void SetTimeSpeed(float speed)
        {
            m_TimeSpeed = speed;
            if(speed == 0)
            {
                m_Running = false;
            }
            else
            {
                m_Running = true;
            }
        }
        #endregion
        
        public void Update()
        {
            if (m_Running)
            {
                m_Galaxy.AddTime(Time.deltaTime * m_TimeSpeed);
                for (int i = 0; i < m_StarAmount; i++)
                {
                    m_StarList[i].SyncRigidBody();
                }
            }
        }

    }
}
