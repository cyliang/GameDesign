using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;

	PlayerScript playerScript;
	Vector3 offset;
	float angle = 0;

	void Start () {
		offset = transform.position - player.transform.position;
		playerScript = player.GetComponent<PlayerScript> ();
	}

	void Update() {
		if (Input.GetKey (KeyCode.Z)) {
			angle -= 1;
		} else if (Input.GetKey (KeyCode.C)) {
			angle += 1;
		}
	}

	void LateUpdate () {
		transform.position = player.transform.position + offset;
		transform.RotateAround (player.transform.position, Vector3.up, angle);
		transform.LookAt (player.transform.position);
		playerScript.direction = (player.transform.position - transform.position).normalized;
	}
}
