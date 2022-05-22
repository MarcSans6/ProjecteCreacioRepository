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

    private Transform target;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Vector2 movement;
    public Vector3 direction;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        animator.SetBool("isRunning", isInChaseRange);
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

    private void MoveCharacter(Vector2 dir)
    {
        rigidbody.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

}