using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MailboxController : MonoBehaviour {
   
    public bool mailDelivered = false;
    public AudioClip closingSound;

    AudioSource audioSource;
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void DeliverMail() {
        if (!mailDelivered) {
            //play the sound of the mail being put in the mailbox
            audioSource.Play();

            //close the mailbox and put the little flag up
            animator.SetBool("closeMailbox", true);

            //play the sound of the mailbox closing
            StartCoroutine(PlayClosingSound());

            mailDelivered = true;
        }
    }

    IEnumerator PlayClosingSound() {
        yield return new WaitForSeconds(1.75f);
        audioSource.PlayOneShot(closingSound);
    }
}
