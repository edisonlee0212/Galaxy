using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
namespace Galaxy
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField]
        private Camera m_Camera;

        [SerializeField]
        private float m_DefaultCameraLookSpeed;
        [SerializeField]
        private float m_DefaultCameraMoveSpeed;

        private bool isRotating;    // Is the camera being rotated?
        private bool isPanning;
        private EntityManager m_EntityManager;
        private Entity m_FollowedEntity;
        private float xAngle, yAngle;
        private Quaternion rotation;
        private float m_Timer;
        private bool m_InTransition;
        private float m_TransitionTime;
        private Vector3 m_PreviousCameraControlPosition;
        private Quaternion m_PreviousCameraControlRotation;
        private Vector3 m_PreviousCameraLocalPosition;
        private Quaternion m_PreviousCameraLocalRotation;
        private ViewType m_ViewType;
        public float TransitionTimer { get => m_TransitionTime; set => m_TransitionTime = value; }
        public float DefaultCameraLookSpeed { get => m_DefaultCameraLookSpeed; set => m_DefaultCameraLookSpeed = value; }
        public float DefaultCameraMoveSpeed { get => m_DefaultCameraMoveSpeed; set => m_DefaultCameraMoveSpeed = value; }

        public void SetCameraRotationX(float x)
        {
            xAngle = x;
            RotateCamera();
        }
        public void SetCameraRotationY(float y)
        {
            yAngle = y;
            RotateCamera();
        }

        public void SetCameraFocus(float z)
        {
            m_Camera.transform.localPosition = new Vector3(0, 0, z);
        }

        private void RotateCamera()
        {
            rotation = Quaternion.Euler(xAngle, yAngle, 0);
            transform.rotation = rotation;
        }

        public void Follow(Entity entity, float transitionTime = -1)
        {
            UnFollow();
            m_FollowedEntity = entity;
            m_InTransition = true;
            transform.position = m_Camera.transform.position;
            transform.rotation = m_Camera.transform.rotation;
            if (transitionTime != -1) m_TransitionTime = transitionTime;
            else m_TransitionTime = Mathf.Sqrt(Vector3.Distance(m_EntityManager.GetComponentData<Translation>(m_FollowedEntity).Value, m_Camera.transform.position)) / 10;
            m_Timer = m_TransitionTime;
            
            m_PreviousCameraControlPosition = transform.position;
            m_PreviousCameraControlRotation = transform.rotation;
            m_PreviousCameraLocalPosition = m_Camera.transform.localPosition;
            m_PreviousCameraLocalRotation = m_Camera.transform.localRotation;
        }

        public void Start()
        {
            m_EntityManager = World.Active.EntityManager;
            m_FollowedEntity = Entity.Null;
        }

        public void UnFollow()
        {
            m_FollowedEntity = Entity.Null;
        }
        float moveSpeed;
        void Update()
        {
            if (m_FollowedEntity != Entity.Null && !m_InTransition)
            {
                var position = m_EntityManager.GetComponentData<LocalToWorld>(m_FollowedEntity).Value.c3;

                transform.position = new Vector3(position.x, position.y, position.z);
                //m_Camera.transform.LookAt(position);
            }

            if (Input.GetKey(KeyCode.LeftControl)) moveSpeed = 0.01f * DefaultCameraMoveSpeed;
            else if (Input.GetKey(KeyCode.LeftShift)) moveSpeed = 2 * DefaultCameraMoveSpeed;
            else moveSpeed = DefaultCameraMoveSpeed;
            if (Input.GetMouseButtonDown(1)) isRotating = true;
            if (Input.GetMouseButtonUp(1)) isRotating = false;
            if (Input.GetMouseButtonDown(2)) isPanning = true;
            if (Input.GetMouseButtonUp(2)) isPanning = false;
            if (isRotating)
            {
                m_Camera.transform.Rotate(-Input.GetAxis("Mouse Y") * DefaultCameraLookSpeed, Input.GetAxis("Mouse X") * DefaultCameraLookSpeed, 0);
            }

            if (isPanning)
            {
                m_Camera.transform.localPosition -= m_Camera.transform.right * moveSpeed * Input.GetAxis("Mouse X") * DefaultCameraLookSpeed;
                m_Camera.transform.localPosition -= m_Camera.transform.up * moveSpeed * Input.GetAxis("Mouse Y") * DefaultCameraLookSpeed;
            }
            m_Camera.transform.localPosition += m_Camera.transform.forward * moveSpeed * Input.GetAxis("Vertical");
            m_Camera.transform.localPosition += m_Camera.transform.right * moveSpeed * Input.GetAxis("Horizontal");
            m_Camera.transform.localPosition += m_Camera.transform.forward * moveSpeed * Input.GetAxis("Mouse ScrollWheel") * 150;

            
        }

        private void FixedUpdate()
        {
            if (m_InTransition) MoveToGameObject();
        }

        private void MoveToGameObject()
        {
            if (m_FollowedEntity != Entity.Null)
            {
                if (m_Timer > 0)
                {
                    m_Timer -= Time.fixedDeltaTime;
                    float t = (1 - m_Timer / m_TransitionTime);
                    transform.position = Vector3.Slerp(m_PreviousCameraControlPosition, m_EntityManager.GetComponentData<Translation>(m_FollowedEntity).Value, t);
                    transform.rotation = Quaternion.Slerp(m_PreviousCameraControlRotation, m_EntityManager.GetComponentData<Rotation>(m_FollowedEntity).Value, t);
                    m_Camera.transform.localPosition = Vector3.Slerp(m_PreviousCameraLocalPosition, new Vector3(0, 0, -30), t);
                    m_Camera.transform.localRotation = Quaternion.Slerp(m_PreviousCameraLocalRotation, Quaternion.Euler(0, 0, 0), t);
                }
                else
                {
                    m_InTransition = false;
                    m_Timer = 0;
                    m_TransitionTime = 0;
                }
            }
        }
    }
}
