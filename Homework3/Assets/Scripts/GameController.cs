using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[System.Serializable]
	public class StairTypeProbability {
		public StairGenerator.StairType stairType;
		[Range(0f, 1f)]
		public float appearProbability;
	}

	[Header("Game Configuration")]
	public float floatingSpeed;
	public int stairPeriod;
	public float stairMovingSpeed, stairMovingRange;
	public float maxHP;

	[Header("Game Objects")]
	public Slider HPSlider;
	public Text stageText, recordText, recordText2;
	public GameObject player;
	public GameObject gameStopPanel;

	[Header("Stair Genaration Configuration")]
	public StairGenerator stairGenerator;
	public StairTypeProbability[] stairTypeProbability;

	[Header("Sound Effect")]
	public AudioClip gameStart;
	public AudioClip gameEnd;
	public AudioClip showPanel;
	public AudioClip stageIncrement;

	bool isPlaying = false;
	float HP;
	int stage = 0, record = 0;
	int count = 0;
	Vector3 playerStartPos;

	void Start () {
		playerStartPos = player.transform.position;
		Debug.Assert (stairTypeProbability.Sum (t => t.appearProbability) <= 1.0f);
		FinishDeadAnimation ();
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
			float rand = Random.value;
			StairGenerator.StairType type = StairGenerator.StairType.Normal;
			foreach (StairTypeProbability t in stairTypeProbability) {
				if ((rand -= t.appearProbability) <= 0f) {
					type = t.stairType;
					break;
				}
			}

			stairGenerator.genStairAtRandom (type);
			stage++;
			if (stage % 10 == 0)
				AudioSource.PlayClipAtPoint (stageIncrement, Camera.main.transform.position);
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
		AudioSource.PlayClipAtPoint (gameStart, Camera.main.transform.position);
		replay ();
	}

	void FinishDeadAnimation() {
		AudioSource.PlayClipAtPoint (showPanel, Camera.main.transform.position);
		gameStopPanel.SetActive (true);
		player.SetActive (false);
		record = Mathf.Max (record, stage);
		recordText2.text = record.ToString ();
	}

	void dead() {
		isPlaying = false;
		AudioSource.PlayClipAtPoint (gameEnd, Camera.main.transform.position);
		player.SendMessage ("PerformDead");
	}

	void replay() {
		// Data reset
		HP = maxHP;
		HPSlider.minValue = 0f;
		HPSlider.maxValue = maxHP;
		stage = 0;
		stairGenerator.movingSpeed = stairMovingSpeed;
		stairGenerator.movingRange = stairMovingRange;
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
