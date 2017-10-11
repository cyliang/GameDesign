using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehavior : MonoBehaviour {

	public int eighteenCount = 3;
	public float rotateSpeed;
	public float slowDown;
	public GameObject Dice;

	private int[] diceResult;

	// Use this for initialization
	void Start () {
		eighteen (eighteenCount);

		int diceCount = diceResult [diceResult.Length - 1];
		float angleDiff = (360f / diceCount) * Mathf.Deg2Rad;
		for (int i = 0; i < diceCount; i++) {
			float angle = angleDiff * i;

			GameObject newDice = Instantiate (Dice, transform);
			newDice.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
			newDice.transform.position = new Vector3 (
				Mathf.Cos (angle),
				4,
				Mathf.Sin (angle)
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (rotateSpeed > 0) {
			transform.Rotate (Vector3.up, rotateSpeed * Time.deltaTime);
			rotateSpeed -= slowDown * Time.deltaTime;
		}
	}

	void eighteen(int count) {
		diceResult = new int[count];

		for (int i = 0; i < count; i++) {
			diceResult [i] = 0;

			for (int j = 0; j < 3; j++) {
				diceResult [i] += Mathf.CeilToInt (Random.value * 6);
			}
		}

		for (int i = 0; i < count; i++) {
			print (diceResult [i]);
		}
	}
}
