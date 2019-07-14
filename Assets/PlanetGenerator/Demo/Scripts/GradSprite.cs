using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradSprite : MonoBehaviour {
    public Gradient gradient;
    public Texture2D tex;
	// Use this for initialization
	void Start () {
        tex = new Texture2D(64, 1);
        for(int x = 0; x < 64; x++)
        {
            tex.SetPixel(x, 1, gradient.Evaluate(x / 64.0f));
        }
        tex.Apply();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(tex, new Rect(0, 0, 64, 1), Vector2.zero);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
