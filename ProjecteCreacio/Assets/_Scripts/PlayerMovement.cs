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
    Vector2 m_MovementInput;

    public float RunSpeed
    {
        get => m_RunSpeed;
        set => m_RunSpeed = value;
    }
    public bool isFlipped
    {
        get => m_IsFlipped;
        set => m_IsFlipped = value;
    }
    public bool isRunning
    {
        get => m_IsRunning;
        set => m_IsRunning = value;
    }
    public Vector2 MovementDirection
    {
        get => m_MovementInput.normalized;
        set => m_MovementInput = value;
    }

    public void OnMove(InputValue inputValue)
    {
        Debug.Log("Player is moving");
        m_MovementInput = inputValue.Get<Vector2>();
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

        float horizontal = m_MovementInput.x;
        float vertical = m_MovementInput.y;

        if (horizontal > 0)
        {
            m_IsFlipped = false;
        }

        if (horizontal < 0)
        {
            m_IsFlipped = true;
        }

        if (m_MovementInput != Vector2.zero) m_IsRunning = true;
        else m_IsRunning = false;

        m_MovementInput.Normalize();

        rigidBody2D.velocity = m_MovementInput * m_RunSpeed;

    }
}
