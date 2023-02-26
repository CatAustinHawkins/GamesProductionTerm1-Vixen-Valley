using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void ToAboutMenu()
    {
        SceneManager.LoadScene("AboutMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelMap");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
