using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighCamBehavior : MonoBehaviour {

	public GameObject player;
	public float height;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.Scale (
			player.transform.position,
			new Vector3 (1f, 0, 1f)
		) + Vector3.up * height;
	}
}
