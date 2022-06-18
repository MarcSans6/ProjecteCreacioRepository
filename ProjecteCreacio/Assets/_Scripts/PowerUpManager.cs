using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private HealthSystem healthSystem;
    private PlayerShoot playerShoot;

    public int AmmoAdded = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyPowerUp(string _powerUpType)
    {
        switch (_powerUpType)
        {
            case "Health":
                HealthPowerUp();
                break;
            case "Ammo":
                break;
            default:
                break;
        }
    }

    private void HealthPowerUp()
    {
    }
    private void AmmoPowerUp()
    {
        playerShoot.CurrentAmmo += AmmoAdded;
    }

}
