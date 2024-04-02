using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {
    public float boxHeight;
    public LayerMask groundMask;
    public float drag;
    public float angularDrag;

    public bool isHeld;
    bool isGrounded;


    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }


    private void Update() {
        if (!isHeld) {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, boxHeight * 0.5f + 0.2f, groundMask);

            if (!isGrounded) {
                rb.drag = 0;
                rb.angularDrag = 0;
            }
            else {
                rb.drag = drag;
                rb.angularDrag = angularDrag;
                rb.mass = 500; //make sure the boxes can't be moved easily, even when the player is carrying another box
            }
        }
    }
}
