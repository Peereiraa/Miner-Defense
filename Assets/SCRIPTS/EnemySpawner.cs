using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    void Awake()
    {
        instance = this;
    }

    // Enemy prefabs
    public List<GameObject> prefabs;

    // Enemy spawn root points
    public List<Transform> spawnPoints;

    // Enemy spawn intervals
    public float spawnInterval = 2f;

    public void StartSpawning()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        while (true)
        {
            // Call spawn method
            SpawnEnemy();

            // Wait spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (prefabs.Count == 0 || spawnPoints.Count == 0)
        {
            Debug.LogWarning("Enemy prefabs or spawn points are not set!");
            return;
        }

        int randomPrefabID = Random.Range(0, prefabs.Count);
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);

        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID].position, Quaternion.identity);
        spawnedEnemy.tag = "Enemy";
        Debug.Log($"Enemigo instanciado con tag: {spawnedEnemy.tag}"); // Confirma el tag

        // Set a parent for organization (optional)
        spawnedEnemy.transform.parent = transform;
        
    }
}
