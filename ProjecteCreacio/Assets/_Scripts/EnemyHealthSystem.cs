﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour, IDamageTaker
{
    private Animator animator;
    private PowerUpManager powerUpManager;

    public float m_MaxHealth = 10.0f;
    private float m_CurrentHealth;
    private bool m_IsDead;

    public float CurrentHealth
    {
        get => m_CurrentHealth;
        set => m_CurrentHealth = value;
    }
    public bool IsDead
    {
        get => m_IsDead;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        powerUpManager = GameObject.FindObjectOfType<PowerUpManager>();
        m_CurrentHealth = m_MaxHealth;
        m_IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateDead())
        {
            animator.SetBool("Dead", true);
            powerUpManager.CreateRandomPowerUp(gameObject.transform);
        }


    }

    public virtual void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;
    }

    private bool UpdateDead()
    {
        m_IsDead = m_CurrentHealth <= 0;
        return m_IsDead;
    }
}