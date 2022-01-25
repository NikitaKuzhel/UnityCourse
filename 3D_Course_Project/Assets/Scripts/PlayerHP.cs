using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    [SerializeField] private Transform _respawnPoint;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        // Debug.Log("Taked damage");

        if (_currentHealth <= 0)
        {
            Debug.Log("Player Died!");
            transform.position = _respawnPoint.position;
        }
    }
}