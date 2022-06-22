using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, IShootable
{
    public void TakeDamage(float amount)
    {
        Debug.Log("Au");
        Destroy(gameObject);
    }


}
