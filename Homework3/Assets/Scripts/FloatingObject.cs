using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class FloatingObject: MonoBehaviour {

	static LinkedList<FloatingObject> floatings = new LinkedList<FloatingObject>();
	LinkedListNode<FloatingObject> selfNode;

	protected void Start () {
		selfNode = floatings.AddLast (this);
	}

	protected void OnDestroy () {
		floatings.Remove (selfNode);
	}

	// Implementation of object floating upward.
	// This method can delete the object by itself when
	// the object becomes no more visible in the scene.
	abstract protected void floatImpl (float distance);

	static public void Float(float distance) {
		for (var it = floatings.First; it != null;) {
			FloatingObject obj = it.Value;
			it = it.Next;

			obj.floatImpl (distance);
		}
	}
}
