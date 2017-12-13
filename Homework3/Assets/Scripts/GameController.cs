using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float floatingSpeed;
	public int stairPeriod;

	public StairGenerator stairGenerator;

	int count = 0;
		
	void Update () {
		FloatingObject.Float (floatingSpeed * Time.deltaTime);
	}

	void FixedUpdate() {
		if (count % stairPeriod == 0) {
			stairGenerator.genStairAtRandom ();
		}

		count++;
	}
}
