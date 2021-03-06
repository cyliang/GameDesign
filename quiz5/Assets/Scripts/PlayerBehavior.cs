﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public float moveSpeed, jumpSpeed;
	public float bulletSpeed;
	public GameObject hand;
	public GameObject bullet;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;

		if (Input.GetKeyDown (KeyCode.Space) && rb.velocity.y == 0f) {
			rb.velocity += Vector2.up * jumpSpeed;
		}

		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = 0;
		transform.rotation = Quaternion.Euler(
			mouse.x >= transform.position.x ?
				Vector3.zero :
				Vector3.up * 180
		);

		Vector3 handPivot = hand.transform.position;
		hand.transform.rotation = Quaternion.FromToRotation (Vector3.right, mouse - handPivot);

		if (Input.GetMouseButtonDown (0)) {
			GameObject newBullet = Instantiate (bullet);
			newBullet.transform.position = handPivot + hand.transform.rotation * Vector3.right * 0.8f;
			newBullet.GetComponent<Rigidbody2D> ().velocity = hand.transform.rotation * Vector3.right * bulletSpeed;
		}
	}
}
