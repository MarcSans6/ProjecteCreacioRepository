﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteligenceEnemy : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;
    

    public bool shouldRotate;

    public LayerMask whatIsplayer;

    private SpriteRenderer spriteRenderer;
    private Transform target;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Vector2 movement;
    public Vector3 direction;

    private bool isInChaseRange;
    public bool isInAttackRange;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        AnimationManager();
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsplayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsplayer);

        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;

        if (shouldRotate)
        {
            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
        }

        SetFlipX();
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !(isInAttackRange))
        {
            MoveCharacter(movement);
        }
        if (isInAttackRange)
        {
            rigidbody.velocity = Vector2.zero;
        }
    }

    private void SetFlipX()
    {
        spriteRenderer.flipX = target.position.x - transform.position.x < 0;
    }
    private void AnimationManager()
    {
        if (isInChaseRange)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);
        if (isInAttackRange)
            animator.SetBool("isAttacking", true);
        else
            animator.SetBool("isAttacking", false);
    }
    private void MoveCharacter(Vector2 dir)
    {
        rigidbody.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

}
