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

    public void Puzzle4()
    {
        SceneManager.LoadScene("Puzzle4");
    }

    public void Puzzle5()
    { 
        SceneManager.LoadScene("Puzzle5");
    }

    public void Puzzle6() 
    {
        SceneManager.LoadScene("Puzzle6");
    }

    public void Puzzle7()
    {
        SceneManager.LoadScene("Puzzle7");
    }

    public void Puzzle8()
    {
        SceneManager.LoadScene("Puzzle8");
    }
}
