using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerShoot playerShoot;
    Rigidbody2D rigidBody2D;
    public float m_RunSpeed = 3.0f;
    public bool m_IsFlipped;
    public bool m_IsRunning;

    Vector2 movementInput;

    public Vector2 MovementDirection
    {
        get => movementInput;
        set => movementInput = value;
    }
    public void OnMove(InputValue _inputValue)
    {
        Debug.Log("Move");
        movementInput = _inputValue.Get<Vector2>();
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
            m_IsRunning = false;
            return;
        }

        Vector3 movement = movementInput;

        float horizontal = movementInput.x;
        float vertical = movementInput.y;

        if (horizontal > 0)
        {
            m_IsFlipped = false;
        }

        if (horizontal < 0)
        {
            m_IsFlipped = true;
        }

        if (movement != Vector3.zero) m_IsRunning = true;
        else m_IsRunning = false;

        movement.Normalize();

        rigidBody2D.velocity = movement * m_RunSpeed;

    }
}
