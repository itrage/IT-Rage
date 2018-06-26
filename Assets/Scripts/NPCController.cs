using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

	public List<RuntimeAnimatorController> animations;
	public Transform itemSpawn;

	Transform player;
	Transform target;
	Transform[] targetPoints;
	string objectName;

	void Start() {
		player = GameObject.Find("player").transform;
		targetPoints = itemSpawn.GetComponentsInChildren<Transform>();
		var idx = Random.Range(0, animations.Count);
		var animator = transform.gameObject.GetComponent<Animator>();
		animator.runtimeAnimatorController = animations[idx];

		idx = Random.Range(0, targetPoints.Length);
		target = targetPoints[idx];
		objectName = transform.name.Replace("(Clone)", "");
	}

	void Update() {
		if (objectName.Equals("ally")) {
			MoveGood();
		} else if (objectName.Equals("enemy")) {
			MoveEvil();
		}

	}

	void MoveGood() {
		if (Time.timeScale > 0f) {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.04f);
			if (Vector3.Distance(transform.position, target.transform.position) < 0.5f) {
				var idx = Random.Range(0, targetPoints.Length);
				target = targetPoints[idx];
			}
		}
	}

	void MoveEvil() {
		float moveSpeed = 0.02f;

		if (Time.timeScale > 0f) {
			transform.position = Vector3.Lerp(transform.position, player.position, moveSpeed);
		}
	}
}
