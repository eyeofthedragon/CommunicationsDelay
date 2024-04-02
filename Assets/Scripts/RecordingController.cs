using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordingController : MonoBehaviour {

    AudioSource voiceRecording;
    MeshRenderer recordingRenderer;
    BoxCollider boxCollider;
    Rigidbody rb;
    SubtitleController subtitleController;

    public bool recordingCollected = false;

    private void Start() {
        voiceRecording = GetComponent<AudioSource>();
        recordingRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        subtitleController = GetComponent<SubtitleController>();
    }

    public void PlayRecording() {
        if (!recordingCollected) {
            //play the audio clip associated with this recording
            voiceRecording.Play();

            subtitleController.StartSubtitles();

            recordingCollected = true;

            //recording should disappear, but object needs to stay active so the audio plays
            recordingRenderer.enabled = false;
            boxCollider.enabled = false;
            rb.useGravity = false; //so the object doesn't just plummet through the ground

        }
    }
}
