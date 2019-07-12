using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControler : MonoBehaviour
{
    private bool m_Active;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetChild(0).gameObject.SetActive(m_Active);
            m_Active = !m_Active;
        }
    }
}
