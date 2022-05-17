﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform shotControler;
    [SerializeField] private GameObject bullet;
    GameObject player;

    public bool isShooting;
    public float chargeTime = 0.5f;
    private float lastTimeFire;

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
        Instantiate(bullet, shotControler.position, shotControler.rotation);
        lastTimeFire = Time.time;
    }
}
