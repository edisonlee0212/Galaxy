using UnityEngine;
using System;


public class flipTexture:MonoBehaviour
{
    
    public void Start() {
    
    GetComponent<Renderer>().material.SetTextureScale ("_MainTex", new Vector2(-1.0f,-1.0f));
    
    }
}