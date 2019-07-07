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
        private float lookSpeed;
        [SerializeField]
        private float moveSpeed;

        private bool isRotating;    // Is the camera being rotated?
        private bool isPanning;

        private float xAngle, yAngle;
        private Quaternion rotation;
        private float m_Timer;
        private bool m_StartTransition;
        private float m_TransitionTime;
        private Vector3 m_PreviousCameraControlPosition;
        private Quaternion m_PreviousCameraControlRotation;
        private Vector3 m_PreviousCameraLocalPosition;
        private Quaternion m_PreviousCameraLocalRotation;
        private GameObject m_FollowedGameObject;
        private ViewType m_ViewType;
        public float TransitionTimer { get => m_TransitionTime; set => m_TransitionTime = value; }
        public GameObject FollowedGameObject { get => m_FollowedGameObject; }

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

        public void Follow(GameObject gameObject, float transitionTime = -1)
        {
            UnFollow();
            m_StartTransition = true;
            if (transitionTime != -1) m_TransitionTime = transitionTime;
            else m_TransitionTime = Mathf.Sqrt(Vector3.Distance(gameObject.transform.position, transform.position)) / 3;
            //Debug.Log(gameObject.transform.position);
            //Debug.Log(transform.TransformPoint(transform.position));
            //Debug.Log(Vector3.Distance(gameObject.transform.position, transform.position));
            m_Timer = m_TransitionTime;
            m_FollowedGameObject = gameObject;
            m_PreviousCameraControlPosition = transform.position;
            m_PreviousCameraControlRotation = transform.rotation;
            m_PreviousCameraLocalPosition = m_Camera.transform.localPosition;
            m_PreviousCameraLocalRotation = m_Camera.transform.localRotation;
        }

        public void UnFollow()
        {
            transform.SetParent(null);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(1)) isRotating = true;
            if (Input.GetMouseButtonUp(1)) isRotating = false;
            if (Input.GetMouseButtonDown(2)) isPanning = true;
            if (Input.GetMouseButtonUp(2)) isPanning = false;
            if (isRotating)
            {
                m_Camera.transform.Rotate(-Input.GetAxis("Mouse Y") * lookSpeed, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }

            if (isPanning)
            {
                m_Camera.transform.localPosition -= m_Camera.transform.right * moveSpeed * Input.GetAxis("Mouse X") * lookSpeed;
                m_Camera.transform.localPosition -= m_Camera.transform.up * moveSpeed * Input.GetAxis("Mouse Y") * lookSpeed;
            }
            m_Camera.transform.localPosition += m_Camera.transform.forward * moveSpeed * Input.GetAxis("Vertical");
            m_Camera.transform.localPosition += m_Camera.transform.right * moveSpeed * Input.GetAxis("Horizontal");
            m_Camera.transform.localPosition += m_Camera.transform.forward * moveSpeed * Input.GetAxis("Mouse ScrollWheel");
        }

        private void FixedUpdate()
        {
            if (m_StartTransition) MoveToGameObject();
        }

        private void MoveToGameObject()
        {
            m_Timer -= Time.fixedDeltaTime;
            if (m_Timer > 0)
            {
                float t = (1 - m_Timer / m_TransitionTime);
                transform.position = Vector3.Slerp(m_PreviousCameraControlPosition, m_FollowedGameObject.transform.position, t);
                transform.rotation = Quaternion.Slerp(m_PreviousCameraControlRotation, m_FollowedGameObject.transform.rotation, t);
                m_Camera.transform.localPosition = Vector3.Slerp(m_PreviousCameraLocalPosition, new Vector3(0, 0, -30), t);
                m_Camera.transform.localRotation = Quaternion.Slerp(m_PreviousCameraLocalRotation, Quaternion.Euler(0, 0, 0), t);
            }
            else
            {
                m_StartTransition = false;
                m_Timer = 0;
                m_TransitionTime = 0;
                transform.SetParent(m_FollowedGameObject.transform);
                transform.localPosition = Vector3.zero;
            }
        }
    }
}
