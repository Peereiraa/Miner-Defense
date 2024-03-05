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


    System.Array.Sort(checkpoints, (x, y) =>
{
    int comparacionX = x.transform.position.x.CompareTo(y.transform.position.x);
    if (comparacionX == 0)
    {
        // Si las coordenadas X son iguales, compara las coordenadas Y
        return x.transform.position.y.CompareTo(y.transform.position.y);
    }
    else
    {
        return comparacionX; // Si las coordenadas X son diferentes, devuelve la comparación de las X
    }
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
