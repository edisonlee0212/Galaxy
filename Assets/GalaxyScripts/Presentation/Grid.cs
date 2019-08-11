using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Galaxy;
public class Grid : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = (float)- StarTransformSimulationSystem.FloatingOrigin.x;
        position.z = (float)- StarTransformSimulationSystem.FloatingOrigin.z;
        transform.position = position;
    }
}
