using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingArea : MonoBehaviour {

    public static Texture2D texture { get; private set; }

    public static byte[] GetAllTextureData() {
        return texture.GetRawTextureData();
    }

	// Use this for initialization
	void Start () {
        PrepareCanvas();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PrepareCanvas() {
        //loads the texture in memory
        texture = (Texture2D)GameObject.Instantiate(GetComponent<Renderer>().material.mainTexture);
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    private void SetAllTextureData(byte[] textureData) {
        texture.LoadRawTextureData(textureData);
        texture.Apply();
    }
}
