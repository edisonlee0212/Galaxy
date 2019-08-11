using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace PlanetGen
{
    public class ColorPicker : MonoBehaviour, IPointerDownHandler
    {
        private Color _col;
        public Color col
        {
            get
            {
                return _col;
            }
            set
            {
                _col = value;
                panel.color = _col;
            }
        }
        
        public Slider sat;
        public Image panel;
        public void OnPointerDown(PointerEventData ped)
        {
            Vector2 localCursor;
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), ped.position, ped.pressEventCamera, out localCursor)) return;
            Rect rect = gameObject.GetComponent<RectTransform>().rect;
            col = Color.HSVToRGB(localCursor.x/rect.width, sat.value, localCursor.y/rect.height);
        }
        public void ChangeSaturation(float t)
        {
            GetComponent<RawImage>().material.SetFloat("_Saturation", t);
        }
    }
}
