using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public TextMeshProUGUI textoMonedas;
    private int monedas = 10; // El usuario comienza con 10 monedas

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ActualizarTextoMonedas();
    }

    public int ObtenerMonedas()
    {
        return monedas;
    }

    // Método para restar monedas cuando se coloca una torre
    public bool ComprarTorre(int costo)
    {
        if (monedas >= costo)
        {
            monedas -= costo;
            ActualizarTextoMonedas();
            return true;
        }
        else
        {
            Debug.Log("No tienes suficientes monedas para comprar esta torre.");
            return false;
        }
    }

    // Método para agregar monedas cuando se completa una oleada
    public void RecompensaPorOleada()
    {
        monedas += 10; // El usuario obtiene 10 monedas por completar una oleada
        ActualizarTextoMonedas();
    }

    // Método para actualizar el texto que muestra la cantidad de monedas
    private void ActualizarTextoMonedas()
{
    textoMonedas.text = "Monedas: " + monedas;
    Debug.Log("Monedas actualizadas: " + monedas);
}
}
