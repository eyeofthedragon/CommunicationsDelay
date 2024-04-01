using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuController : MonoBehaviour {
    public Image fader;

    private void Start() {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu")) {
            fadeIn();
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


    IEnumerator fadeOut(string sceneName) {
        fader.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

    void fadeIn() {
        fader.DOFade(0, 0.5f);
    }
}
