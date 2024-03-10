using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PantallaCarga : MonoBehaviour
{
    public Image loadingBar;
    public string sceneToLoad = "SampleScene"; // Nombre de la escena a cargar después de que la carga esté completa
    public float loadTime = 4.5f; // Tiempo de carga en segundos

    private float currentTime = 0f;
    private AsyncOperation asyncOperation;

    void Start()
    {
        // Comenzar la carga asíncrona de la escena
        asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncOperation.allowSceneActivation = false; // Evitar que la escena se active automáticamente

        // Iniciar la animación de la barra de carga
        currentTime = 0f;
        loadingBar.fillAmount = 0f;
    }

    void Update()
    {
        // Incrementar el tiempo actual
        currentTime += Time.deltaTime;

        // Calcular el progreso de carga
        float progress = Mathf.Clamp01(currentTime / loadTime);

        // Actualizar la barra de carga
        loadingBar.fillAmount = progress;

        // Comprobar si la carga ha terminado
        if (currentTime >= loadTime)
        {
            asyncOperation.allowSceneActivation = true; // Activar la escena cargada
        }
    }
}
