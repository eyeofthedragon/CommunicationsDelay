using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDialogueTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public DialogueGraph tree;
    public DialogueManager dialogueManager;
    public Image fader;

    bool alreadyPlayed = false;

    private void Update() {
        if (alreadyPlayed && !dialogueManager.dialogueIsPlaying) {
            fader.DOFade(0, 4).OnComplete(() => { audioSource.Play(); this.gameObject.SetActive(false); });
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player" && !alreadyPlayed) {
            TriggerDialogue();
            alreadyPlayed = true;
        }
    }

    public void TriggerDialogue() {
        dialogueManager.StartDialogue(tree.nodes[0]);
    }
}
