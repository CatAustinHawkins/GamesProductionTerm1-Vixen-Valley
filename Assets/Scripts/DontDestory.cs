using UnityEngine;
using UnityEngine.SceneManagement;

//script to hold variables and information that I want to be carried over, not complete
public class DontDestory : MonoBehaviour
{
    //stores the lives the player has
    public int Lives = 3;

    //stores the level the player is currently on, to dictate which level map is made visible
    public int LevelPlayerisOn = -1;

    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //scene = SceneManager.GetActiveScene().name;

        DontDestroyOnLoad(gameObject);

        Load();
    }

    public void LifeTracker()
    {
        Lives--;
        if(Lives < 0)
        {
            Lives = 3;
            SceneManager.LoadScene("MainMenu");
        }
        Save();
    }

    public void LevelTracker()
    {
        LevelPlayerisOn++;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Levels", LevelPlayerisOn);
        PlayerPrefs.SetInt("Health", Lives);
    }
    
    public void Load()
    {
        LevelPlayerisOn = PlayerPrefs.GetInt("Levels");
        Lives = PlayerPrefs.GetInt("Health");
    }
}
