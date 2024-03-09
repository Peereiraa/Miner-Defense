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
    private bool isDying = false; // Nuevo flag para controlar si el enemigo está muriendo

    public int health = 100; // Salud inicial del enemigo

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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

    private void Die()
    {
        if (isDying) return; // Previene que la muerte se procese múltiples veces

        isDying = true; // Establece el estado a muriendo
        animator.SetTrigger("Die");

        // Desactiva componentes para prevenir más interacciones o movimientos
        GetComponent<Collider2D>().enabled = false; // Asume uso de Collider2D para juego 2D

        // Considera desactivar otros componentes, como scripts de movimiento o IA

        // Espera para destruir el objeto hasta que la animación de muerte se haya completado
        // Ajusta este tiempo según la duración de tu animación de muerte
    }
    void Start()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("WayPoint");


        Array.Sort(checkpoints, (GameObject checkpoint1, GameObject checkpoint2) =>
            {
                return string.Compare(checkpoint1.name, checkpoint2.name);
            });

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
