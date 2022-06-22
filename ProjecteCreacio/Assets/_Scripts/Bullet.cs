﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float Speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SetVelocity();
    }

    void SetVelocity()
    {
        _rigidbody.velocity = transform.right * Speed;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<IShootable>();

        if (enemy != null)
        {
            enemy.TakeDamage(99999);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
