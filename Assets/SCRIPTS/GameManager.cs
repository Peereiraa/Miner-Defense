using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() { instance = this; }

    public SpawnOleadas spawnController;
    public float tiempoEntreOleadas = 10f;

    public CurrencySystem currency;


    void Start()
    {
//        GetComponent<CurrencySystem>().Init();

        StartCoroutine(ComenzarOleadas());
    }

    IEnumerator ComenzarOleadas()
    {
        yield return new WaitForSeconds(2f); 

        for (int i = 0; i < spawnController.oleadas.Length; i++) 
        {
            Oleada oleada = spawnController.oleadas[i];
            yield return new WaitForSeconds(tiempoEntreOleadas);

            for (int j = 0; j < oleada.cantidad; j++)
            {
                spawnController.SpawnEnemigo(oleada.enemyPrefab);
                yield return new WaitForSeconds(oleada.tiempoEntreSpawn);
            
        }
    }
}
}