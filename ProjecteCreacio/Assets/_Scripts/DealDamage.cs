using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float Damage = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<HealthSystem>();
        if (health != null)
        {
            health.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
