﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Animator playerAnimator;
    PlayerMovement playerMovement;
    PlayerShoot playerShoot;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = playerMovement.IsFlipped;
        playerAnimator.SetBool("Run", playerMovement.IsRunning);
        playerAnimator.SetBool("Shoot", playerShoot.IsShooting);
    }

    
}
