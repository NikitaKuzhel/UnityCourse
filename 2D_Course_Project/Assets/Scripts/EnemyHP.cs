using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;
    private int currentHealth;

    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip death;
    private AudioSource audioSource;

    void Start()
    {
        currentHealth = MaxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Проигрыш звука
        audioSource.PlayOneShot(hit, 1f);

        if (currentHealth <= 0)
        {
            Debug.Log("Enemy Died!");
            audioSource.PlayOneShot(death, 1f);
            Destroy(gameObject, 0.3f);
        }
    }
}
