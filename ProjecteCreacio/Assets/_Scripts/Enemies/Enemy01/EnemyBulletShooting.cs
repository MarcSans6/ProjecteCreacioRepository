using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class EnemyBulletShooting : MonoBehaviour
{
    public Transform EnemyShotController;
    public GameObject EnemyBulletPrefab;
    

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
        
        Instantiate(EnemyBulletPrefab, EnemyShotController.transform.position, EnemyShotController.rotation);
        lastTimeFire = Time.time;
    }
        
    
}
