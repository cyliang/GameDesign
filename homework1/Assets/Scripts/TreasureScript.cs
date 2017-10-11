using UnityEngine;
using System.Collections;

public class TreasureScript : MonoBehaviour {

	public float speed;
	public float distance;

	Vector3 position;

	void Start () {
		position = transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = position + Vector3.up * Mathf.Sin (speed * Time.time) * distance;
	}
}
