using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInteraction : MonoBehaviour {

    public Transform player;
    public Transform orientation;
    public Transform holdArea;

    public TMP_Text interactionPrompt;

    private bool inCubeRange = false;
    private bool canDrop = false;
    private bool holding = false;
    private Rigidbody rb;

    private bool raycast;

    private void Start() {
        rb = GetComponentInChildren<Rigidbody>();
    }


    //private void OnTriggerEnter(Collider other) {
    //    if (other.gameObject.tag == "Player") {
    //        inCubeRange = true;
    //        interactionPrompt.text = "[E] Pick up";
    //    }
    //}

    //private void OnTriggerExit(Collider other) {
    //    if (other.gameObject.tag == "Player") {
    //        inCubeRange = false;
    //        interactionPrompt.text = "";
    //    }
    //}


    private void Update() {

        //The way this currently works, the player can pick up objects even if they're not looking at them.
        //Might be worth using a raycast of some sort to change that.

        if (Input.GetKeyDown(KeyCode.E) && inCubeRange && !holding) {
            rb.useGravity = false;
            rb.freezeRotation = true;
            rb.drag = 10;
            transform.parent = holdArea;

            holding = true;
            canDrop = false;
            interactionPrompt.text = ""; //hide the prompt once they've picked it up
        }
        if (Input.GetKeyDown(KeyCode.E) && holding && canDrop) {
            rb.useGravity = true;
            rb.freezeRotation = false;
            rb.drag = 1;
            transform.parent = null;

            holding = false;
        }

        if (holding) {

            if (Vector3.Distance(transform.position, holdArea.position) > 0.1f) {
                Vector3 directionToMove = holdArea.position - transform.position;
                directionToMove.Normalize();

                rb.AddForce(directionToMove * 50);
            }
            transform.LookAt(player.position); //make sure the box rotates with the player
        
        }

        Invoke(nameof(ResetPickup), 1);
        
    }

    private void ResetPickup() {
        canDrop = true;
    }
}
