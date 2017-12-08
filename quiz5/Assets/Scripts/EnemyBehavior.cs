using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	
	public float moveSpeed;

	private Transform player;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerBehavior> ().transform;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.y == 0f && transform.position.y < -2f) {
			float x = Mathf.MoveTowards (transform.position.x, player.position.x, moveSpeed * Time.deltaTime);
			transform.position = new Vector3 (x, transform.position.y);
		}
	}
}
