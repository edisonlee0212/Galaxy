using UnityEngine;
using System;


public class OffsetTextureAnimate:MonoBehaviour{
    // Scroll main texture based on time
    //v1.01
    //-IOS compatible
    public float scrollSpeedX = 0.015f;
    public float scrollSpeedY = 0.015f;
    public float scrollSpeedXMaterial2 = 0.015f;
    public float scrollSpeedYMaterial2 = 0.015f;
    public void Update() {
        float offsetX = Time.time * scrollSpeedX%1;
        float offsetY = Time.time * scrollSpeedY%1;
        float offset2X = Time.time * scrollSpeedXMaterial2%1;
        float offset2Y = Time.time * scrollSpeedYMaterial2%1;
        GetComponent<Renderer>().material.SetTextureOffset ("_BumpMap", new Vector2(offsetX,offsetY));
        GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", new Vector2(offsetX,offsetY));
        if(GetComponent<Renderer>().materials.Length>1){
       		 GetComponent<Renderer>().materials[1].SetTextureOffset ("_MainTex", new Vector2(offset2X,offset2Y));
      		 GetComponent<Renderer>().materials[1].SetTextureOffset ("_BumpMap", new Vector2(offset2X,offset2Y));
        }
    }
}