using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float floatingSpeed;
	public int stairPeriod;

	public float maxHP;

	public Slider HPSlider;
	public Text stageText, recordText;

	public StairGenerator stairGenerator;

	float HP;
	int stage, record;
	int count = 0;

	void Start () {
		replay ();
	}
		
	void Update () {
		FloatingObject.Float (floatingSpeed * Time.deltaTime);
	}

	void FixedUpdate() {
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

	void dead() {
		print ("DEAD");
	}

	void replay() {
		HP = maxHP;
		HPSlider.minValue = 0f;
		HPSlider.maxValue = maxHP;

		stage = 0;
		updateInfo ();
	}

	void updateInfo() {
		HPSlider.value = HP;
		stageText.text = stage.ToString();
		recordText.text = record.ToString();
	}
}
