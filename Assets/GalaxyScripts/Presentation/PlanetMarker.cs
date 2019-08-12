using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMarker : MonoBehaviour
{
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private TextMeshProUGUI m_PlanetNameText;
    [SerializeField]
    private TextMeshProUGUI m_PlanetTypeText;
    [SerializeField]
    private TextMeshProUGUI m_PlanetSizeText;

    public Image Image { get => m_Image; set => m_Image = value; }
    public TextMeshProUGUI PlanetNameText { get => m_PlanetNameText; set => m_PlanetNameText = value; }
    public TextMeshProUGUI PlanetTypeText { get => m_PlanetTypeText; set => m_PlanetTypeText = value; }
    public TextMeshProUGUI PlanetSizeText { get => m_PlanetSizeText; set => m_PlanetSizeText = value; }

    public void SetColor(Color color)
    {
        m_Image.color = color;
        m_PlanetNameText.color = color;
        m_PlanetTypeText.color = color;
        m_PlanetSizeText.color = color;
    }
}
