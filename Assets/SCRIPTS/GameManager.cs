using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI textoOleadas;
    public GameObject siguienteOleadaBoton; // Referencia al botón

    public SpawnOleadas spawnController;
    private int oleadaActual = -1; // Variable para mantener el seguimiento de la oleada actual

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        siguienteOleadaBoton.SetActive(true); // Activa el botón al inicio del juego
    }

    public void ComenzarOleada()
    {
        StartCoroutine(ComenzarOleadas());
        siguienteOleadaBoton.SetActive(false); // Desactiva el botón cuando comienza la oleada
    }

    IEnumerator ComenzarOleadas()
    {
        while (oleadaActual < spawnController.oleadas.Length - 1) // Ajuste aquí para evitar un índice fuera de rango
        {
            oleadaActual++; // Incrementa el contador de la oleada actual antes de iniciar la oleada

            Oleada oleada = spawnController.oleadas[oleadaActual];
            textoOleadas.text = "Oleada " + (oleadaActual + 1);

            for (int j = 0; j < oleada.cantidad; j++)
            {
                spawnController.SpawnEnemigo(oleada.enemyPrefab);
                yield return new WaitForSeconds(oleada.tiempoEntreSpawn);
            }

            while (spawnController.HayEnemigosEnOleadaActual())
            {
                yield return null;
            }
            CoinManager.instance.RecompensaPorOleada();
            // No quedan enemigos en la oleada actual, activa el botón
            siguienteOleadaBoton.SetActive(true);

            yield return new WaitUntil(() => Input.GetButtonDown("SiguienteOleada")); // Espera hasta que se presione el botón

            siguienteOleadaBoton.SetActive(false); // Desactiva el botón después de presionarlo
        }
        
        // Se han completado todas las oleadas, otorga las monedas
        
    }
}
