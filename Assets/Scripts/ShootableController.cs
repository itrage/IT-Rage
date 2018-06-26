using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableController : MonoBehaviour {

	public int shootReward;
	PlayerScore playerScore;

	void Awake() {
		var player = GameObject.FindWithTag("Player");
		playerScore = player.GetComponent<PlayerScore>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "NPC") {
			if (other.name.Contains("enemy")) {
				playerScore.AddScore(-shootReward);
				Destroy(other.gameObject);
				Destroy(gameObject);
			}
		}
	}
}
