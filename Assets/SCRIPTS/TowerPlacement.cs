using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerPrefab; // Asigna el prefab de la torre desde el editor de Unity

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta el clic izquierdo del mouse
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("buildGround"))
            {
                PlaceTower(hit.point);
                hit.collider.gameObject.SetActive(false); // Opcional: desactiva el lugar de construcción
            }
        }
    }

    void PlaceTower(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
    }
}
