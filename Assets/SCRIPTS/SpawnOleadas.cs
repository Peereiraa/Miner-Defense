using UnityEngine;
using System.Collections;

public class SpawnOleadas : MonoBehaviour
{
    public Oleada[] oleadas;
    public Transform[] puntosSpawn;

    private int oleadaActual = 0;

    void Start()
    {
        StartCoroutine(SpawnOleada());
    }

    IEnumerator SpawnOleada()
    {
        while (oleadaActual < oleadas.Length)
        {
            Oleada oleada = oleadas[oleadaActual];
            for (int i = 0; i < oleada.cantidad; i++)
            {
                SpawnEnemigo(oleada.enemyPrefab);
                yield return new WaitForSeconds(oleada.tiempoEntreSpawn);
            }
            oleadaActual++;
            yield return new WaitForSeconds(oleada.tiempoEntreOleadas);
        }
    }

    void SpawnEnemigo(GameObject enemyPrefab)
    {
        Transform spawnPoint = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
