using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D bulletRigidbody;
    public BulletController bulletController;


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
        if (m_IsShooting && m_LastTimeFire + m_BulletChargeTime <= Time.time)
        {
            Debug.Log("Player is shooting");
            CreateBullet();
        }
    }
    public void OnShootStart()
    {
        m_IsShooting = true;
    }
    public void OnShootEnd()
    {
        m_IsShooting = false;
    }
    private void CreateBullet()
    {
        Instantiate(bullet, bulletController.position, Quaternion.AngleAxis(bulletController.rotation, Vector3.forward));
        m_LastTimeFire = Time.time;
    }
}
