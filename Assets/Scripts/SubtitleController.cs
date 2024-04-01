using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleController : MonoBehaviour {
    public TextAsset textFile;
    public TMP_Text subtitle;

    public void StartSubtitles() {
        string fullText = textFile.text;

        string[] strings = fullText.Split('\n');

        //for (int i = 0; i < strings.Length; i++) {
        //    print(strings[i]);
        StartCoroutine(ShowNextString(strings));
            
            //subtitle.text = strings[i];
        //}
    }

    IEnumerator ShowNextString(string[] strings) {
        for (int i=0; i<strings.Length; i++) {
            subtitle.text = strings[i];
            yield return new WaitForSeconds(2);
        }
        
        
    }

}
