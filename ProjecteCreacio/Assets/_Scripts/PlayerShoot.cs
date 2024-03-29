﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int m_MaxAmmo = 30;
    public int m_Ammo;
    public float m_AddAmmoTime = 1.0f;
    private bool m_IsShooting;
    public float m_BulletChargeTime = 0.5f;
    private float m_LastTimeFire;
    private float m_LastTimeAddAmmo;
    public GameObject mainCharacterBullet;
    public BulletController bulletController;
    public AudioSource audioSource;
    public AudioClip shootingAudioClip;

    public int CurrentAmmo
    {
        get => m_Ammo;
        set => m_Ammo = value;
    }
    public bool IsShooting
    {
        get => m_IsShooting;
        set => m_IsShooting = value;
    }

    public void Start()
    {
        m_Ammo = m_MaxAmmo;
    }
    public void Update()
    {
        Shoot();
        ManageMaxAmmo();
        //AutomaticAdd1Ammo();
    }
    public void OnShootStart()
    {
        if (m_Ammo > 0)
        {
           m_IsShooting = true;
        }
    }
    public void OnShootEnd()
    {
        if (m_Ammo > 0)
        {
           m_IsShooting = false;
        }
    }
    private void CreateBullet()
    {
        Instantiate(mainCharacterBullet, bulletController.Position, Quaternion.AngleAxis(bulletController.Rotation, Vector3.forward));
        m_LastTimeFire = Time.time;
        m_Ammo -= 1;
    }

    private void AutoAdd1Ammo()
    {
        if (m_LastTimeAddAmmo + m_AddAmmoTime <= Time.time)
        {
            if (m_Ammo < m_MaxAmmo)
            {
                m_Ammo++;
                m_LastTimeAddAmmo = Time.time;
            }
        }
    }
    private void AddAmmo(int amount)
    {
        m_Ammo += amount;
    }
    private void Shoot()
    {
        if (m_IsShooting && m_LastTimeFire + m_BulletChargeTime <= Time.time && m_Ammo > 0)
        {
            Debug.Log("Player is shooting");
            audioSource.PlayOneShot(shootingAudioClip);
            CreateBullet();
        }
    }

    private void ManageMaxAmmo()
    {
        if (m_Ammo > m_MaxAmmo)
        {
            m_Ammo = m_MaxAmmo;
        }
    }
}
