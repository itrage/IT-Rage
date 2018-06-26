using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
	public Slider healthSlider;
	public AudioSource gameAudio;
	public static AudioSource mainAudio;
	public AudioSource deadAudio;
	public RectTransform gameOverUI;

	public static float currentHealth;
	public static PlayerController controlMovement;
	public static CapsuleCollider2D capsuleCollider;

	void Start() {
		PlayerHealth.mainAudio = gameAudio;
		PlayerHealth.mainAudio.loop = true;
		PlayerHealth.mainAudio.Play();

		PlayerHealth.currentHealth = fullHealth;
		PlayerHealth.controlMovement = GetComponent<PlayerController>();
		PlayerHealth.capsuleCollider = GetComponent<CapsuleCollider2D>();

		//HUD Initialization
		healthSlider.maxValue = fullHealth;
		healthSlider.value = fullHealth;

		transform.gameObject.SetActive(true);
	}

	public void AddDamage(float damage) {
		if (damage <= 0) return;
		PlayerHealth.currentHealth -= damage;
		healthSlider.value = PlayerHealth.currentHealth;

		if (PlayerHealth.currentHealth <= 0) {
			Death();
		}
	}

	public void Death() {
		StartCoroutine("MakeDead");
	}

	void disableObjects() {
		Time.timeScale = 0f;
		healthSlider.gameObject.SetActive(false);
		PlayerHealth.capsuleCollider.enabled = false;
		PlayerHealth.controlMovement.enabled = false;
		transform.gameObject.SetActive(false);
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Menu");
		for (int i = 0; i < objs.Length; i++) {
			objs[i].SetActive(false);
		}
		gameOverUI.gameObject.SetActive(true);
	}

	IEnumerator MakeDead() {
		disableObjects();
		PlayerHealth.mainAudio.Stop();
		deadAudio.Play();
		//AudioSource.PlayClipAtPoint(deadAudio, transform.position, 1f);  // Not working, idk why
		yield return new WaitForSeconds(1.5f);
	}
}
