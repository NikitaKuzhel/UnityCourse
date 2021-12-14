using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;

    [SerializeField] private GameManager gameManager;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Player Died!");
            gameManager.GameOver();
        }
    }
}
