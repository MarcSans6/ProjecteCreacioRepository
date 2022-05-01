﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float RunSpeed = 3f;
    public SpriteRenderer spriteRenderer;
    public Animator playerAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.Translate(new Vector2(RunSpeed * Time.deltaTime,0), Space.World);
            spriteRenderer.flipX = false;
            playerAnimator.SetBool("Run", true);
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.Translate(new Vector2(-RunSpeed * Time.deltaTime, 0), Space.World);
            spriteRenderer.flipX = true;
            playerAnimator.SetBool("Run", true);
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            transform.Translate(new Vector2(0, RunSpeed * Time.deltaTime), Space.World);
            playerAnimator.SetBool("Run", true);
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            transform.Translate(new Vector2(0, -RunSpeed * Time.deltaTime), Space.World);
            playerAnimator.SetBool("Run", true);
        }

    }
}
