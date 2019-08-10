using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMsg : MonoBehaviour
{
    [SerializeField]
    Text m_InputAmount;
    [SerializeField]
    Text m_InputSeed;
    private int m_StartAmount;
    private int m_Seed;
    public int StartAmount { get => m_StartAmount; set => m_StartAmount = value; }
    public int Seed { get => m_Seed; set => m_Seed = value; }

    public void OnStart()
    {
        if(!int.TryParse(m_InputAmount.text, out m_StartAmount)){
            m_StartAmount = 6000;
        }
        if (!int.TryParse(m_InputSeed.text, out m_Seed))
        {
            m_Seed = 0;
        }
        if (m_StartAmount > ushort.MaxValue) m_StartAmount = ushort.MaxValue;
        if (m_StartAmount < 1) m_StartAmount = 1;
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Galaxy");
    }

    public void OnAQuit()
    {
        Application.Quit();
    }
}
