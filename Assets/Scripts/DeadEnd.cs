using UnityEngine;
using System.Collections;

public class DeadEnd : MonoBehaviour {

    public float offset;
    public float scrollSpeed;
    Material mat;

    // Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        offset += scrollSpeed * Time.deltaTime;
        if (offset > 1)
            offset = 0;

        mat.mainTextureOffset = new Vector2(-offset, 0);
	}
}
