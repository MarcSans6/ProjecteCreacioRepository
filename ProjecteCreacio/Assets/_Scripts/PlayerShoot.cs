using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public bool m_IsShooting;
    public float m_BulletChargeTime = 0.5f;
    private float m_LastTimeFire;
    public GameObject mainCharacterBullet;
    public BulletController bulletController;


    public bool IsShooting
    {
        get => m_IsShooting;
        set => m_IsShooting = value;
    }

    public void Start()
    {
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
        Debug.Log("Create bullet starts");
        Instantiate(mainCharacterBullet, bulletController.Position, Quaternion.AngleAxis(bulletController.Rotation, Vector3.forward));
        m_LastTimeFire = Time.time;
        Debug.Log("create bullet ends");

    }
}
