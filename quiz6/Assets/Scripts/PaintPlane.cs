using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintPlane : MonoBehaviour, IPointerDownHandler, IDragHandler {

	public Texture2D mainTexture;
	public float fadeRadius;
	public float fadeRate;
	Texture2D alphaTex;

	void Start () {
		alphaTex = new Texture2D (mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
		GetComponent<Renderer> ().material.SetTexture ("_AlphaTex", alphaTex);

		alphaTex.SetPixels (Enumerable.Repeat (
			Color.red,
			alphaTex.width * alphaTex.height
		).ToArray ());
		alphaTex.Apply ();
	}
	
	public void OnPointerDown (PointerEventData eventData) {
		Vector3 updateMaskAround = eventData.pointerCurrentRaycast.worldPosition;
		Vector3 relativeCoord = transform.InverseTransformPoint (updateMaskAround) + new Vector3(5, 0, 5);
		relativeCoord.Scale (new Vector3 (0.1f * alphaTex.width, 1.0f, 0.1f * alphaTex.height));
		Vector2 textureCoord = new Vector2 (
			Mathf.Round(relativeCoord.x),
			Mathf.Round(relativeCoord.z)
		);

		Vector2 minCoord = Vector2.Max (textureCoord - Vector2.one * fadeRadius, Vector2.zero);
		Vector2 maxCoord = Vector2.Min (textureCoord + Vector2.one * fadeRadius, new Vector2 (alphaTex.width, alphaTex.height));
		Vector2 range = maxCoord - minCoord;

		Color[] texels = alphaTex.GetPixels ((int)minCoord.x, (int)minCoord.y, (int)range.x, (int)range.y);
		for (int x = 0; x < (int)range.x; x++) {
			for (int y = 0; y < (int)range.y; y++) {
				texels [(int)range.x * y + x] -= Color.red / Mathf.Pow (Vector2.Distance (
					minCoord + new Vector2 (x, y),
					textureCoord
				), 2f) * fadeRate;
			}
		}

		alphaTex.SetPixels ((int)minCoord.x, (int)minCoord.y, (int)range.x, (int)range.y, texels);
		alphaTex.Apply ();
	}

	public void OnDrag (PointerEventData eventData) {
		if (eventData.pointerCurrentRaycast.gameObject == gameObject)
			OnPointerDown (eventData);
	}
}
