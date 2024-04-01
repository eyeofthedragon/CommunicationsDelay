using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public Transform player;
    public float sensitivityX;
    public float sensitivityY;

    public Transform orientation;
    public DialogueManager dialogueManager;

    float xRotation;
    float yRotation;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        if (!dialogueManager.dialogueIsPlaying) {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

            if (mouseX > 0.5f || mouseX < -0.5f) {
                yRotation += mouseX; //getting weird tiny movements even when not moving the mouse, so don't accept those
            };
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //clamp the rotation so the user can't look too far up/down


            // rotate the camera
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            // rotate the object that stores what direction we're facing
            orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            //rotate the player so that they can't turn around and see themself
            player.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
