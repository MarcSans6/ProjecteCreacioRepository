using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
