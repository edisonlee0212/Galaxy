using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    GameObject m_Camera;
    private float xAngle, yAngle;
    private Quaternion rotation;
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
}
