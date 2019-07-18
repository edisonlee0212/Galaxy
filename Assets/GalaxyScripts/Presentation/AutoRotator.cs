using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotator : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;

    // Update is called once per frame
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, timer * m_Speed, 0);
    }
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
