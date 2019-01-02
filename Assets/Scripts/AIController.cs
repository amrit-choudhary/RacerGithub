using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    public GameObject waypoint;
    public GameObject body;
    Vector3 startPosition;
    Quaternion startRotation;

    // Use this for initialization
	void Start () {
        waypoint.transform.position = transform.position + transform.forward * 100;
        int rand = Random.Range(0, GameManager.instance.AIColors.Length);
        body.GetComponent<Renderer>().material.color = GameManager.instance.AIColors[rand];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Waypoint") {
            if (col.gameObject.GetComponent<Waypoint>().nextWaypoint.position != null)
                waypoint.transform.position = col.gameObject.GetComponent<Waypoint>().nextWaypoint.position;
        }
    }
}
