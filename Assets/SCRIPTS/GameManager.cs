using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI textoOleadas;

    public SpawnOleadas spawnController;
    public float tiempoDespuesDeOleada = 5f; // Tiempo para esperar después de que se eliminen todos los enemigos

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(ComenzarOleadas());
    }

    IEnumerator ComenzarOleadas()
    {
        yield return new WaitForSeconds(2f);

        int oleadaActual = 0;

        while (oleadaActual < spawnController.oleadas.Length)
        {
            Oleada oleada = spawnController.oleadas[oleadaActual];
            textoOleadas.text = "Oleada " + (oleadaActual + 1);

            for (int j = 0; j < oleada.cantidad; j++)
            {
                spawnController.SpawnEnemigo(oleada.enemyPrefab);
                yield return new WaitForSeconds(oleada.tiempoEntreSpawn);
            }

            yield return new WaitForSeconds(oleada.tiempoEntreOleadas + tiempoDespuesDeOleada);

            spawnController.IncrementarOleada(); // Incrementa la oleada actual
            oleadaActual++;
        }
    }
}
