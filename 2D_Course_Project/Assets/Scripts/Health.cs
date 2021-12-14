using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    PlayerHP playerHP;

    int potion = 20;

    private void Awake()
    {
        playerHP = FindObjectOfType<PlayerHP>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerHP.currentHealth < playerHP.MaxHealth)
        {
            Destroy(gameObject);
            playerHP.currentHealth += potion;
        }
    }
}
