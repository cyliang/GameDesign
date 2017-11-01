using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : BulletBehavior {

	public float speed;
	public float jumpSpeed;
	public float maxHeight;
	public float bulletSpeed;
	public Vector3 direction;

	public Text scoreText;
	public GameObject bullet, bulletGroup;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		GameModel.scoreText = scoreText;
		GameModel.updateScore ();
	}

	void Update() {
		if (transform.position.y < -10) {
			GameModel.lose ();
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Quaternion rotate = Quaternion.AngleAxis (-20, Vector3.right);

			GameObject newBullet = Instantiate (bullet, bulletGroup.transform);
			newBullet.transform.position = transform.position + rotate * direction * 2f;
			newBullet.GetComponent<Rigidbody> ().velocity = rb.velocity + rotate * direction * bulletSpeed;
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
}
