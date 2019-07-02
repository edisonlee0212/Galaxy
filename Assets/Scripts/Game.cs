using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
namespace Galaxy
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private OrbitObject m_OrbitPrefab;

        [SerializeField]
        private int m_OrbitsAmount;

        [SerializeField]
        private DensityWaveProperties m_DensityWaveProperties;

        private bool m_DisplayOrbits;
        private List<OrbitObject> m_OrbitObjects;
        private DensityWave m_DensityWave;
        private float m_TimeSpeed;
        private bool m_Running = true;
        private Galaxy m_Galaxy;

        // Start is called before the first frame update
        void Start()
        {
            m_TimeSpeed = 0.1f;
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
        }

        public void Update()
        {
            
            m_Galaxy.AddTime(Time.deltaTime * m_TimeSpeed);
        }

        /// <summary>
        /// To recalculate the orbit, and to reset every star.
        /// </summary>
        public void Recalculate()
        {
            m_Galaxy.StarPositionCalculationSystem.CalculateOrbit = true;
            for(int i = 0; i < m_OrbitsAmount; i++)
            {
                m_OrbitObjects[i].orbit = m_DensityWave.GetOrbit((float)i / (m_OrbitsAmount - 1));
                m_OrbitObjects[i].CalculateEllipse();
                m_OrbitObjects[i].gameObject.SetActive(m_DisplayOrbits);
            }
            m_Galaxy.AddTime(0);
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
        
    }
}
