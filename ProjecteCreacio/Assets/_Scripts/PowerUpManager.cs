using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject player;
    private HealthSystem playerHealthSystem;
    private PlayerShoot playerShoot;
    private DropObjects dropObjects;

    public int AmmoAdded = 10;

    public GameObject Player
    {
        get => player;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHealthSystem = player.GetComponent<HealthSystem>();
        playerShoot = player.GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            HealthSystem eHealthSystem = enemy.GetComponent<HealthSystem>();
            if (eHealthSystem != null)
            {
                if (eHealthSystem.IsDead)
                {
                    dropObjects.CreateRandomPowerUp();
                }
            }
        }
    }

    public void ApplyPowerUp(string _powerUpType)
    {
        switch (_powerUpType)
        {
            case "HealthPU":
                HealthPowerUp();
                break;
            case "AmmoPU":
                AmmoPowerUp();
                break;
            default:
                break;
        }
    }

    private void HealthPowerUp()
    {
        playerHealthSystem.CurrentHealth += 3;
    }
    private void AmmoPowerUp()
    {
        playerShoot.CurrentAmmo += AmmoAdded;
    }

}
