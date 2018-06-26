using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpawnItems : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject enemy;
	public GameObject ally;
	public RectTransform winGameUI;
	public RectTransform pauseUI;
	public RectTransform countdownUI;
	public Text countdownText;
	public float spawnTime = 3f;
	public float waitTime = 120f;
	public Transform itemSpawn;

	float timer;
	float cdTime;
	GameObject objectHold;
	int initAllyPercentage = 60;

	// Use this for initialization
	void Start() {
		spawnPoints = itemSpawn.GetComponentsInChildren<Transform>();
		StartCoroutine("SpawnItem");
		cdTime = waitTime;
	}

	// Update is called once per frame
	void Update() {
		timer += Time.deltaTime;
		cdTime -= Time.deltaTime;
		int min = (int) Math.Round(cdTime, 0) / 60;
		int sec = (int) Math.Round(cdTime, 0) % 60;
		countdownText.text = (min < 10 ? "0" + min : "" + min) + ":" + (sec < 10 ? "0" + sec : "" + sec);
	}

	void ItemType() {
		int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
		int typeExtra = UnityEngine.Random.Range(1, 100);
		if (typeExtra <= initAllyPercentage) {
			Instantiate(ally, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
		} else {
			Instantiate(enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
		}
		initAllyPercentage = Math.Max(20, initAllyPercentage - UnityEngine.Random.Range(0, 2));
		spawnTime = Math.Max(1, spawnTime - UnityEngine.Random.Range(0, 2) / 20f);
	}

	public void WinGame() {
		pauseUI.gameObject.SetActive(false);
		countdownUI.gameObject.SetActive(false);
		winGameUI.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	IEnumerator SpawnItem() {
		while (timer < waitTime) {
			ItemType();
			yield return new WaitForSeconds(spawnTime);
		}

		WinGame();
		yield return null;
	}
}
