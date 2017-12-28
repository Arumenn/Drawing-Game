using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrush : MonoBehaviour {

    public int brushSize = 10;
    public Color brushColor = Color.red;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                var zone = hit.collider.GetComponent<DrawingArea>();
                if (zone != null) {
                    Debug.Log(hit.textureCoord);
                    Debug.Log(hit.point);

                    Renderer rend = hit.transform.GetComponent<Renderer>();
                    MeshCollider meshCollider = hit.collider as MeshCollider;

                    if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null) {
                        return;
                    }

                    Texture2D texture = rend.material.mainTexture as Texture2D;
                    Vector2 pixel1UV = hit.textureCoord;
                    pixel1UV.x *= texture.width;
                    pixel1UV.y *= texture.height;

                    //brush
                    for (int x = -brushSize; x < brushSize; x++) {
                        for (int y = -brushSize; y < brushSize; y++) {
                            DrawingArea.texture.SetPixel((int)pixel1UV.x + x, (int)pixel1UV.y + y, brushColor);
                        }
                    }
                    DrawingArea.texture.Apply();
                }
            }
        }
	}
}
