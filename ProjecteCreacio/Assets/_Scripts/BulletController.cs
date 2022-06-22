using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement playerMovement;

    public float m_Speed = 10.0f;
    public float m_BulletPlayerOffset;
    private Vector3 m_SpawnPosition;
    private float m_SpawnRotation;

    public Vector3 Position
    {
        get => m_SpawnPosition;
        set => m_SpawnPosition = value;
    }
    public float Rotation
    {
        get => m_SpawnRotation;
        set => m_SpawnRotation = value;
    }

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    public void Update()
    {
        SetRotation();
        SetPosition();
    }
   
    void SetRotation()
    {
        
        float angle = Vector2.SignedAngle(Vector2.right, playerMovement.Direction);
        m_SpawnRotation = angle;
    }
    void SetPosition()
    {
        Vector3 vectorOffset = playerMovement.Direction * m_BulletPlayerOffset;

        m_SpawnPosition = player.transform.position + vectorOffset;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<IShootable>();

        if (enemy != null)
        {
            enemy.TakeDamage(99999);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}


