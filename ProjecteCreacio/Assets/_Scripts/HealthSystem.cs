using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    private Animator animator;

    public float m_MaxHealth = 9.0f;
    public float m_CurrentHealth;
    private bool m_IsDead;
    public AudioSource audioSource;
    public AudioClip DeadAudioClip;

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
        m_CurrentHealth = m_MaxHealth;
        m_IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateDead())
        {
            animator.SetBool("Dead", true);
            audioSource.PlayOneShot(DeadAudioClip);
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
