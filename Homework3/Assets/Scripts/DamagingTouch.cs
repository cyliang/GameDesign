using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingTouch : MonoBehaviour {

	public float hurt;
	public GameController gameController;

	void OnTriggerEnter2D(Collider2D other) {
		gameController.MakeDamage (hurt);
	}
}
