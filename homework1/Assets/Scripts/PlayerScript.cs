using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float maxHeight;
	public Vector3 direction;
	public Text scoreText, resultText;
	public AudioClip[] scoreClips;
	public GameObject scoreEffect;
	public AudioClip[] footSound;
	public float footVolume;

	Rigidbody rb;
	int score;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		updateScore ();
	}

	void Update() {
		if (transform.position.y < -10) {
			GameModel.lose ();
		}
	}
	
	void FixedUpdate() {
		if (Input.GetKeyDown (KeyCode.LeftControl) && transform.position.y < maxHeight) {
			rb.AddForce (Vector3.up * jumpSpeed);
		}
		if (Input.GetKey (KeyCode.Space)) {
			rb.velocity = rb.velocity * 0.95f;
		} else {
			rb.AddForce ((
				direction * Input.GetAxis ("Vertical") +
				Vector3.Cross(Vector3.up, direction) * Input.GetAxis ("Horizontal")				
			) * speed);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Treasure")) {
			other.gameObject.transform.parent.gameObject.SetActive (false);

			AudioSource.PlayClipAtPoint (scoreClips [Random.Range (0, scoreClips.Length)], transform.position);
			Instantiate (scoreEffect, other.transform.position, Quaternion.identity);

			score++;
			updateScore ();

			if (score == 10)
				GameModel.win ();
		}
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Ground")) {
			AudioSource.PlayClipAtPoint (footSound [Random.Range (0, footSound.Length)], 
				collision.contacts[0].point, 
				10f * collision.relativeVelocity.magnitude);
		}
	}

	void updateScore() {
		scoreText.text = "Score: " + score.ToString ();
	}
}
