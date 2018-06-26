using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public RectTransform menuCanvas;
    public RectTransform instructionCanvas;

    public void PlayGame() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Instructions() {
        menuCanvas.gameObject.SetActive(false);
        instructionCanvas.gameObject.SetActive(true);
    }

    public void Menu() {
        instructionCanvas.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
    }
}
