using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Galaxy
{
    public class PlanetSystemInfoWindow : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        private Vector2 m_StartPos, m_StartWNDPos;
        [SerializeField]
        private Text m_StarName, m_PlanetAmount, m_StarInfo;

        public void OnBeginDrag(PointerEventData eventData)
        {
            m_StartPos = eventData.position;
            m_StartWNDPos = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = (eventData.position - m_StartPos) + m_StartWNDPos;
            
        }

        public void ResetInfo(StarProperties starProperties, StarData starData)
        {
            m_PlanetAmount.text = starData.PlanetAmount.ToString();
            m_StarName.text = "Star No." + starProperties.Index.ToString();
            m_StarInfo.text = "Mass: \t" + starProperties.Mass.ToString() + "\nProportion: \t" + starProperties.Proportion.ToString();

        }
    }
}
