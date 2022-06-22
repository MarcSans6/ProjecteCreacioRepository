using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Bullet : MonoBehaviour
{
    private Transform player;
    private Transform enemy;
    private Rigidbody2D _rigidbody;
    public float Speed = 10;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy03").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();

        dir = player.position - enemy.position;
        dir.Normalize();

        SetVelocity(dir);
    }

    void SetVelocity(Vector3 dir)
    {
        _rigidbody.velocity = dir * Speed;
    }


    // Update is called once per frame
    void Update()
    {

    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
