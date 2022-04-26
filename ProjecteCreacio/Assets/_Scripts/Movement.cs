using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float RunSpeed = 3f;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.Translate(new Vector2(RunSpeed * Time.deltaTime,0), Space.World);
            spriteRenderer.flipX = false;
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.Translate(new Vector2(-RunSpeed * Time.deltaTime, 0), Space.World);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            transform.Translate(new Vector2(0, RunSpeed * Time.deltaTime), Space.World);
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            transform.Translate(new Vector2(0, -RunSpeed * Time.deltaTime), Space.World);
        }

    }
}
