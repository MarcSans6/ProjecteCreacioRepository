using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class EnemyBulletShooting : MonoBehaviour
{
    public Transform EnemyShotController;
    public GameObject EnemyBulletPrefab;

    public float chargeTime = 0.5f;
    private float lastTimeFire;

    // Update is called once per frame
    void Update()
    {
        if (lastTimeFire + chargeTime <= Time.time)
        {
            Debug.Log("EnemyShoot");
            CreateEnemyBullet();
        }
    }

    private void CreateEnemyBullet()
    {
        Instantiate(EnemyBulletPrefab, EnemyShotController.transform.position, EnemyShotController.rotation);
        lastTimeFire = Time.time;
    }
}
