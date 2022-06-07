using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shotControler;
    public GameObject bullet;
<<<<<<< HEAD
=======
    private Rigidbody2D bulletRigidbody;
    public BulletController bulletController;
>>>>>>> 3b7299390a8457dcf556958a76783517fd929ee3

    public bool isShooting;
    public float chargeTime = 0.5f;
    private float lastTimeFire;

<<<<<<< HEAD
    
=======
    private bool m_IsShooting;
    public float m_BulletChargeTime = 0.5f;
    private float m_LastTimeFire;

    public bool isShooting
    {
        get => m_IsShooting;
        set => m_IsShooting = value;
    }
    public float BulletChargeTime
    {
        get => m_BulletChargeTime;
        set => m_BulletChargeTime = value;
    }
    public float LastTimeFire
    {
        get => m_LastTimeFire;
        set => m_LastTimeFire = value;
    }

    public void Start()
    {
        bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
    }
>>>>>>> 3b7299390a8457dcf556958a76783517fd929ee3
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
