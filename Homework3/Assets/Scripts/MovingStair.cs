using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStair : MonoBehaviour {

	public float minX, maxX;
	public float speed;

	int toward;
	Rigidbody2D standing;

	// Use this for initialization
	void Start () {
		toward = 1;
		standing = null;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x + toward * speed * Time.deltaTime, minX, maxX);
		Vector3 movement = pos - transform.position;
		transform.position = pos;

		if (pos.x == minX && toward == -1 ||
		    pos.x == maxX && toward == 1) {

			toward *= -1;
		}

		if (standing != null) {
			standing.position += (Vector2) movement;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			standing = other.rigidbody;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			standing = null;
		}
	}
}
