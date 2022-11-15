using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;
    private bool isBlinking;
    [SerializeField] float blinkingDuration;
    private float blinkingCounter;
    private SpriteRenderer _characterRenderer;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMaxHealth(maxHealth);
        _characterRenderer = GetComponent<SpriteRenderer>();

    }


    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        if (blinkingDuration > 0)
        {
            isBlinking = true;
            blinkingCounter = blinkingDuration;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerController>().canMove = false;
        }

    }
    private void ToggleColor(bool isVisible)
    {
        Color color = _characterRenderer.color;
        color = new Color(color.r, color.g, color.b,
         isVisible ? 1 : 0);
        _characterRenderer.color = color;
    }
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (isBlinking)
        {
            blinkingCounter -= Time.deltaTime; if (blinkingCounter > blinkingDuration * 0.8)
            {
                ToggleColor(false);
            }
            else if (blinkingCounter > blinkingDuration * 0.6)
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > blinkingDuration * 0.4)
            {
                ToggleColor(false);
            }
            else if (blinkingCounter > blinkingDuration * 0.2)
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > 0)
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                isBlinking = false;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlayerController>().canMove = true;

            }
        }
    }
}


