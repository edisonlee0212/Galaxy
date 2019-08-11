using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMarker : MonoBehaviour
{
    private Image m_Image;

    public Image Image { get => m_Image; set => m_Image = value; }

    public void Awake()
    {
        m_Image = GetComponent<Image>();
    }
}
