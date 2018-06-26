using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

	Transform itemObject;
	HoldObject holdObject;
	int objectValue = 10;

	// Use this for initialization
	void Start() {
		holdObject = GetComponent<HoldObject>();
		itemObject = holdObject.Item;
	}

	// Update is called once per frame
	void Update() {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			PlayerScore playerScore = other.gameObject.GetComponent<PlayerScore>();
			PlayerObjects playerObjects = other.gameObject.GetComponent<PlayerObjects>();
			playerScore.AddScore(objectValue);
			string objectName = itemObject.name.Replace("(Clone)", "");
			playerObjects.AddCount(objectName);
			Destroy(gameObject);
		}
	}
}
