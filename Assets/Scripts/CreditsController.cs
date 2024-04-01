using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text authorText;
    public TMP_Text credits1;
    public TMP_Text credits2Title;
    public TMP_Text credits2Text;

    private float timer = 0;
    private bool[] eventsTriggered = new bool[4];

    private void Start() {
        titleText.alpha = 0;
        authorText.alpha = 0;
        credits1.alpha = 0;
        credits2Title.alpha = 0;
        credits2Text.alpha = 0;
    }

    private void Update() {
        timer += Time.deltaTime;

        //Fade in title
        //Hold on title
        //Fade out title
        //Fade in text
        //Hold on text
        //Fade out text 
        //Go to main menu


        if (timer > 19) {
            SceneManager.LoadScene("MainMenu");
        }
        else if (timer > 16 && !eventsTriggered[3]) {
            credits1.DOFade(0, 2);
            credits2Title.DOFade(0, 2);
            credits2Text.DOFade(0, 2);
            eventsTriggered[3] = true;
        }
        else if (timer > 10 && !eventsTriggered[2]) {
            credits1.DOFade(1, 3);
            credits2Title.DOFade(1, 3);
            credits2Text.DOFade(1, 3);
            eventsTriggered[2] = true;
        }
        else if (timer > 8 && !eventsTriggered[1]) {
            titleText.DOFade(0, 2);
            authorText.DOFade(0, 2);
            eventsTriggered[1] = true;
        }
        else if (timer > 1 && !eventsTriggered[0]) {
            titleText.DOFade(1, 4);
            authorText.DOFade(1, 4);
            eventsTriggered[0] = true;
        }
    }
}
