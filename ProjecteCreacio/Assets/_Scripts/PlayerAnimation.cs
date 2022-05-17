using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Animator playerAnimator;
    public NewMovement newMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        newMovement = GetComponent<NewMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spriteRenderer.flipX = newMovement.isFlipped;
        playerAnimator.SetBool("Run", newMovement.isRunning);
    }

    
}
