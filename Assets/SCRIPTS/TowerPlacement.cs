using UnityEngine;
using TMPro;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] lugaresCompra; // Array para almacenar los lugares de compra
    public GameObject towerPrefab; // Asigna el prefab de la torre desde el editor de Unity
    public int costoTorre = 10; // Costo de la torre
    public TextMeshProUGUI[] textosCompra; // Array para almacenar los TextMeshPro

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta el clic izquierdo del mouse
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("buildGround"))
            {
                for (int i = 0; i < lugaresCompra.Length; i++)
                {
                    if (hit.collider.gameObject == lugaresCompra[i])
                    {
                        if (CoinManager.instance.ComprarTorre(costoTorre)) // Verifica si el jugador puede comprar la torre
                        {
                            PlaceTower(hit.point);
                            lugaresCompra[i].SetActive(false); // Desactiva el lugar de construcción correspondiente
                            textosCompra[i].enabled = false; // Hace invisible el TextMeshPro correspondiente
                        }
                        break; // Sale del bucle una vez que se ha encontrado el lugar de compra correspondiente
                    }
                }
            }
        }
    }

    void PlaceTower(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
    }
}
