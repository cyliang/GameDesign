using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public AudioClip winSound, loseSound, startSound;
	public GameObject winText, loseText;
	public Text playBtnText;

	void Start() {
		switch (GameModel.state) {
		case GameModel.State.win:
			winText.SetActive (true);
			AudioSource.PlayClipAtPoint (winSound, Vector3.zero);
			break;

		case GameModel.State.lose:
			loseText.SetActive (true);
			AudioSource.PlayClipAtPoint (loseSound, Vector3.zero);
			break;

		default:
			playBtnText.text = "Play";
			AudioSource.PlayClipAtPoint (startSound, Vector3.zero);
			break;
		}
	}

	void OnButtonClick() {
		GameModel.replay ();
	}
}
