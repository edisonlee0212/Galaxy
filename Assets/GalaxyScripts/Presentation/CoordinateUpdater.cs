using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Galaxy
{
    public class CoordinateUpdater : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_TextMeshProUGUI;
        protected void FixedUpdate()
        {
            m_TextMeshProUGUI.text = "X-[" + (StarTransformSimulationSystem.FloatingOrigin.x.ToString()) + "]\nY-[" + (StarTransformSimulationSystem.FloatingOrigin.y.ToString()) + "]\nZ-[" + (StarTransformSimulationSystem.FloatingOrigin.z.ToString()) + "]";
        }
    }
}
