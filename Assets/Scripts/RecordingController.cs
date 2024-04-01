using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordingController : MonoBehaviour {

    public TMP_Text interactionPrompt;

    AudioSource voiceRecording;
    MeshRenderer recordingRenderer;
    BoxCollider boxCollider;
    Rigidbody rb;

    //bool inRange = false;
    public bool recordingCollected = false;

    private void Start() {
        voiceRecording = GetComponent<AudioSource>();
        recordingRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    //private void OnTriggerEnter(Collider other) {
    //    if (other.gameObject.tag == "Player") {
    //        inRange = true;

    //        if (!recordingCollected) {
    //            interactionPrompt.text = "[E] Play recording";
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other) {
    //    if (other.gameObject.tag == "Player") {
    //        inRange = false;
    //        interactionPrompt.text = "";
    //    }
    //}

    //private void Update() {
    //    if (Input.GetKeyDown(KeyCode.E) && inRange && !recordingCollected) {
    //        PlayRecording();
    //    }

    //}

    public void PlayRecording() {
        if (!recordingCollected) {
            //play the audio clip associated with this recording
            voiceRecording.Play();

            recordingCollected = true;

            //recording should disappear, but needs to stay active so the audio plays
            recordingRenderer.enabled = false;
            boxCollider.enabled = false;
            rb.useGravity = false; //so the object doesn't just plummet through the ground

        }
    }
}
