using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float damage;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			playerHealth.AddDamage(damage);

			Destroy(gameObject);
		}
	}
}
