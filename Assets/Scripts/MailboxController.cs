using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MailboxController : MonoBehaviour {

    public TMP_Text interactionPrompt;
    public AudioClip test;

    public bool mailDelivered = false;

    AudioSource audioSource;
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void DeliverMail() {
        if (!mailDelivered) {
            //play a sound effect
            audioSource.Play();

            //close the mailbox and put the little flag up
            animator.SetBool("closeMailbox", true);

            StartCoroutine(PlayClosingSound());
            //audioSource.PlayOneShot(test);
            


            mailDelivered = true;
        }
    }

    IEnumerator PlayClosingSound() {
        yield return new WaitForSeconds(1.75f);
        audioSource.PlayOneShot(test);
    }
}
