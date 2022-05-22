﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Animator playerAnimator;
    PlayerMovement playerMovement;
    PlayerIsDead playerIsDead;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerIsDead = GetComponent<PlayerIsDead>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = playerMovement.isFlipped;
        playerAnimator.SetBool("Run", playerMovement.isRunning);
        playerAnimator.SetBool("Dead", playerIsDead.isDead);
    }

    
}
