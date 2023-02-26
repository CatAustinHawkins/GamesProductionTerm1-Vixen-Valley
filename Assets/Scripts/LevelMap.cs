using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMap : MonoBehaviour
{
    public GameObject GameManager;

    public DontDestory Script;

    public GameObject LevelMap1;

    public GameObject LevelMap2;

    public GameObject LevelMap3;

    public GameObject LevelMap4;

    public GameObject LevelMap5;

    public void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        Script = GameManager.GetComponent<DontDestory>();

        if(Script.LevelPlayerisOn == -1)
        {
            LevelMap1.SetActive(true);
        }

        if(Script.LevelPlayerisOn == 0)
        {
            LevelMap2.SetActive(true);
            LevelMap1.SetActive(false);
        }

        if(Script.LevelPlayerisOn == 1)
        {
            LevelMap3.SetActive(true);
            LevelMap2.SetActive(false);
        }

        if(Script.LevelPlayerisOn == 2)
        {
            LevelMap4.SetActive(true);
            LevelMap3.SetActive(false);
        }

        if(Script.LevelPlayerisOn == 3)
        {
            LevelMap5.SetActive(true);
            LevelMap4.SetActive(false);
        }

    }

    //LevelPlayerIsOn = -1, means pre-tutorial
    //LevelPlayerIsOn = 0, means after tutorial, pre level 1
    //LevelPlayerIsOn = 1, means after level 1, pre level 2
    //LevelPlayerIsOn = 2, means after level 2, pre level 3
    //LevelPlayerIsoN = 3, means after level 3


    public void Level0()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
}
