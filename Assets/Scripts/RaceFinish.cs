using UnityEngine;
using System.Collections;

public class RaceFinish : MonoBehaviour {

	public float offset;
    public float scrollSpeed;
    Material mat;

    // Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
        //GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x, 1.0f);
	}
	
	// Update is called once per frame
    void Update() {
        offset += scrollSpeed * Time.deltaTime;
        if (offset > 1)
            offset = 0;

        mat.mainTextureOffset = new Vector2(-offset, 0);
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            GameManager.instance.aiFinishedAlready++;
        }

        if (col.tag == "RealPlayer") {
            GameManager.instance.PlayerFinishedRace();
        }


            
    }
}
