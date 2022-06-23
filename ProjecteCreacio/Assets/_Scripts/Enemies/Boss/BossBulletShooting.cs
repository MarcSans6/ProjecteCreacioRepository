﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossBulletShooting : MonoBehaviour
{
    public Transform EnemyShotController;
    public Transform EnemyShotController02;
    public GameObject EnemyBulletPrefab;
    public GameObject EnemyBulletPrefab02;
    public System.Random alea = new System.Random();


    private InteligenceEnemy inteligenceEnemy;

    public float chargeTime = 1.0f;
    private float lastTimeFire;
    private void Start()
    {
        inteligenceEnemy = GetComponent<InteligenceEnemy>();

    }

    void Update()
    {
        if (inteligenceEnemy.isInAttackRange && lastTimeFire + chargeTime <= Time.time)
        {
            CreateEnemyBullet();
        }


    }

    private void CreateEnemyBullet()
    {
        int random;

        random = alea.Next(1, 11);

        if (random<=7)
        {
            Instantiate(EnemyBulletPrefab, EnemyShotController.transform.position, EnemyShotController.rotation);
            lastTimeFire = Time.time;
        }
        else
        {
            Instantiate(EnemyBulletPrefab02, EnemyShotController02.transform.position, EnemyShotController02.rotation);
            lastTimeFire = Time.time;
        }
        
    }


}