using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float moveSpeed;

	Rigidbody2D rb;
	Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 velocity = rb.velocity;
		velocity.x = Input.GetAxis ("Horizontal") * moveSpeed;
		transform.localEulerAngles = Vector3.up * (velocity.x > 0f ? 0f : 180f);
		rb.velocity = velocity;

		animator.SetFloat("Speed", velocity.magnitude);
	}
}
