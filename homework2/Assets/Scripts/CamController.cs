using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

	public Camera[] cameraList;
	private int lastIndex;

	void Start() {
		lastIndex = 0;

		for (int i = lastIndex + 1; i < cameraList.Length; i++) {
			cameraList [i].enabled = false;
		}
	}

	public void rotateCamera() {
		cameraList [lastIndex].enabled = false;

		++lastIndex;
		lastIndex %= cameraList.Length;

		cameraList [lastIndex].enabled = true;
	}
}
