using UnityEngine;

public class SpawnOleadas : MonoBehaviour
{
    public Oleada[] oleadas;
    public Transform[] puntosSpawn;

    private int oleadaActual = 1;

    public int GetOleadaActual()
    {
        return oleadaActual;
    }

    public void SpawnEnemigo(GameObject enemyPrefab)
    {
        Transform spawnPoint = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}