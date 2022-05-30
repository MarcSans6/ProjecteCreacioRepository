﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Animator playerAnimator;
    PlayerMovement playerMovement;
    PlayerIsDead playerIsDead;
    PlayerShoot playerShoot;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerIsDead = GetComponent<PlayerIsDead>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = playerMovement.isFlipped;
        playerAnimator.SetBool("Run", playerMovement.isRunning);
        playerAnimator.SetBool("Dead", playerIsDead.isDead);
        playerAnimator.SetBool("Shoot", playerShoot.isShooting);
    }

    
}