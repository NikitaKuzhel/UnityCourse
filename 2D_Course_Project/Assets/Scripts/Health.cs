using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public PlayerHP playerHP;

    public HealthBar healthBar;

    [SerializeField] private int potion = 40;

    [SerializeField] private AudioClip healthSound;
    private AudioSource audioSource;

    private void Awake()
    {
        playerHP = FindObjectOfType<PlayerHP>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerHP.currentHealth < playerHP.maxHealth)
        {
            // Проигрыш звука
            audioSource.PlayOneShot(healthSound, 1f);

            Destroy(gameObject, 0.1f);
            playerHP.currentHealth += potion;

            if (playerHP.currentHealth > 100)
            {
                playerHP.currentHealth = 100;
            }


            healthBar.SetHealth(playerHP.currentHealth);
        }
    }
}
