using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : MonoBehaviour
{
    PlayerShoot playerShoot;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerShoot.isShooting)
        {
            
        }
    }
}
