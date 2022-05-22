using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shotControler;
    public GameObject bullet;

    public bool isShooting;
    public float chargeTime = 0.5f;
    private float lastTimeFire;

    
    public void Update()
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
