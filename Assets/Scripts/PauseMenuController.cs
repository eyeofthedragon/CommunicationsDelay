using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
    public Canvas pauseMenu;
    public DialogueManager dialogueManager;
    //public AudioSource gameMusic;
    //public AudioClip pauseOpen;
    //public AudioClip pauseClose;

    AudioSource soundEffectSource;

    bool pauseMenuOpen = false;

    private void Start() {
        pauseMenu.enabled = false;
        //soundEffectSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenuOpen && !dialogueManager.dialogueIsPlaying) {
            pauseMenuOpen = true;
            Time.timeScale = 0;
            pauseMenu.enabled = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            AudioListener.pause = true;

            //gameMusic.Pause();
            //soundEffectSource.PlayOneShot(pauseOpen);
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

        //soundEffectSource.PlayOneShot(pauseClose);
        //gameMusic.Play();
    }
}
