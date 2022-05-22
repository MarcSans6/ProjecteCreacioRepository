using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class PlayerIsDead : MonoBehaviour
{
    private HealthSystem health;
    public bool isDead;
    public int time = 1000;

    void Awake()
    {
        health = GetComponent<HealthSystem>();    
    }

    private void OnEnable()
    {
        health.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        health.OnDeath -= OnDeath;
    }

    private void OnDeath()
    {
        Debug.Log("Player death!");
        isDead = true;
        Destroy(gameObject);
    }
}
