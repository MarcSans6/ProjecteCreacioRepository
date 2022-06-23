using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class EnemyBulletShooting : MonoBehaviour
{
    public Transform enemyShotController;
    public GameObject EnemyBulletPrefab;
    private EnemyBullet enemyBullet;
    

    private InteligenceEnemy inteligenceEnemy;

    public float chargeTime = 1.0f;
    private float lastTimeFire;
    private void Start()
    {
        inteligenceEnemy = GetComponent<InteligenceEnemy>();
        enemyBullet = EnemyBulletPrefab.GetComponent<EnemyBullet>();
        enemyShotController = GetComponentInChildren<Transform>();
        
    }

    void Update()
    {
        if (inteligenceEnemy.isInAttackRange && lastTimeFire + chargeTime <= Time.time)
        {
            enemyBullet.shotControllerPosition = enemyShotController.transform.position;
            CreateEnemyBullet();
        }

        
    }

    private void CreateEnemyBullet()
    {
        
        Instantiate(EnemyBulletPrefab, enemyShotController.transform.position, enemyShotController.rotation);
        lastTimeFire = Time.time;
    }
        
    
}
