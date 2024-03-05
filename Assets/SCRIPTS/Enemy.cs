﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    [SerializeField]GameObject[] checkpoints;
    Vector2 siguientePosicion;
    float velocidad = 3.5f;
    float distanciaCambio = 0.5f;
    int numeroSiguienteCheckpoint = 0;

    
    void Start(){
        checkpoints = GameObject.FindGameObjectsWithTag("WayPoint");


    Array.Sort(checkpoints, (GameObject checkpoint1, GameObject checkpoint2) =>
        {
            return string.Compare(checkpoint1.name, checkpoint2.name);
        });

            }
    
    void Update()
    {
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
