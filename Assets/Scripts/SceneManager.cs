using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        //SceneManager.LoadScene("Cap2.1");
    }
}
