using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
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
    private void RotateCamera()
    {
        rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.rotation = rotation;
    }
}
