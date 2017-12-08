using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTextureOffset : MonoBehaviour {

	Material mat;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		mat.SetVector("_Offset", mat.GetVector("_Offset") + new Vector4 (1f, 1f) * Time.deltaTime * speed);
	}
}
