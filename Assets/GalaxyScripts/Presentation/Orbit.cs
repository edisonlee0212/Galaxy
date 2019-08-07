using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
namespace Galaxy
{
    [RequireComponent(typeof(LineRenderer))]
    public class Orbit : MonoBehaviour
    {
        private OrbitProperties m_Orbit;
        public OrbitProperties orbit { get => m_Orbit; set => m_Orbit = value; }

        private LineRenderer m_LineRenderer;

        protected void Awake()
        {
            m_LineRenderer = GetComponent<LineRenderer>();
        }

        public void CalculateEllipse(float offset = 10)
        {
            int pointAmount = (int)((m_Orbit.a + m_Orbit.b) / offset) + 10;
            Vector3[] points = new Vector3[pointAmount + 1];
            for(int i = 0; i < pointAmount; i++)
            {
                float angle = ((float)i / pointAmount) * 360 * Mathf.Deg2Rad;
                points[i] = (float3)orbit.GetPoint(angle, false);
                
            }
            points[pointAmount] = points[0];
            m_LineRenderer.positionCount = pointAmount + 1;
            m_LineRenderer.SetPositions(points);
        }

    }
}
