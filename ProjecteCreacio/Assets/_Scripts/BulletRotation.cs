using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    PlayerMovement playerMovement;

    Vector2 aimInput;
    Vector2 aim;
    float angleToRotate;
    Quaternion rotation;

    public void OnAim(InputValue inputValue)
    {
        Debug.Log("Aim");
        aimInput = inputValue.Get<Vector2>();
    }
    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        aim = aimInput;

        float horizontal = aimInput.x;
        float vertical = aimInput.y;
        

        aim.Normalize();

        angleToRotate = Vector2.SignedAngle(Vector2.right, aim);
        rotation = Quaternion.AngleAxis(angleToRotate, Vector3.forward);
        transform.rotation = rotation;  
        
        if (horizontal > 0)
        {
            playerMovement.isFlipped = false;
        }

        if (horizontal < 0)
        {
            playerMovement.isFlipped = true;
        }
    }
}
