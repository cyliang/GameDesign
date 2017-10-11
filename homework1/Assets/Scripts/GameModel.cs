using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameModel {

	public enum State {start, win, lose};
	static public State state {
		get;
		private set;
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
