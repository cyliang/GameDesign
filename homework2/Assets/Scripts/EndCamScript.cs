using UnityEngine;
using System.Collections;

public class EndCamScript : MonoBehaviour {

	public float speed;

	void LateUpdate () {
		transform.Rotate (Vector3.up * speed * Time.deltaTime);
	}
}
