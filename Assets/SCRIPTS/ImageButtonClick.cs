using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageButtonClick : MonoBehaviour
{
    // Método que se ejecutará cuando se haga clic en el botón de la imagen
public void OnMouseDown()
{
    Debug.Log("Botón de imagen clickeado");
    ChangeScene();
}


public void ChangeScene()
{
    Debug.Log("Cambiando de escena");
    SceneManager.LoadScene("Pantallacarga");
}
}