using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagament : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Chapter2_1()
    {
        SceneManager.LoadScene("Cap2.1");
    }
}
