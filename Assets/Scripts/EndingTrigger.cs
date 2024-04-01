using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndingTrigger : MonoBehaviour {
    public DialogueGraph tree;
    public MailboxController mailbox;
    public NoteController note;
    public Image fader;
    public Image cursor;
    public DialogueManager dialogueManager;

    bool alreadyPlayed = false;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player" && !alreadyPlayed && mailbox.mailDelivered && note.noteRead) {
            TriggerDialogue();
            alreadyPlayed = true;

            //fade to black
            cursor.gameObject.SetActive(false);
            fader.DOFade(1, 2f);
        }
    }

    private void Update() {
        if (alreadyPlayed && !dialogueManager.dialogueIsPlaying) {
            SceneManager.LoadScene("Credits");
        }
    }

    public void TriggerDialogue() {
        dialogueManager.StartDialogue(tree.nodes[0]);
    }

}
