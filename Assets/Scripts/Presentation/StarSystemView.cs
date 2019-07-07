using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Galaxy
{
    public class StarSystemView : MonoBehaviour
    {
        [SerializeField]
        private Camera m_Camera;
        [SerializeField]
        private float lookSpeed;
        [SerializeField]
        private float moveSpeed;

        private bool isRotating;    // Is the camera being rotated?
        private bool isPanning;


        // Update is called once per frame
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
                m_Camera.transform.position -= m_Camera.transform.right * moveSpeed * Input.GetAxis("Mouse X") * lookSpeed;
                m_Camera.transform.position -= m_Camera.transform.up * moveSpeed * Input.GetAxis("Mouse Y") * lookSpeed;
            }
            m_Camera.transform.position += m_Camera.transform.forward * moveSpeed * Input.GetAxis("Vertical");
            m_Camera.transform.position += m_Camera.transform.right * moveSpeed * Input.GetAxis("Horizontal");
            m_Camera.transform.position += m_Camera.transform.forward * moveSpeed * Input.GetAxis("Mouse ScrollWheel") * 100;
        }
    }
}
