using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;
    private BoxCollider2D playerCollider;
    public PowerUpManager powerUpManager;
    private BoxCollider2D collider;
    private Transform transform;

    public float m_Radius = 1.0f;
    public float m_FinalSpeed = 3.0f;
    private float m_CurrentSpeed;
    private float m_MaxScale = 1.0f;
    private float m_MinScale = 0.1f;
    public float m_ReductionTime = 1.0f;
    private float m_CurrentReductionTime = 0.0f;
    private bool m_Reducted = false;

    private string m_PowerUpTag;

    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        transform = GetComponent<Transform>();
        collider = GetComponent<BoxCollider2D>();
        m_PowerUpTag = name;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckIfPlayerInRadius())
        {
            PickUpMovement();
            if (CheckIfCollidesWithPLayer())
            {
                ReduceScale();
                if (m_Reducted)
                {
                   Destroy(gameObject);
                   powerUpManager.ApplyPowerUp(m_PowerUpTag);
                }
            }
        }
    }

    private bool CheckIfPlayerInRadius()
    {
        return (playerTransform.position - transform.position).magnitude <= m_Radius;
    }

    private void PickUpMovement()
    {
        m_CurrentSpeed = Mathf.Lerp(0.0f,m_FinalSpeed, m_Radius/ (playerTransform.position - transform.position).magnitude);
        transform.position += (playerTransform.position - transform.position).normalized * m_CurrentSpeed * Time.deltaTime;
    }

    private bool CheckIfCollidesWithPLayer()
    {
        return collider.IsTouching(playerCollider);
    }

    private void ReduceScale()
    {
        transform.localScale *= 1.0f;

        m_CurrentReductionTime += Time.deltaTime;
        
        float scale = Mathf.Lerp(m_MaxScale, m_MinScale, m_ReductionTime / m_CurrentReductionTime);
        transform.localScale *= scale;
        if (scale <= m_MinScale)
        {
            m_Reducted = true;
        }
    }
}
