using UnityEngine;


public class CameraFacingBillboard : MonoBehaviour
{
    void LateUpdate()
    {
	transform.LookAt(Camera.main.transform,transform.up);
    }
}