using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIndicatorBehavior : MonoBehaviour {

	public GameObject player;

	private float mapWidth, mapHeight;

	// Use this for initialization
	void Start () {
		RectTransform parentTransform = transform.parent.transform as RectTransform;
		mapWidth = parentTransform.rect.width;
		mapHeight = parentTransform.rect.height;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 playerPosition = player.transform.position;
		transform.localPosition = new Vector3 (
			mapWidth / 500f * playerPosition.x - mapWidth / 2,
			mapHeight / 500f * playerPosition.z - mapHeight / 2
		);
	}
}
