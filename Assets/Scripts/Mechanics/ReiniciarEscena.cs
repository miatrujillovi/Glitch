using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarEscena : MonoBehaviour
{

    private string actualScene;

    void Awake()
    {
        actualScene = SceneManager.GetActiveScene().name;
    }

    public void ReiniciarEscenas()
    {
        SceneManager.LoadScene(actualScene);
    }
}
