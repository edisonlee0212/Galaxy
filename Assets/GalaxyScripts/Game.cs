using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Galaxy
{
    public class Game : MonoBehaviour
    {
        #region Attributes

        [SerializeField]
        private CameraControl m_CameraControl;
        [SerializeField]
        private GalaxySystem m_GalaxySystem;
        [SerializeField]
        private Orbit m_OrbitPrefab;
        [SerializeField]
        private int m_OrbitsAmount;
        [SerializeField]
        private GalaxyPatternProperties m_DensityWaveProperties;
        [SerializeField]
        private Settings m_Settings;
        [SerializeField]
        private StarMarker m_StarMarker;
        [SerializeField]
        private PlanetarySystem m_PlanetarySystemPrefab;
        [SerializeField]
        private GameObject m_LoadingScreen;
        [SerializeField]
        private int seed;
        #endregion

        private static int m_Seed;
        private PlanetarySystem m_PlanetarySystem;
        private bool m_DisplayOrbits;
        private List<Orbit> m_OrbitObjects;
        private GalaxyPattern m_DensityWave;
        private float m_TimeSpeed;
        private bool m_Running = true;
        private int m_StarAmount;

        public static int Seed { get => m_Seed; set => m_Seed = value; }

        // Start is called before the first frame update
        void Start()
        {
            
            var go = GameObject.Find("SceneMsg");
            if (go != null)
            {
                SceneMsg msg = go.GetComponent<SceneMsg>();
                m_StarAmount = msg.StartAmount;
                m_Seed = msg.Seed;
                Destroy(go);
            }
            else
            {
                m_StarAmount = 6000;
                m_Seed = seed;
            }
            m_DensityWaveProperties.DiskAB = Mathf.Pow(m_StarAmount, 0.3333333f) * 1000;
            m_LoadingScreen = Instantiate(m_LoadingScreen, FindObjectOfType<Canvas>().transform);
            Debug.Log("Start Loading...");
            Init();
            Destroy(m_LoadingScreen);
            Debug.Log("Loading finished...");
        }

        private void Init()
        {
            Canvas m_Canvas = FindObjectOfType<Canvas>();

            m_CameraControl = Instantiate(m_CameraControl);
            m_StarMarker = Instantiate(m_StarMarker, m_Canvas.transform);

            m_PlanetarySystem = Instantiate(m_PlanetarySystemPrefab, Vector3.zero, Quaternion.identity);
            m_CameraControl.PlanetarySystem = m_PlanetarySystem;
            m_GalaxySystem.CameraControl = m_CameraControl;
            m_GalaxySystem.StarMarker = m_StarMarker;
            m_GalaxySystem.PlanetarySystem = m_PlanetarySystem;
            m_GalaxySystem.Init(m_DensityWaveProperties, m_StarAmount, 10);
            m_TimeSpeed = 0.001f;
            Debug.Assert(m_OrbitsAmount <= 100 && m_OrbitsAmount >= 10);
            m_OrbitObjects = new List<Orbit>();
            for (int i = 0; i < m_OrbitsAmount; i++)
            {
                Orbit instance = Instantiate(m_OrbitPrefab, transform);
                instance.gameObject.SetActive(false);
                m_OrbitObjects.Add(instance);
            }
            m_DensityWave = m_GalaxySystem.GalaxyPattern;
            m_Settings.Init(m_GalaxySystem.GalaxyPattern.DensityWaveProperties, m_TimeSpeed, m_DisplayOrbits);
            Recalculate();
        }

        public void OnBackToMainMenu()
        {
            m_GalaxySystem.ShutDown();
            SceneManager.LoadScene("Start");
        }

        public void Update()
        {
            m_GalaxySystem.AddTime(Time.fixedDeltaTime * m_TimeSpeed);
        }

        #region Methods
        /// <summary>
        /// To recalculate the orbit, and to resetsion every star.
        /// </summary>
        public void Recalculate()
        {
            m_GalaxySystem.Galaxy.StarTransformSimulationSystem.CalculateOrbit = true;
            for (int i = 0; i < m_OrbitsAmount; i++)
            {
                m_OrbitObjects[i].orbit = m_DensityWave.GetOrbit((float)i / (m_OrbitsAmount - 1), float3.zero);
                m_OrbitObjects[i].CalculateEllipse();
                m_OrbitObjects[i].gameObject.SetActive(m_DisplayOrbits);
            }
            m_GalaxySystem.SetTime(m_GalaxySystem.Galaxy.Time);
        }

        public void SetCenterPositionX(float x)
        {
            m_DensityWave.SetCenterPositionX(x);
            Recalculate();
        }

        public void SetCenterPositionY(float y)
        {
            m_DensityWave.SetCenterPositionY(y);
            Recalculate();
        }

        public void SetCenterPositionZ(float z)
        {
            m_DensityWave.SetCenterPositionZ(z);
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

        public void SetDisplayOrbits(bool display)
        {
            m_DisplayOrbits = display;
            Recalculate();
        }

        public void SetDiskAB(float ab)
        {
            m_DensityWave.SetDiskAB(ab);
            Recalculate();
        }

        public void SetDiskEccentricity(float ecc)
        {
            m_DensityWave.SetDiskEccentricity(ecc);
            Recalculate();
        }

        public void SetCenterEccentricity(float ecc)
        {
            m_DensityWave.SetCenterEccentricity(ecc);
            Recalculate();
        }

        public void SetCenterAB(float radius)
        {
            m_DensityWave.SetCenterAB(radius);
            Recalculate();
        }

        public void SetCenterTiltX(float tiltX)
        {
            m_DensityWave.SetCenterTiltX(tiltX);
            Recalculate();
        }

        public void SetCenterTiltY(float tiltY)
        {
            m_DensityWave.SetCenterTiltZ(tiltY);
            Recalculate();
        }

        public void SetCoreTiltX(float tiltX)
        {
            m_DensityWave.SetCoreTiltX(tiltX);
            Recalculate();
        }

        public void SetCoreTiltY(float tiltY)
        {
            m_DensityWave.SetCoreTiltZ(tiltY);
            Recalculate();
        }

        public void SetDiskTiltX(float tiltX)
        {
            m_DensityWave.SetDiskTiltX(tiltX);
            Recalculate();
        }

        public void SetDiskTiltY(float tiltY)
        {
            m_DensityWave.SetDiskTiltZ(tiltY);
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
            if (speed == 0)
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
