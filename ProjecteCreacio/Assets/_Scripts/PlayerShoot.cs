using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Transform shotControler;
    private GameObject bullet;
    Rigidbody2D rigidbody2D;

    public bool isShooting;
    public float chargeTime = 0.5f;
    private float lastTimeFire;

    private void Start()
    {
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        if (isShooting && lastTimeFire + chargeTime <= Time.time)
        {
            Debug.Log("Shoot");
            CreateBullet();
        }
    }
    public void OnShootStart()
    {
        isShooting = true;
    }
    public void OnShootEnd()
    {
        isShooting = false;
    }
    private void CreateBullet()
    {
        Instantiate(bullet, bullet., shotControler.rotation);
        lastTimeFire = Time.time;
    }
}
