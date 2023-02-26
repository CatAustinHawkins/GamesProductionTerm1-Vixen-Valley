using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    //script for pause button, setting button, back to home button

    public GameObject PauseMenu;

    public void PauseButton()
    {
        PauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

}
