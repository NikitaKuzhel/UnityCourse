using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonHP : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Enemy Died!");
            Destroy(gameObject);
        }
    }
}
