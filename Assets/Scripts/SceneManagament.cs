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

    public void Puzzle1()
    {
        SceneManager.LoadScene("Puzzle1");
    }

    public void Puzzle2()
    {
        SceneManager.LoadScene("Puzzle2");
    }

    public void Puzzle3()
    {
        SceneManager.LoadScene("Puzzle3");
    }
}
