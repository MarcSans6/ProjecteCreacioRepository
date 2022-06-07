using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shotControler;
    public GameObject bullet;
    private Rigidbody2D bulletRigidbody;
    public BulletController bulletController;

    public bool m_isShooting;
    public float m_chargeTime = 0.5f;
    private float m_lastTimeFire;

    
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
    public void Update()
    {
        if (m_isShooting && m_lastTimeFire + m_chargeTime <= Time.time)
        {
            Debug.Log("Shoot");
            CreateBullet();
        }
    }
    public void OnShootStart()
    {
        m_isShooting = true;
    }
    public void OnShootEnd()
    {
        m_isShooting = false;
    }
    private void CreateBullet()
    {
        Instantiate(bullet, shotControler.position, shotControler.rotation);
        m_lastTimeFire = Time.time;
    }
}
