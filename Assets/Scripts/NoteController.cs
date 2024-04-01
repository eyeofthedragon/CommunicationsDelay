using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public Canvas noteCanvas;
    public bool noteRead = false;

    public void ReadNote() {
        noteCanvas.gameObject.SetActive(true);
        noteRead = true;
    }

    public void PutDownNote() {
        noteCanvas.gameObject.SetActive(false);
    }
}
