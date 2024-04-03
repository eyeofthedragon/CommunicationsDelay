using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ControlsController : MonoBehaviour
{
    public Canvas controlsCanvas;
    public Image fader;
    public MenuController menuController;

    public void ShowControls() {
        fader.DOFade(1, 0.5f).OnComplete(() => { 
            controlsCanvas.gameObject.SetActive(true);
            fader.DOFade(0, 0.5f);
            StartCoroutine(StartGame());
        });
        
    }

    IEnumerator StartGame() {
        yield return new WaitForSeconds(3);
        menuController.StartGame();
    }
}
