using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Animator playerAnimator;
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spriteRenderer.flipX = playerMovement.isFlipped;
        playerAnimator.SetBool("Run", playerMovement.isRunning);
    }

    
}
