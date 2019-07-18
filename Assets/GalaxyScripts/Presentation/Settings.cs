using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Galaxy {
    public class Settings : MonoBehaviour
    {
        private bool m_Active;

        Canvas m_Canvas;

        public void Init(GalaxyPatternProperties densityWaveProperties, float timeSpeed, bool displayOrbit)
        {
            m_Canvas = transform.GetComponentInChildren<Canvas>();
            m_Canvas.transform.GetChild(0).GetComponent<Toggle>().isOn = displayOrbit;
            m_Canvas.transform.GetChild(1).GetComponentInChildren<Slider>().value = densityWaveProperties.DiskSpeed;
            m_Canvas.transform.GetChild(2).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreSpeed;
            m_Canvas.transform.GetChild(3).GetComponentInChildren<Slider>().value = densityWaveProperties.CenterSpeed;
            m_Canvas.transform.GetChild(4).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreTiltX;
            m_Canvas.transform.GetChild(5).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreTiltZ;
            m_Canvas.transform.GetChild(6).GetComponentInChildren<Slider>().value = densityWaveProperties.CenterTiltX;
            m_Canvas.transform.GetChild(7).GetComponentInChildren<Slider>().value = densityWaveProperties.CenterTiltZ;
            m_Canvas.transform.GetChild(8).GetComponentInChildren<Slider>().value = densityWaveProperties.MinimumRadius;
            m_Canvas.transform.GetChild(9).GetComponentInChildren<Slider>().value = densityWaveProperties.DiskA;
            m_Canvas.transform.GetChild(10).GetComponentInChildren<Slider>().value = densityWaveProperties.DiskB;
            m_Canvas.transform.GetChild(11).GetComponentInChildren<Slider>().value = densityWaveProperties.Rotation;
            m_Canvas.transform.GetChild(12).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreProportion;
            m_Canvas.transform.GetChild(13).GetComponentInChildren<Slider>().value = timeSpeed;
            m_Canvas.transform.GetChild(14).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreEccentricity;
            transform.GetChild(0).gameObject.SetActive(m_Active);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                m_Active = !m_Active;
                transform.GetChild(0).gameObject.SetActive(m_Active);
                
            }
        }
    }
}
