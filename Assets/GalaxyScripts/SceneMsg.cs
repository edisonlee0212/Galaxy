using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMsg : MonoBehaviour
{
    [SerializeField]
    Text m_InputText;

    private int m_StartAmount;

    public int StartAmount { get => m_StartAmount; set => m_StartAmount = value; }

    public void OnStart()
    {
        m_StartAmount = int.Parse(m_InputText.text);
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Galaxy");
    }

    public void OnAQuit()
    {
        Application.Quit();
    }
}
