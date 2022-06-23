using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    private bool m_HasToDrop = true;
    public GameObject healthPU;
    public GameObject ammoPU;
    private Transform transform;
    private EnemyHealthSystem enemyHealthSystem;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        enemyHealthSystem = GetComponent<EnemyHealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_HasToDrop)
        {
            if (enemyHealthSystem.IsDead)
            {
                CreateRandomPowerUp();
                m_HasToDrop = false;
            }
        }
        
    }
    public void CreateRandomPowerUp()
    {
        if (Random.Range(1,3) == 1)
            Instantiate(healthPU, transform.position, transform.rotation);
        else
            Instantiate(ammoPU, transform.position, transform.rotation);
    }
}
