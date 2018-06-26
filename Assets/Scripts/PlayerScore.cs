using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	public static int playerScore;
	public Text scoreText;

	void Start() {
		playerScore = 0;
	}

	public void AddScore(int scoreValue) {
		PlayerScore.playerScore += scoreValue;
		scoreText.text = PlayerScore.playerScore.ToString();
	}
}
