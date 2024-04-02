using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleController : MonoBehaviour {
    public TextAsset textFile;
    public TMP_Text subtitle;
    public MenuController menuController;

    public void StartSubtitles() {
        string fullText = textFile.text;

        string[] strings = fullText.Split('/');

        //for (int i = 0; i < strings.Length; i++) {
        //    print(strings[i]);
        StartCoroutine(ShowNextString(strings));
            
            //subtitle.text = strings[i];
        //}
    }

    IEnumerator ShowNextString(string[] strings) {
        for (int i=0; i<strings.Length; i++) {

            //only show the subtitles if they're turned on, but load them regardless in case they're turned on mid-recording
            if (menuController.subtitlesEnabled) {
                subtitle.text = strings[i];
            }
            yield return new WaitForSeconds(8);
        }
        
        
    }

}
