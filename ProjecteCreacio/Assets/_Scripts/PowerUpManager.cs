﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject player;
    private HealthSystem playerHealthSystem;
    private PlayerShoot playerShoot;
    private DropObjects dropObjects;

    public int AmmoAdded = 10;
    public float HealthAdded = 3.0f;

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
        Debug.Log("StartsHealthAdded");
        playerHealthSystem.CurrentHealth += HealthAdded;
        Debug.Log("EndsHealthAdded");

    }
    private void AmmoPowerUp()
    {
        playerShoot.CurrentAmmo += AmmoAdded;
    }

}
