using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundController : MonoBehaviour
{
    public DialogueGraph tree;
    public DialogueManager dialogueManager;
    public MailboxController mailbox;

    bool mailDelivered;

    private void Update() {
        if (mailbox.mailDelivered) {
            mailDelivered = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player" && !mailDelivered) {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue() {
        dialogueManager.StartDialogue(tree.nodes[0]);
    }
}
