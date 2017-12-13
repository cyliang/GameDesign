using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float floatingSpeed;
	public int stairPeriod;

	public float maxHP;

	public Slider HPSlider;
	public Text stageText, recordText, recordText2;

	public GameObject player;
	public GameObject gameStopPanel;
	public StairGenerator stairGenerator;

	bool isPlaying = false;
	float HP;
	int stage, record;
	int count = 0;
	Vector3 playerStartPos;

	void Start () {
		playerStartPos = player.transform.position;
	}
		
	void Update () {
		if (!isPlaying)
			return;
		
		FloatingObject.Float (floatingSpeed * Time.deltaTime);
	}

	void FixedUpdate() {
		if (!isPlaying)
			return;
		
		if (count % stairPeriod == 0) {
			stairGenerator.genStairAtRandom ();
			stage++;
			updateInfo ();
		}

		count++;
	}

	public void MakeDamage(float damage) {
		HP -= damage;
		updateInfo ();

		if (HP <= 0f) {
			dead ();
		}
	}

	public void startPlay() {
		isPlaying = true;
		gameStopPanel.SetActive (false);
		replay ();
	}

	void dead() {
		isPlaying = false;
		gameStopPanel.SetActive (true);
		player.SetActive (false);
		record = Mathf.Max (record, stage);
		recordText2.text = record.ToString ();
	}

	void replay() {
		// Data reset
		HP = maxHP;
		HPSlider.minValue = 0f;
		HPSlider.maxValue = maxHP;
		stage = 0;
		updateInfo ();

		// Scene reset
		foreach (Transform stair in stairGenerator.transform) {
			Destroy (stair.gameObject);
		}
		Instantiate (
			stairGenerator.stairPrefab,
			new Vector2 (0f, -2.4f),
			Quaternion.identity,
			stairGenerator.transform
		);
		player.SetActive (true);
		player.transform.position = playerStartPos;
	}

	void updateInfo() {
		HPSlider.value = HP;
		stageText.text = stage.ToString();
		recordText.text = record.ToString();
	}
}
