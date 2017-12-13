using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingStair : FloatingObject {

	public float upperBound;

	protected override void floatImpl(float distance) {
		if ((transform.position += Vector3.up * distance).y > upperBound) {
			Destroy (gameObject);
		}
	}

}
