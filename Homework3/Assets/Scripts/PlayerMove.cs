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
		float movement = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		rb.position += Vector2.right * movement;
		transform.localEulerAngles = Vector3.up * (movement > 0f ? 0f : 180f);

		animator.SetFloat("Speed", rb.velocity.y != 0f ? 5f : movement * 20f);
	}
}
