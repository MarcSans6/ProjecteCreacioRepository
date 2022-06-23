using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    private HealthSystem healthSystem;
    public SpriteRenderer childrenSpriteRenderer;

    public Sprite h00, h01, h02, h03, h04, h05, h06, h07, h08, h09, h10;
    private Sprite[] healthBarArray;
    void Start()
    {
        h10 = h09;
        healthSystem = GetComponentInParent<HealthSystem>();
        healthBarArray = new Sprite[] { h00, h01, h02, h03, h04, h05, h06, h07, h08, h09, h10};
    }

    // Update is called once per frame
    void Update()
    {
        childrenSpriteRenderer.sprite = healthBarArray[(int)healthSystem.CurrentHealth];
    }
}
