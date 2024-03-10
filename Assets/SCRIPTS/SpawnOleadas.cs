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
    public void IncrementarOleada()
    {
        oleadaActual++;
    }
    public void SpawnEnemigo(GameObject enemyPrefab)
    {
        Transform spawnPoint = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
        // Instancia el enemigo
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        // Asigna el tag "Enemy" al enemigo instanciado
        enemy.tag = "Enemy";
        enemy.GetComponent<Enemy>().SetInitialHealth(oleadaActual);
    }
}