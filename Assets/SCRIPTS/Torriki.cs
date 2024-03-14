using UnityEngine;
using TMPro; // Importa el espacio de nombres TMPro

public class Torriki : MonoBehaviour
{
    private static int vidaTorre = 5;
    [SerializeField] public TextMeshProUGUI textoTorre;

    void Start()
    {
        textoTorre.text = vidaTorre.ToString(); // Cambiado "toString()" a "ToString()"
    }

    public void decrementarVida()
    {
        vidaTorre--;

        textoTorre.text = vidaTorre.ToString(); // Cambiado "toString()" a "ToString()"
    }
}
