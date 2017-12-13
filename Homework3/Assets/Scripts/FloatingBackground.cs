using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBackground : FloatingObject {

	public float maxY;

	protected override void floatImpl (float distance) {
		Vector3 pos = transform.position;
		pos.y += distance;
		pos.y %= maxY;
		transform.position = pos;
	}

}
