using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairGenerator : MonoBehaviour {

	public Vector2 genPosBegin, genPosEnd;
	public GameObject stairPrefab, fireStairPrefab;
	public AudioClip turnaroundSound;

	[HideInInspector]
	public float movingSpeed, movingRange;

	public enum StairType
	{
		Normal,
		Moving,
		OnFire,
	}

	public GameObject genStairAtRandom(StairType stairType = StairType.Normal) {
		Vector2 genPos = Vector2.Lerp (genPosBegin, genPosEnd, Random.value);

		GameObject prefab;
		switch (stairType) {
		case StairType.OnFire:
			prefab = fireStairPrefab;
			break;
		default:
			prefab = stairPrefab;
			break;
		}

		GameObject newStair = Instantiate (
		    prefab,
			genPos,
		    Quaternion.identity,
		    transform
		);

		switch (stairType) {
		case StairType.Moving:
			MovingStair moving = newStair.AddComponent<MovingStair> ();
			moving.maxX = Mathf.Min (genPos.x + movingRange, genPosEnd.x);
			moving.minX = Mathf.Max (genPos.x - movingRange, genPosBegin.x);
			moving.speed = movingSpeed;
			moving.turnaroundSound = turnaroundSound;
			break;
		case StairType.OnFire:
			DamagingTouch damaging = newStair.AddComponent<DamagingTouch> ();
			damaging.gameController = FindObjectOfType<GameController> ();
			damaging.hurt = 10f;
			break;
		}

		return newStair;
	}
}
