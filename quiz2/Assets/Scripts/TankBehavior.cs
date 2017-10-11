using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankBehavior : MonoBehaviour {

	public float cameraHeight = 1f;
	public float cameraDistance = 1f;
	public float movingForce = 1f;
	public float breakForce = 1f;
	public float rotateSpeed = 30f;

	public MyButton forwardBtn, breakBtn, rightBtn, leftBtn;

	private Transform camTrans;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		camTrans = Camera.main.transform;
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) || breakBtn.isPressed) {
			Break ();
		} else {
			Move (Mathf.Clamp(
				Input.GetAxis ("Vertical") +
				(forwardBtn.isPressed ? 1f : 0),
				-1f, 1f
			));
			Rotate (Mathf.Clamp(
				Input.GetAxis ("Horizontal") +
				(rightBtn.isPressed ? 1f : 0) +
				(leftBtn.isPressed ? -1f : 0),
				-1f, 1f
			));
		}
	}

	void LateUpdate() {
		Vector3 camPos = (transform.position - transform.forward * cameraDistance);
		camPos.y = cameraHeight;
		Vector3 lookAt = transform.position;
		lookAt.y = cameraHeight;

		camTrans.position = camPos;
		camTrans.LookAt (lookAt, Vector3.up);
	}

	public void Move(float mag) {
		rigidBody.AddForce (
			transform.forward * mag * movingForce * Time.deltaTime
		);
	}

	public void Rotate(float mag) {
		transform.Rotate (
			transform.up,
			mag * rotateSpeed * Time.deltaTime
		);
	}

	public void Break() {
		Vector3 v = rigidBody.velocity;
		float mag = Mathf.Min (v.magnitude, breakForce * Time.deltaTime);
		rigidBody.velocity -= v.normalized * mag;
	}
}
