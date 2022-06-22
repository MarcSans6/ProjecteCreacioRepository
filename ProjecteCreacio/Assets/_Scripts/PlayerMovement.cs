using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerShoot playerShoot;
    Rigidbody2D rigidBody2D;
    HealthSystem healthSystem;
    public float m_RunSpeed = 3.0f;
    private bool m_IsFlipped;
    private bool m_IsRunning;
    private Vector2 m_Direction;

    Vector2 m_MovementInput;

    public bool IsFlipped
    {
        get => m_IsFlipped;
        set => m_IsFlipped = value;
    }
    public bool IsRunning
    {
        get => m_IsRunning;
        set => m_IsRunning = value;
    }
    public Vector2 Direction
    {
        get => m_Direction;
        set => m_Direction = value;
    }
    public Vector2 MovementDirection
    {
        get => m_MovementInput;
        set => m_MovementInput = value;
    }
    public void OnMove(InputValue _inputValue)
    {
        
        m_MovementInput = _inputValue.Get<Vector2>();
    }

    public void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerShoot = GetComponent<PlayerShoot>();
        healthSystem = GetComponent<HealthSystem>();
    }

    void FixedUpdate()
    {
        m_Direction = m_MovementInput;

        if (playerShoot.IsShooting || healthSystem.IsDead)
        {
            rigidBody2D.velocity = Vector3.zero;
            m_IsRunning = false;
            return;
        }

        Vector3 movement = m_MovementInput;

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

        if (movement != Vector3.zero) m_IsRunning = true;
        else m_IsRunning = false;

        movement.Normalize();

        rigidBody2D.velocity = movement * m_RunSpeed;

    }
}
