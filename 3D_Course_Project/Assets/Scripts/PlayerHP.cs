using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    [SerializeField] private float _secondsBeforeRegen = 2f;
    [SerializeField] private Transform _respawnPoint;
    private Coroutine _regen;

    [SerializeField] private HealthBar _healthBar;

    [SerializeField] LayerMask _redTeam;
    [SerializeField] LayerMask _blueTeam;

    void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            Debug.Log(gameObject.name + " died!");
            transform.position = _respawnPoint.position;
            _currentHealth = _maxHealth;
            _healthBar.SetHealth(_currentHealth);

            if (gameObject.tag == "Enemy")
            {
                RedTeamScore.scoreValue += 1;
            }

            if (gameObject.tag == "Player")
            {
                BlueTeamScore.scoreValue += 1;
            }
        }

        if (_regen != null)
        {
            StopCoroutine(_regen);
        }

        _regen = StartCoroutine(RegenHealth());
    }

    private IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(_secondsBeforeRegen);

        while (_currentHealth < _maxHealth)
        {
            _currentHealth += _maxHealth / 100;
            _healthBar.SetHealth(_currentHealth);
            yield return new WaitForSeconds(0.1f);
        }

        _regen = null;
    }
}