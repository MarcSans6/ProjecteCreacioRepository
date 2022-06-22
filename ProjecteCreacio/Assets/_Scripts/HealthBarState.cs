using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Sprites;

public class HealthBarState : MonoBehaviour
{
    private int currentHealth;
    private HealthSystem healthSystem;
    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void Start()
    {
        healthSystem = GetComponentInParent<HealthSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteArray = Resources.LoadAll<Sprite>("ui x3");

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = (int)healthSystem.CurrentHealth;
        spriteRenderer.sprite = ChangeSprite(currentHealth);
       
    }

    private Sprite ChangeSprite(int currentHealth)
    {
        return spriteArray[currentHealth];
    }
}
