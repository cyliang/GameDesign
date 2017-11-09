using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject enemyPrefab;
	public Vector2 appearPosition;
	public float appearPeriod;

	private float appearTime;

	// Use this for initialization
	void Start () {
		appearTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - appearTime >= appearPeriod) {
			makeEnemy ();
		}
	}

	void makeEnemy() {
		appearTime = Time.time;

		GameObject newEnemy = Instantiate (enemyPrefab, transform);
		newEnemy.transform.position = appearPosition;
	}
}
