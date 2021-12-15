using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public PlayerHP playerHP;

    public HealthBar healthBar;

    [SerializeField] private int potion = 40;

    private void Awake()
    {
        playerHP = FindObjectOfType<PlayerHP>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerHP.currentHealth < playerHP.maxHealth)
        {
            Destroy(gameObject);
            playerHP.currentHealth += potion;

            if (playerHP.currentHealth > 100)
            {
                playerHP.currentHealth = 100;
            }


            healthBar.SetHealth(playerHP.currentHealth);
        }
    }
}
