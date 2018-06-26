using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
    
    public GameObject pauseButton;
    public RectTransform pauseUI;

    public void PauseGame() {
        Time.timeScale = 0;
        PlayerHealth.mainAudio.Pause();
        pauseButton.SetActive(false);
        pauseUI.gameObject.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1.0f;
        PlayerHealth.mainAudio.Play();
        pauseUI.gameObject.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void PlayAgain() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
