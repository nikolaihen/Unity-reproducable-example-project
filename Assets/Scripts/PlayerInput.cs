using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour {

    public float movementSpeed = 5f;
    public float jumpForce = 40f;

    PlayerController controller;

    void Start() {
        controller = GetComponent<PlayerController>();
    }

    void Update() {
        Vector2 moveVelocity = GetMovementInput();
        controller.Move(moveVelocity);

        if (Input.GetKeyDown(KeyCode.Space)) {
            controller.Jump(jumpForce);
        }
    }

    Vector2 GetMovementInput() {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        return moveInput.normalized * movementSpeed;
    }
}
