using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	public float dieCountDown = 3;
	public int fragEffectNum = 100;
	public GameObject fragPrefab;

	private bool shallDie = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if ((dieCountDown -= Time.deltaTime) <= 0 || shallDie) {
			die ();
		}
	}

	void OnCollisionEnter(Collision collision) {
		shallDie = true;
	}

	void die() {
		Vector3 diePosition = transform.position + Vector3.up;
		for (int i = 0; i < fragEffectNum; i++) {
			GameObject newFrag = Instantiate (fragPrefab);
			newFrag.transform.position = diePosition;
		}

		Destroy (gameObject);
	}
}
