using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerShoot playerShoot;
    Rigidbody2D rigidBody2D;
    public float runSpeed = 3.0f;
    public bool isFlipped;
    public bool isRunning;


    Vector2 movementInput;
    public void OnMove(InputValue inputValue)
    {
        Debug.Log("Move");
        movementInput = inputValue.Get<Vector2>();
    }

    public void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    void FixedUpdate()
    {
        if (playerShoot.isShooting)
        {
            rigidBody2D.velocity = Vector3.zero;
            isRunning = false;
            return;
        }

        Vector3 movement = movementInput;

        float horizontal = movementInput.x;
        float vertical = movementInput.y;

        if (horizontal > 0)
        {
            isFlipped = false;
        }

        if (horizontal < 0)
        {
            isFlipped = true;
        }

        if (movement != Vector3.zero) isRunning = true;
        else isRunning = false;

        movement.Normalize();

        rigidBody2D.velocity = movement * runSpeed;

    }
}
