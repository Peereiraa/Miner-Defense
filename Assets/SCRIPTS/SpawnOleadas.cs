using UnityEngine;

public class SpawnOleadas : MonoBehaviour
{
    public Oleada[] oleadas;
    public Transform[] puntosSpawn;

    private int oleadaActual = -1; // Comienza en -1 para que la primera oleada sea la 0
    private int enemigosRestantesEnOleadaActual;

    public int GetOleadaActual()
    {
        return oleadaActual;
    }

    public void IncrementarOleada()
    {
        oleadaActual++;
        if (oleadaActual >= 0 && oleadaActual < oleadas.Length)
        {
            enemigosRestantesEnOleadaActual = oleadas[oleadaActual].cantidad; // Reinicia el contador de enemigos restantes
        }
    }

    public void DecrementarEnemigosRestantes()
    {
        enemigosRestantesEnOleadaActual--;
    }

    public bool HayEnemigosEnOleadaActual()
    {
        return enemigosRestantesEnOleadaActual > 0;
    }

    public void SpawnEnemigo(GameObject enemyPrefab)
    {
        Transform spawnPoint = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.tag = "Enemy";
        enemy.GetComponent<Enemy>().SetInitialHealth(oleadaActual + 1); // Usar oleadaActual + 1 para la numeración de oleadas
        enemigosRestantesEnOleadaActual++;
    }

    public void IniciarNuevaOleada()
    {
        enemigosRestantesEnOleadaActual = 0;
    }
}
