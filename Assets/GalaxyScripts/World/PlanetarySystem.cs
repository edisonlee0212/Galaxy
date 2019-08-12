using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;

namespace Galaxy
{
    public enum PlanetType
    {
        Arctic,
        Arid,
        Baren,
        Continental,
        Desert,
        Jungle,
        Lava,
        Toxic
    }

    public class PlanetarySystem : MonoBehaviour
    {
        #region Attributes
        [SerializeField]
        private PlanetHolder m_PlanetHolderPrefab;
        [SerializeField]
        private Planet[] m_PlanetPrefabs;
        [SerializeField]
        private PlanetMarker m_PlanetMarkerPrefab;

        private StarProperties m_StarProperties;
        private EntityManager m_EntityManager;
        private StarData m_StarData;
        private Camera m_Camera;
        #endregion

        #region Public
        private float m_Time;
        private PlanetHolder[] m_PlanetHolders;
        private int m_MaxPlanetAmount;
        private OrbitProperties[] m_OrbitProperties;
        private PlanetData[] m_PlanetDatas;
        private ResourceData[] m_ResourceDatas;
        private PlanetOrbits m_PlanetOrbits;
        private Light m_Light;
        private PlanetMarker[] m_PlanetMarkers;
        private CameraControl m_CameraControl;
        public int MaxPlanetAmount { get => m_MaxPlanetAmount; set => m_MaxPlanetAmount = value; }
        public PlanetOrbits PlanetOrbits { get => m_PlanetOrbits; set => m_PlanetOrbits = value; }
        public OrbitProperties[] OrbitProperties { get => m_OrbitProperties; set => m_OrbitProperties = value; }
        public float Time { get => m_Time; set => m_Time = value; }
        public PlanetData[] PlanetProperties { get => m_PlanetDatas; set => m_PlanetDatas = value; }
        public Light Light { get => m_Light; set => m_Light = value; }
        public PlanetHolder[] PlanetHolders { get => m_PlanetHolders; set => m_PlanetHolders = value; }
        public PlanetMarker[] PlanetMarkers { get => m_PlanetMarkers; set => m_PlanetMarkers = value; }
        public CameraControl CameraControl { get => m_CameraControl; set => m_CameraControl = value; }
        public ResourceData[] ResourceDatas { get => m_ResourceDatas; set => m_ResourceDatas = value; }
        #endregion

        public void Start()
        {
            m_EntityManager = World.Active.EntityManager;
            m_Camera = Camera.main;
        }

        private static unsafe void CopyDataArray(NativeArray<PlanetData> planetDatas, int count, PlanetData[] outPlanetDatas, int sourceOffset)
        {
            fixed (PlanetData* planetDataPtr = outPlanetDatas)
            {
                PlanetData* sourcePtr = (PlanetData*)planetDatas.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(planetDataPtr, sourcePtr + sourceOffset, UnsafeUtility.SizeOf<PlanetData>() * count);
            }
        }

        private static unsafe void CopyDataArray(NativeArray<ResourceData> resourceDatas, int count, ResourceData[] outResourceDatas, int sourceOffset)
        {
            fixed (ResourceData* resourceDataPtr = outResourceDatas)
            {
                ResourceData* sourcePtr = (ResourceData*)resourceDatas.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resourceDataPtr, sourcePtr + sourceOffset, UnsafeUtility.SizeOf<ResourceData>() * count);
            }
        }

        public void Init()
        {
            m_PlanetHolders = new PlanetHolder[m_MaxPlanetAmount];
            m_OrbitProperties = new OrbitProperties[m_MaxPlanetAmount];
            m_PlanetMarkers = new PlanetMarker[m_MaxPlanetAmount];
            m_PlanetDatas = new PlanetData[m_MaxPlanetAmount];
            m_ResourceDatas = new ResourceData[m_MaxPlanetAmount];
            var canvas = FindObjectOfType<Canvas>();
            for (int i = 0; i < m_MaxPlanetAmount; i++)
            {
                m_PlanetHolders[i] = Instantiate(m_PlanetHolderPrefab, transform);
                m_PlanetMarkers[i] = Instantiate(m_PlanetMarkerPrefab, canvas.transform);
                m_PlanetMarkers[i].gameObject.SetActive(false);
                m_PlanetHolders[i].gameObject.SetActive(false);
                m_PlanetDatas[i] = default;
            }
        }

        public unsafe void Reset(Entity starEntity)
        {
            if (starEntity != Entity.Null && m_PlanetOrbits != null && m_PlanetHolders != null)
            {
                Debug.Log("Setting planetary system.");
                m_StarProperties = m_EntityManager.GetComponentData<StarProperties>(starEntity);
                Random.seed = m_StarProperties.Index;
                m_StarData = DataSystem.StarDatas[m_StarProperties.Index];
                CopyDataArray(DataSystem.PlanetDatas, m_StarData.PlanetAmount, m_PlanetDatas, m_StarData.FirstPlanetReference);
                CopyDataArray(DataSystem.ResourceDatas, m_StarData.PlanetAmount, m_ResourceDatas, m_StarData.FirstPlanetReference);
                int planetAmount = m_StarData.PlanetAmount;
                for (int i = 0; i < planetAmount; i++)
                {
                    var planetData = m_PlanetDatas[i];
                    OrbitProperties[i] = new OrbitProperties
                    {
                        tiltX = Random.Next() * 5 - 2.5f,
                        tiltZ = Random.Next() * 5 - 2.5f,
                        a = m_StarProperties.Mass * planetData.DistanceToStar,
                        b = m_StarProperties.Mass * planetData.DistanceToStar,
                        speedMultiplier = 5
                    };
                    m_PlanetOrbits.Orbits[i].orbit = m_OrbitProperties[i];
                    if (m_PlanetOrbits.Orbits[i] != null) m_PlanetOrbits.Orbits[i].gameObject.SetActive(true);
                    float planetSize = 1f;
                    if (m_PlanetHolders[i].Planet != null)
                    {
                        //TODO: Set up planet material here.
                        m_PlanetHolders[i].Planet.transform.localScale = Vector3.one * planetSize / 10;
                        m_PlanetHolders[i].Planet.PlanetMaterial = m_PlanetPrefabs[(int)(planetData.Seed * 24) % 8].PlanetMaterial;
                        m_PlanetHolders[i].Planet.transform.GetChild(0).GetComponent<MeshRenderer>().material = m_PlanetPrefabs[(int)(planetData.Seed * 24) % 8].AtmosphereMaterial;
                    }
                    m_PlanetHolders[i].gameObject.SetActive(true);
                    m_PlanetMarkers[i].PlanetNameText.text = "Unknown Planet No." + planetData.Reference;
                    m_PlanetMarkers[i].PlanetTypeText.text = "Type: " + ((PlanetType)((planetData.Seed * 24) % 8)).ToString();
                    m_PlanetMarkers[i].PlanetSizeText.text = "Size: " + planetSize.ToString();
                    m_PlanetMarkers[i].gameObject.SetActive(true);
                    m_PlanetOrbits.Orbits[i].CalculateEllipse(0.1f);
                }
                for (int i = planetAmount; i < m_PlanetHolders.Length; i++)
                {
                    m_PlanetHolders[i].gameObject.SetActive(false);
                    m_PlanetMarkers[i].gameObject.SetActive(false);
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
                    m_PlanetMarkers[i].gameObject.SetActive(false);
                    m_PlanetOrbits.Orbits[i].gameObject.SetActive(false);
                }
                m_StarData.PlanetAmount = 0;
            }
        }
        private float m_Timer;
        public void Update()
        {
            m_Time += UnityEngine.Time.deltaTime;
            m_Timer += UnityEngine.Time.deltaTime;
            for (int i = 0; i < m_StarData.PlanetAmount; i++)
            {
                Vector3 planetPosition = (float3)m_OrbitProperties[i].GetPoint(m_Time / 300 + m_PlanetDatas[i].Seed * 360);
                float distance = Vector3.Distance(m_Camera.transform.position, m_PlanetHolders[i].transform.position);

                PlanetHolder planetHolder = m_PlanetHolders[i];
                planetHolder.transform.position = planetPosition;
                if (planetHolder.Planet != null) planetHolder.Planet.transform.rotation = Quaternion.AngleAxis(m_Time * 30, Quaternion.AngleAxis(m_OrbitProperties[i].tiltZ, Vector3.forward) * Quaternion.AngleAxis((float)m_OrbitProperties[i].tiltX, Vector3.right) * Vector3.up);
                Vector3 markerPosition = m_Camera.WorldToScreenPoint(planetPosition);
                if (markerPosition.z < 0) markerPosition = Vector3.one * 20000;

                PlanetMarker planetMarker = m_PlanetMarkers[i];
                planetMarker.transform.position = markerPosition;
                Vector3 scale = distance < 2 ? Vector3.one : Vector3.one / Mathf.Sqrt(distance - 1);
                planetMarker.transform.localScale = scale;
                Color color = Color.white;
                color.a = (distance * 4 - 0.3f) < 0.001f ? 0 : (distance * 4 - 0.3f) > 1f ? 1f : (distance * 4 - 0.3f);
                if (m_Timer > 0.02f)
                {
                    planetMarker.SetColor(color);
                    
                }
            }
            if(m_Timer > 0.02f) m_Timer = 0;
        }
    }
}
