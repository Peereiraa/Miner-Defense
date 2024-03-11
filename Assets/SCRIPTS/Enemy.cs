﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] checkpoints;
    private Vector2 siguientePosicion;
    private float velocidad = 3.5f;
    private float distanciaCambio = 0.5f;
    private int numeroSiguienteCheckpoint = 0;

    private Animator animator;
    private bool isDying = false; 

    public int health = 100; 
    public int baseHealth = 100; 

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Llamado para aplicar daño al enemigo
    public void TakeDamage(int damage)
    {
        if (isDying) return; // Previene recibir daño si ya está muriendo

        health -= damage;
        Debug.Log(gameObject.name + " recibió " + damage + " de daño.");

        if (health <= 0)
        {
            Die();
        }
    }

    // Establece la salud inicial del enemigo basándose en un factor de oleada
    public void SetInitialHealth(int waveFactor)
    {
        health = baseHealth + (waveFactor * 10); // Incrementa la salud base en 10 por cada oleada
        Debug.Log(gameObject.name + " salud inicial ajustada a: " + health);
    }

    // Procesa la muerte del enemigo
    private void Die()
{
    if (isDying) return; // Previene que la muerte se procese múltiples veces

    isDying = true; // Establece el estado a muriendo
    animator.SetTrigger("Die");

    // Desactiva componentes para prevenir más interacciones o movimientos
    GetComponent<Collider2D>().enabled = false;

    // Decrementa el contador de enemigos restantes en la oleada actual
    GameManager.instance.spawnController.DecrementarEnemigosRestantes();

    Destroy(gameObject, 1.55f); // Destruye el objeto después de la animación de muerte
}

    void Start()
{
    // Inicialización de checkpoints
    checkpoints = GameObject.FindGameObjectsWithTag("WayPoint");

    Array.Sort(checkpoints, (checkpoint1, checkpoint2) => 
        string.Compare(checkpoint1.name, checkpoint2.name));

    // Reinicia el contador de checkpoints al comenzar una nueva oleada
    numeroSiguienteCheckpoint = 0;
}

    void Update()
    {
        if(isDying) return;
        Console.WriteLine(checkpoints[numeroSiguienteCheckpoint].transform.position);
        // Si no hay checkpoints, no hagas nada
        if (checkpoints.Length == 0)
            return;

        // Actualiza siguientePosicion antes de mover al enemigo hacia ese checkpoint
        siguientePosicion = checkpoints[numeroSiguienteCheckpoint].transform.position;

        // Mueve al enemigo hacia el siguiente checkpoint
        transform.position = Vector2.MoveTowards(
            transform.position,
            siguientePosicion,
            velocidad * Time.deltaTime);

        // Si el enemigo llega al checkpoint, pasa al siguiente
        if (Vector2.Distance(transform.position, siguientePosicion) < distanciaCambio)
        {
            numeroSiguienteCheckpoint++;
            if (numeroSiguienteCheckpoint >= checkpoints.Length)
                numeroSiguienteCheckpoint = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("PerderVida");
    }
}