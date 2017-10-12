using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : Button {
	public bool isPressed {
		get {
			return IsPressed ();
		}
	}
}
