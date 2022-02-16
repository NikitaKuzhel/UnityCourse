using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int attackDamage = 40;

    [SerializeField] private float attackRate = 2f; // сколько раз можно ударить в секунду
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        
        }
    }

    void Attack()
    {
        // Определяет игрока в зоне для атаки
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        // Наносит урон
        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("We hit " + player.name);
            player.GetComponent<PlayerHP>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
