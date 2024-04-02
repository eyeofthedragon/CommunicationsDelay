using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
    public Canvas pauseMenu;
    public DialogueManager dialogueManager;

    CanvasGroup canvasGroup;
    bool pauseMenuOpen = false;

    private void Start() {
        pauseMenu.enabled = false;
        canvasGroup = pauseMenu.GetComponent<CanvasGroup>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenuOpen && !dialogueManager.dialogueIsPlaying) {
            pauseMenuOpen = true;
            Time.timeScale = 0;
            pauseMenu.enabled = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            AudioListener.pause = true;

            canvasGroup.interactable = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuOpen) {
            CloseMenu();
        }
    }

    public void CloseMenu() {
        pauseMenuOpen = false;
        Time.timeScale = 1;
        pauseMenu.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        AudioListener.pause = false;

        //it seems like sometimes the space bar is pressing pause menu buttons during gameplay. ensure it doesn't do that
        canvasGroup.interactable = false;
    }
}
