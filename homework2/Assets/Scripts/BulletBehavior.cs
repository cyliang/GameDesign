using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehavior : MonoBehaviour {
	
	public AudioClip[] scoreClips;
	public GameObject scoreEffect;
	public AudioClip[] footSound;
	public float footVolume;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Treasure")) {
			other.gameObject.transform.parent.gameObject.SetActive (false);

			AudioSource.PlayClipAtPoint (scoreClips [Random.Range (0, scoreClips.Length)], transform.position);
			Instantiate (scoreEffect, other.transform.position, Quaternion.identity);

			GameModel.scoring ();
		}
	}

	protected void OnCollisionEnter (Collision collision) {
		if (collision.collider.gameObject.CompareTag ("Ground")) {
			AudioSource.PlayClipAtPoint (footSound [Random.Range (0, footSound.Length)], 
				collision.contacts[0].point, 
				10f * collision.relativeVelocity.magnitude);
		}
	}
}
