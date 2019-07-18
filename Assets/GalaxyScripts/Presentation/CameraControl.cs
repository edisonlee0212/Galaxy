using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
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
        private Vector3 m_PreviousPosition;
        private Quaternion m_PreviousRotation;
        private Vector3 m_TargetPosition;
        private Quaternion m_TargetRotation;
        #endregion

        #region Public
        private Camera m_Camera;
        private float m_DefaultCameraLookSpeed;
        private float m_DefaultCameraMoveSpeed;
        private ViewType m_ViewType;
        private float m_CenterDistance;
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
        #endregion

        private void Start()
        {
            Camera = transform.GetChild(0).GetComponent<Camera>();
            m_DefaultCameraLookSpeed = 1;
            m_DefaultCameraMoveSpeed = 0.5f;
            m_ViewType = ViewType.Galaxy;
            m_CenterDistance = 10;
            y = 36.87f;
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
            ViewType = viewType;
            m_InTransition = true;
            m_TransitionTime = transitionTime;
            m_Timer = m_TransitionTime;
            m_PreviousPosition = m_Camera.transform.localPosition;
            m_PreviousRotation = m_Camera.transform.localRotation;
            if (viewType == ViewType.StarSystem)
            {
                m_TargetPosition = new Vector3(0, 1.5f, -2f);
                m_CenterDistance = 2.5f;
            }
            else if (viewType == ViewType.Planet)
            {
                m_TargetPosition = new Vector3(0, 0.15f, -0.2f);
                m_CenterDistance = 0.25f;
            }else
            {
                m_TargetPosition = new Vector3(0, 3f, -4f);
                m_CenterDistance = 5f;
            }
            m_TargetRotation = Quaternion.Euler(36.87f, 0, 0);
            y = 36.87f;
            x = 0;
        }

        void Update()
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
                        position.y -= Time.deltaTime * m_CenterDistance * 2;
                    }
                    else if (Input.GetKey(KeyCode.LeftShift))
                    {
                        position.y += Time.deltaTime * m_CenterDistance * 2;
                    }
                    m_CameraMoveSpeed = DefaultCameraMoveSpeed;
                    Vector3 vertical = m_Camera.transform.forward;
                    vertical.y = 0;
                    Vector3 horizonal = m_Camera.transform.right;
                    horizonal.y = 0;
                    
                    position += vertical.normalized * m_CameraMoveSpeed * Input.GetAxis("Vertical") * m_CenterDistance / 40;
                    position += horizonal.normalized * m_CameraMoveSpeed * Input.GetAxis("Horizontal") * m_CenterDistance / 40;
                    transform.position = position;
                    
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
                    m_Grid.GetComponent<MeshRenderer>().material.SetColor("_LineColor", Color.white * (40 - m_CenterDistance >= 0 ? (40 - m_CenterDistance) / 100 : 0));

                }
                else
                {
                    m_CenterDistance -= Input.GetAxis("Vertical") * 0.1f;
                    m_CenterDistance -= Input.GetAxis("Mouse ScrollWheel") * 0.1f;
                    if (m_ViewType == ViewType.StarSystem) m_CenterDistance = Mathf.Clamp(m_CenterDistance, 0.4f, 5);
                    else m_CenterDistance = Mathf.Clamp(m_CenterDistance, 0.05f, 1);
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
                }
                Color c = Color.white;
                //if (ViewType == ViewType.StarSystem) c.a = 0.2f * m_Timer / m_TransitionTime;
                if (ViewType == ViewType.Galaxy) c.a = 0.2f * (1 - m_Timer / m_TransitionTime);
                else c.a = 0;
                transform.GetChild(1).GetComponent<MeshRenderer>().material.SetColor("_TintColor", c);
                m_Grid.GetComponent<MeshRenderer>().material.SetColor("_LineColor", c * 0.5f);
                float t = Mathf.Pow((m_TransitionTime - m_Timer) / m_TransitionTime, 0.25f);
                m_Camera.transform.localPosition = Vector3.Lerp(m_PreviousPosition, m_TargetPosition, t);
                m_Camera.transform.localRotation = Quaternion.Lerp(m_PreviousRotation, m_TargetRotation, t);
            }
            Vector3 gridPos = m_Grid.transform.position;
            gridPos.y = position.y - 0.1f;
            m_Grid.transform.position = gridPos;
        }
    }
}
