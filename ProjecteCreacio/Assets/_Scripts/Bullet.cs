using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject particle;
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
        var enemy = other.GetComponent<EnemyHealthSystem>();

        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }

        if (other.gameObject.GetComponent<PlayerShoot>() == null)
        {
            DestroyBullet();
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void DestroyBullet()
    {
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
