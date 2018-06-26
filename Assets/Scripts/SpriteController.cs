using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteController : MonoBehaviour {

	public List<Sprite> sprites;

	SpriteRenderer spriteRenderer;


	void Awake() {
		spriteRenderer = transform.gameObject.GetComponent<SpriteRenderer>();
	}

	public void SetSprite(int idx) {
		if (idx >= 0 && idx < sprites.Count) {
			spriteRenderer.sprite = sprites[idx];
		}
	}

}
