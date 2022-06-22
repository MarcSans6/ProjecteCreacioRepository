using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03BulletShooting : MonoBehaviour
{
    public Transform EnemyShotController;
    public GameObject EnemyBulletPrefab;

    private IntelligenceEnemy03 inteligenceEnemy03;

    public float chargeTime = 1.0f;
    private float lastTimeFire;
    private void Start()
    {
        inteligenceEnemy03 = GetComponent<IntelligenceEnemy03>();
    }

    void Update()
    {
        if (inteligenceEnemy03.isInAttackRange && lastTimeFire + chargeTime <= Time.time)
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
