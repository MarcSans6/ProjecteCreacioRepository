using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet02 : MonoBehaviour
{
    private Transform player;
    private Transform enemy;
    private Rigidbody2D _rigidbody;
    public float Speed = 10;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Boss").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();

        dir = player.position - enemy.position;
        dir.Normalize();

        SetVelocity(dir);
        SetRotation(dir);
    }

    void SetVelocity(Vector3 dir)
    {
        _rigidbody.velocity = dir * Speed;
    }

    void SetRotation(Vector3 dir)
    {
        if (dir.y >= 0)
        {
            _rigidbody.rotation = Vector3.Angle(new Vector3(1, 0), dir);
        }
        else
        {
            _rigidbody.rotation = Vector3.Angle(new Vector3(-1, 0), dir);
        }
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
