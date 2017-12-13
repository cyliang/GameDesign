using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairGenerator : MonoBehaviour {

	public Vector2 genPosBegin, genPosEnd;
	public GameObject stairPrefab;

	public GameObject genStairAtRandom() {
		return Instantiate (
		    stairPrefab,
		    Vector2.Lerp (genPosBegin, genPosEnd, Random.value),
		    Quaternion.identity,
		    transform
		);
	}
}
