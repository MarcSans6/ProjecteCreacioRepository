﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    Vector2 movementInput;
    public void OnMove(InputValue inputValue)
    {
        Debug.Log("Move");
        movementInput = inputValue.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        float horizontal = movementInput.x;
        float vertical = movementInput.y;

        if (horizontal > 0)
        {
            movement += Vector3.right;
        }

        if (horizontal < 0)
        {
            movement -= Vector3.right;
        }

        if (vertical > 0)
        {
            movement += Vector3.forward;
        }

        if (vertical < 0)
        {
            movement -= Vector3.forward;
        }

        movement.Normalize();

        transform.position += movement * Time.deltaTime;
    }
}
