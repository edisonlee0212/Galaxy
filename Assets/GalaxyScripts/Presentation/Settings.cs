using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Galaxy {
    public class Settings : MonoBehaviour
    {
        private bool m_Active;

        GameObject m_List;

        public void Init(GalaxyPatternProperties densityWaveProperties, float timeSpeed, bool displayOrbit)
        {
            m_Active = true;
            m_List = transform.GetChild(1).gameObject;
            m_List.transform.GetChild(0).GetComponent<Toggle>().isOn = displayOrbit;
            m_List.transform.GetChild(1).GetComponentInChildren<Slider>().value = densityWaveProperties.DiskSpeed;
            m_List.transform.GetChild(2).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreSpeed;
            m_List.transform.GetChild(3).GetComponentInChildren<Slider>().value = densityWaveProperties.CenterSpeed;
            m_List.transform.GetChild(4).GetComponentInChildren<Slider>().value = densityWaveProperties.DiskTiltX;
            m_List.transform.GetChild(5).GetComponentInChildren<Slider>().value = densityWaveProperties.DiskTiltZ;
            m_List.transform.GetChild(6).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreTiltX;
            m_List.transform.GetChild(7).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreTiltZ;
            m_List.transform.GetChild(8).GetComponentInChildren<Slider>().value = densityWaveProperties.CenterTiltX;
            m_List.transform.GetChild(9).GetComponentInChildren<Slider>().value = densityWaveProperties.CenterTiltZ;
            m_List.transform.GetChild(10).GetComponentInChildren<Slider>().value = densityWaveProperties.DiskAB;
            m_List.transform.GetChild(11).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreProportion;
            m_List.transform.GetChild(12).GetComponentInChildren<Slider>().value = densityWaveProperties.CenterAB;
            m_List.transform.GetChild(13).GetComponentInChildren<Slider>().value = densityWaveProperties.DiskEccentricity;
            m_List.transform.GetChild(14).GetComponentInChildren<Slider>().value = densityWaveProperties.CoreEccentricity;
            m_List.transform.GetChild(15).GetComponentInChildren<Slider>().value = densityWaveProperties.CenterEccentricity;
            m_List.transform.GetChild(16).GetComponentInChildren<Slider>().value = densityWaveProperties.Rotation;
            m_List.transform.GetChild(17).GetComponentInChildren<Slider>().value = timeSpeed;
            
            transform.GetChild(1).gameObject.SetActive(m_Active);
            transform.GetChild(0).gameObject.SetActive(m_Active);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                m_Active = !m_Active;
                transform.GetChild(0).gameObject.SetActive(m_Active);
                transform.GetChild(1).gameObject.SetActive(m_Active);
            }
        }
    }
}
