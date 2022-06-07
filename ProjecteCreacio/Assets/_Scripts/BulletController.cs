using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerMovement;
    private Rigidbody2D rigidbody;

    public float m_Speed = 10.0f;
    public float m_BulletPlayerOffset;
    private Vector3 m_SpawnPosition;
    private float m_SpawnRotation;

    public Vector3 position
    {
        get => m_SpawnPosition;
        set => m_SpawnPosition = value;
    }
    public float rotation
    {
        get => m_SpawnRotation;
        set => m_SpawnRotation = value;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        rigidbody = GetComponent<Rigidbody2D>();
        SetVelocity();
    }
    public void Update()
    {
        SetRotation();
        SetPosition();
    }
    void SetVelocity()
    {
        rigidbody.velocity = transform.right * m_Speed;
    }
    void SetRotation()
    {
        float angle = Vector2.SignedAngle(Vector2.right, playerMovement.MovementDirection);
        m_SpawnRotation = angle;
    }
    void SetPosition()
    {
        Vector3 vectorOffset = playerMovement.MovementDirection * m_BulletPlayerOffset;

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


