using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    public GameObject healthPU;
    public GameObject ammoPU;
    private Transform transform;
    private HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSystem.IsDead)
        {
            CreateRandomPowerUp();
        }
    }



    private void CreateRandomPowerUp()
    {
        if (Random.Range(1,3) == 1)
            Instantiate(healthPU, transform);
        else
            Instantiate(ammoPU, transform);
    }
}
