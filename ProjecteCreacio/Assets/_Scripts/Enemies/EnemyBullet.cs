using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D _rigidbody;
    public float Speed = 10;
    public Transform enemy;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void SetVelocity(Vector3 dir)
    {
        _rigidbody.velocity = dir * Speed;
    }


    // Update is called once per frame
    void Update()
    {
        dir = player.position - enemy.position;
        dir.Normalize(); 
        
        SetVelocity(dir);
    }
}
