using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{
    public float attackRange = 500f; // Rango de ataque de la torre
    public int damage = 10; // Daño que la torre hace a cada enemigo
    public float attackInterval = 1f; // Cuánto tiempo espera entre ataques

    private float attackTimer;

    void Start()
    {
        attackTimer = attackInterval; // Inicializa el temporizador de ataque
    }

    void Update()
    {
        attackTimer -= Time.deltaTime; // Actualiza el temporizador de ataque cada frame

        if (attackTimer <= 0)
        {
            Attack();
            attackTimer = attackInterval; // Reinicia el temporizador de ataque
        }
    }

    void Attack()
    {
        // Detecta todos los enemigos dentro del rango de ataque
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (var enemy in enemiesInRange)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja un círculo en el editor para visualizar el rango de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
