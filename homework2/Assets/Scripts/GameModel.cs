using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameModel {

	static public Text scoreText { get; set; }

	public enum State {start, win, lose};
	static public State state {
		get;
		private set;
	}

	static int score = 0;
	static public void scoring() {
		score++;
		updateScore ();

		if (score == 10)
			win ();
	}
		
	static public void updateScore() {
		scoreText.text = "Score: " + score.ToString ();
	}

	static public void replay() {
		state = State.start;
		SceneManager.LoadScene ("Play");
	}

	static public void win() {
		state = State.win;
		SceneManager.LoadScene ("EndGame");
	}

	static public void lose() {
		state = State.lose;
		SceneManager.LoadScene ("EndGame");
	}
}
