using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Damage : MonoBehaviour, IShootable
{
    public void TakeDamage(float amount)
    {
        Debug.Log("Au");
        Destroy(gameObject);
    }
}
