using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragBehavior : MonoBehaviour {
	
	public float fragEffectForce = 10;
	public float fragEffectRadius = 20;
	public float effectDuration = 3;

	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.AddExplosionForce (
			fragEffectForce,
			transform.position,
			fragEffectRadius
		);

		Material mat = new Material (Shader.Find ("Unlit/Color"));
		mat.color = Random.ColorHSV ();
		GetComponent<Renderer> ().material = mat;
	}
	
	// Update is called once per frame
	void Update () {
		if ((effectDuration -= Time.deltaTime) <= 0 || rigidbody.velocity.magnitude <= 0.01f) {
			Destroy (gameObject);
		}
	}
}
