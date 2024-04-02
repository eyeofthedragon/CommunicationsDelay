using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour {
    public Image fader;
    public TMP_Text subtitles;
    public bool subtitlesEnabled;

    private void Start() {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu")) {
            fadeIn();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void StartGame() {
        StartCoroutine(fadeOut("Bluefield"));
    }

    public void MainMenu() {
        Time.timeScale = 1; //turn time back on so that it will load even when the game is paused
        StartCoroutine(fadeOut("MainMenu"));
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void ToggleSubtitles() {
        subtitlesEnabled = !subtitlesEnabled;
        if (!subtitlesEnabled) {
            subtitles.text = ""; //ensure the text goes away if they disable subtitles mid-recording
        }
    }

    IEnumerator fadeOut(string sceneName) {
        fader.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

    void fadeIn() {
        fader.DOFade(0, 1);
    }
}
