using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
namespace Galaxy
{
    public class CameraControl : MonoBehaviour
    {
        #region Attributes
        [SerializeField]
        private GameObject m_Grid;

        private float m_CameraMoveSpeed;
        private float x, y;
        private bool m_InTransition;
        private float m_TransitionTime;
        private float m_Timer;
        private Vector3 m_PreviousCameraPosition;
        private Quaternion m_PreviousCameraRotation;
        private Vector3 m_TargetCameraPosition;
        private Quaternion m_TargetCameraRotation;
        private Vector3 m_PreviousPosition;
        private Quaternion m_PreviousRotation;
        private Vector3 m_TargetPosition;
        private Quaternion m_TargetRotation;
        private EntityManager m_EntityManager;
        private OrbitProperties m_CurrentPlanetOrbitProperties;
        private PlanetProperties m_CurrentPlanetProperties;
        private Transform m_CurrentSelectedPlanetHolder;
        #endregion

        #region Public

        private Camera m_Camera;
        private float m_DefaultCameraLookSpeed;
        private float m_DefaultCameraMoveSpeed;
        private ViewType m_ViewType;
        private float m_CenterDistance;
        private PlanetarySystem m_PlanetarySystem;
        private Entity m_PlanetEntity;
        public float DefaultCameraLookSpeed { get => m_DefaultCameraLookSpeed; set => m_DefaultCameraLookSpeed = value; }
        public float DefaultCameraMoveSpeed { get => m_DefaultCameraMoveSpeed; set => m_DefaultCameraMoveSpeed = value; }
        public Camera Camera { get => m_Camera; set => m_Camera = value; }
        public ViewType ViewType
        {
            get => m_ViewType;
            set
            {
                m_ViewType = value;
            }
        }
        public float CenterDistance { get => m_CenterDistance; set => m_CenterDistance = value; }
        public Entity PlanetEntity
        {
            get => m_PlanetEntity;
            set
            {
                m_PlanetEntity = value;
                if (m_PlanetEntity != Entity.Null)
                {
                    m_CurrentPlanetOrbitProperties = m_EntityManager.GetComponentData<OrbitProperties>(m_PlanetEntity);
                    m_CurrentPlanetProperties = m_EntityManager.GetComponentData<PlanetProperties>(m_PlanetEntity);
                }
            }
        }

        public PlanetarySystem PlanetarySystem { get => m_PlanetarySystem; set => m_PlanetarySystem = value; }
        public Transform CurrentSelectedPlanetHolder { get => m_CurrentSelectedPlanetHolder;
            set
            {
                if (m_CurrentSelectedPlanetHolder != value)
                {
                    m_CurrentSelectedPlanetHolder = value;
                    StarMarker.Target = m_CurrentSelectedPlanetHolder;
                }
            }
        }
        #endregion

        private void Start()
        {
            m_Grid = Instantiate(m_Grid);
            Camera = transform.GetChild(0).GetComponent<Camera>();
            m_DefaultCameraLookSpeed = 1;
            m_DefaultCameraMoveSpeed = 2f;
            m_ViewType = ViewType.Galaxy;
            m_CenterDistance = 10;
            y = 36.87f;
            m_EntityManager = World.Active.EntityManager;
        }

        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }

        public void StartTransition(float transitionTime, ViewType viewType)
        {
            m_ViewType = viewType;
            m_InTransition = true;
            m_TransitionTime = transitionTime;
            m_Timer = m_TransitionTime;
            m_PreviousCameraPosition = m_Camera.transform.localPosition;
            m_PreviousCameraRotation = m_Camera.transform.localRotation;
            if (viewType == ViewType.StarSystem)
            {
                m_TargetCameraPosition = new Vector3(0, 1.5f, -2f);
                m_PreviousPosition = transform.localPosition;
                m_TargetPosition = Vector3.zero;
                m_CenterDistance = 2.5f;
            }
            else if (viewType == ViewType.Planet)
            {
                m_TargetCameraPosition = new Vector3(0, 0.15f, -0.2f);
                m_PreviousPosition = transform.localPosition;
                m_TargetPosition = Vector3.zero;
                m_CenterDistance = 0.25f;
            }
            else
            {
                m_TargetCameraPosition = new Vector3(0, 3f, -4f);
                m_CenterDistance = 5f;
            }
            m_TargetCameraRotation = Quaternion.Euler(36.87f, 0, 0);
            y = 36.87f;
            x = 0;
        }

        protected void FixedUpdate()
        {
            
            if (m_ViewType == ViewType.StarSystem)
            {
                
                Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    GameObject gameObject = hit.collider.gameObject;
                    if (gameObject.CompareTag("PlanetHolder"))
                    {
                        CurrentSelectedPlanetHolder = gameObject.GetComponent<PlanetHolder>().transform;
                        
                    }
                }
            }
        }

        protected void Update()
        {
            Vector3 position = transform.position;
            if (!m_InTransition)
            {

                if (ViewType == ViewType.Galaxy)
                {
                    m_CenterDistance -= Input.GetAxis("Mouse ScrollWheel") * 0.5f;
                    m_CenterDistance -= Input.GetAxis("QE") * 3f;
                    m_CenterDistance = Mathf.Clamp(m_CenterDistance, 5f, 100f);
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        StarTransformSimulationSystem.FloatingOrigin.y -= Time.deltaTime * m_CenterDistance * 2 * m_CameraMoveSpeed;
                    }
                    else if (Input.GetKey(KeyCode.LeftShift))
                    {
                        StarTransformSimulationSystem.FloatingOrigin.y += Time.deltaTime * m_CenterDistance * 2 * m_CameraMoveSpeed;
                    }
                    m_CameraMoveSpeed = DefaultCameraMoveSpeed;
                    Vector3 vertical = m_Camera.transform.forward;
                    vertical.y = 0;
                    Vector3 horizonal = m_Camera.transform.right;
                    horizonal.y = 0;

                    StarTransformSimulationSystem.FloatingOrigin += (float3)vertical.normalized * m_CameraMoveSpeed * Input.GetAxis("Vertical") * m_CenterDistance / 40;
                    StarTransformSimulationSystem.FloatingOrigin += (float3)horizonal.normalized * m_CameraMoveSpeed * Input.GetAxis("Horizontal") * m_CenterDistance / 40;

                    if (Input.GetMouseButton(1))
                    {
                        x += Input.GetAxis("Mouse X") * 0.5f;
                        y -= Input.GetAxis("Mouse Y") * 0.5f;
                    }
                    y = ClampAngle(y, -90, 90);
                    Quaternion rotation = Quaternion.Euler(y, x, 0);
                    Vector3 vTemp = new Vector3(0.0f, 0.0f, -m_CenterDistance);
                    Camera.transform.localPosition = rotation * vTemp;
                    Camera.transform.localRotation = rotation;
                    int distance = 80;
                    m_Grid.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_LineColor", Color.white * (distance - m_CenterDistance >= 0 ? (distance - m_CenterDistance) / 200 : 0));
                    m_Grid.transform.GetChild(1).GetComponent<MeshRenderer>().material.SetColor("_LineColor", Color.white * (distance - m_CenterDistance >= 0 ? (distance - m_CenterDistance) / 200 : 0));

                }
                else
                {
                    m_CenterDistance -= Input.GetAxis("Vertical") * 0.1f;
                    m_CenterDistance -= Input.GetAxis("Mouse ScrollWheel") * 0.1f;
                    if (m_ViewType == ViewType.StarSystem)
                    {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            StartTransition(0.5f, ViewType.Galaxy);
                            CurrentSelectedPlanetHolder = null;
                            return;
                        }
                        else if (CurrentSelectedPlanetHolder != null && Input.GetKeyDown(KeyCode.F))
                        {
                            transform.SetParent(CurrentSelectedPlanetHolder);
                            CurrentSelectedPlanetHolder = null;
                            StartTransition(0.5f, ViewType.Planet);
                            return;
                        }
                        m_CenterDistance = Mathf.Clamp(m_CenterDistance, 0.4f, 5);
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            transform.SetParent(null);
                            CurrentSelectedPlanetHolder = null;
                            StartTransition(0.5f, ViewType.StarSystem);
                            return;
                        }
                        m_CenterDistance = Mathf.Clamp(m_CenterDistance, 0.02f, 1);
                    }
                    if (Input.GetMouseButton(1))
                    {
                        x += Input.GetAxis("Mouse X") * 0.5f;
                        y -= Input.GetAxis("Mouse Y") * 0.5f;
                    }
                    y = ClampAngle(y, -90, 90);
                    Quaternion rotation = Quaternion.Euler(y, x, 0);
                    Vector3 vTemp = new Vector3(0.0f, 0.0f, -m_CenterDistance);
                    Camera.transform.localPosition = rotation * vTemp;
                    Camera.transform.localRotation = rotation;
                }

            }
            else
            {
                m_Timer -= Time.deltaTime;
                if (m_Timer < 0)
                {
                    m_Timer = 0;
                    m_InTransition = false;
                    if (ViewType == ViewType.Galaxy)
                    {
                        StarTransformSimulationSystem.FollowedStar = Entity.Null;
                        m_PlanetarySystem.Reset(Entity.Null);
                        SelectionSystem.ViewType = ViewType.Galaxy;
                    }
                }
                float t = Mathf.Pow((m_TransitionTime - m_Timer) / m_TransitionTime, 0.25f);
                m_Camera.transform.localPosition = Vector3.Lerp(m_PreviousCameraPosition, m_TargetCameraPosition, t);
                m_Camera.transform.localRotation = Quaternion.Lerp(m_PreviousCameraRotation, m_TargetCameraRotation, t);

                Color c = Color.white;
                if (ViewType == ViewType.Galaxy) c.a = 0.2f * (1 - m_Timer / m_TransitionTime);
                else
                {
                    transform.localPosition = Vector3.Lerp(m_PreviousPosition, m_TargetPosition, t);
                    c.a = 0;
                }
                transform.GetChild(1).GetComponent<MeshRenderer>().material.SetColor("_TintColor", c);
                m_Grid.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_LineColor", c * 0.5f);
                m_Grid.transform.GetChild(1).GetComponent<MeshRenderer>().material.SetColor("_LineColor", c * 0.5f);
            }
            Vector3 gridPos = m_Grid.transform.position;
            gridPos.y = position.y - 0.1f;
            m_Grid.transform.position = gridPos;
        }
    }
}
