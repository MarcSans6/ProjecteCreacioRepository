using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    particleSystem.Play();
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    particleSystem.Stop();
    //}
}
