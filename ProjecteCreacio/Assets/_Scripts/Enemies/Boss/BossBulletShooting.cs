using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossBulletShooting : MonoBehaviour
{
    public Transform enemyShotController01;
    public Transform enemyShotController02;
    public GameObject enemyBulletPrefab01;
    public GameObject enemyBulletPrefab02;  
    private EnemyBullet enemyBullet01;
    private EnemyBullet enemyBullet02;

    public System.Random alea = new System.Random();


    private InteligenceEnemy inteligenceEnemy;

    public float chargeTime = 1.0f;
    private float lastTimeFire;
    private void Start()
    {
        inteligenceEnemy = GetComponent<InteligenceEnemy>();
        enemyBullet01 = enemyBulletPrefab01.GetComponent<EnemyBullet>();
        enemyBullet02 = enemyBulletPrefab02.GetComponent<EnemyBullet>();
        

    }

    void Update()
    {
        if (inteligenceEnemy.isInAttackRange && lastTimeFire + chargeTime <= Time.time)
        {
            enemyBullet01.shotControllerPosition = enemyShotController01.position;
            enemyBullet02.shotControllerPosition = enemyShotController02.position;
            CreateEnemyBullet();
        }


    }

    private void CreateEnemyBullet()
    {
        int random;

        random = alea.Next(1, 11);

        if (random<=7)
        {
            Instantiate(enemyBulletPrefab01, enemyShotController01.position, enemyShotController01.rotation);
            lastTimeFire = Time.time;
        }
        else
        {
            Instantiate(enemyBulletPrefab02, enemyShotController02.position, enemyShotController02.rotation);
            lastTimeFire = Time.time;
        }
        
    }


}
