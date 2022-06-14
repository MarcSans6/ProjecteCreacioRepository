using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider2D collider2D;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

    }

    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }
    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
    public void UnableCollider()
    {
        collider2D.isTrigger = true;
    }
    public void AbleCollider()
    {
        collider2D.isTrigger = false;
    }
}