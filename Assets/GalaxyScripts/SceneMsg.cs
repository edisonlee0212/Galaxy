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
    
    [SerializeField]
    private Toggle m_ConnectAllStarsToggle;
    [SerializeField]
    private Toggle m_IndirectToggle;
    [SerializeField]
    private Toggle m_GPUFrustumCullingToggle;

    private int m_StartAmount;
    private int m_Seed;
    private bool m_EnableIndirect;
    private bool m_EnableGPUFrustumCulling;
    private bool m_ConnectAllStars;
    public int StartAmount { get => m_StartAmount;}
    public int Seed { get => m_Seed; }
    public bool ConnectAllStars { get => m_ConnectAllStars; }
    public bool EnableIndirect { get => m_EnableIndirect; }
    public bool EnableGPUFrustumCulling { get => m_EnableGPUFrustumCulling; }

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
        m_ConnectAllStars = m_ConnectAllStarsToggle.isOn;
        m_EnableIndirect = m_IndirectToggle.isOn;
        m_EnableGPUFrustumCulling = m_GPUFrustumCullingToggle.isOn;
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Galaxy");
    }

    public void OnAQuit()
    {
        Application.Quit();
    }
}
