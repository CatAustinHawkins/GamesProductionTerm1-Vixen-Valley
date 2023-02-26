using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{   //this script controls all the gameplay UI - used as a base for TutorialUI, Level1UI, Level2UI and Level3UI.

    [Header("Heart UI Images on Screen")]
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    [Header("Heart UI GameObjects on Screen")]
    public GameObject Heart1GO;
    public GameObject Heart2GO;
    public GameObject Heart3GO;

    [Header("Heart UI Images")]
    public Sprite NormalHeart;
    public Sprite FireHeart;
    public Sprite WaterHeart;
    public Sprite PlantHeart;
    public Sprite BrokenHeart;
    public Sprite GreyHeart;

    [Header("Broken Heart UI GameObjects")]
    public GameObject BrokenHeart1GO;
    public GameObject BrokenHeart2GO;
    public GameObject BrokenHeart3GO;

    [Header("What Element?")]
    public bool normalfox;//if fox is normal set to true
    public bool plantfox;//if fox is plant set to true
    public bool waterfox;//if fox is water set to true
    public bool firefox;//if fox is fire set to true

    [Header("Player Info")]
    public GameObject Player;
    //public Level1Player script;

    //Private Variables; that I don't need to access in editor
    private Scene currentScene;
    private string sceneName;

    private float retrytimer;
    private bool retrytimerbegin;
    
    private int damagetakencount;

    private bool Spin;
    private float spintimer;

    [Header("Ability GameObjects")]
    public GameObject NormalAbility;
    public GameObject PlantAbility;
    public GameObject WaterAbility;
    public GameObject FireAbility;

    [Header("Other UI GameObjects")]
    public GameObject Tails;
    public GameObject FoxRetryButton;

    [Header("Audio")]
    public AudioSource Barking_Audio;


    public void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void Update()
    {
        if(retrytimerbegin == true)
        {
            retrytimer = retrytimer + 1 * Time.deltaTime;
        }
        if(retrytimer > 1)
        {
            retrytimer = 0;
            retrytimerbegin = false;
        }
        if(Spin)
        {
            spintimer = spintimer + 1 * Time.deltaTime; 
        }
        if(spintimer > 0.16)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 60);
        }
        if(spintimer > 0.32)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 120);
        }
        if(spintimer > 0.48)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
        }
        if(spintimer > 0.64)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 240);
        }
        if(spintimer > 0.8)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 300);
        }
        if(spintimer > 0.96)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 360);
            Spin = false;
            spintimer = 0;
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            //setting it back to 0 for next time
        }

    }

    public void NormalFoxAbility()
    {
        //bark
        Debug.Log("Bark");
        Barking_Audio.Play();
    }

    public void PlantFoxAbility()
    {
        //move objects
    }

    public void WaterFoxAbility()
    {
        //grow plants
    }

    public void FireFoxAbility()
    {
        //burn obstacles
    }

    public void ElementSwitchToPlant()//
    {
        //when the player clicks the green tail 
        //spin tail wheel to face the plant tail 
        //trigger plant fox begin function to update the UI visually
        //same for other element switching
        Tails.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 45);
        PlantFoxBegin();
    }

    public void ElementSwitchtoNormal()//will be triggered when the player clicks the normal tail
    {
        Tails.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        NormalFoxBegin();
    }

    public void ElementSwitchtoWater()//will be triggered when the player clicks the water tail
    {
        Tails.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        WaterFoxBegin();
    }

    public void ElementSwitchtoFire()//will be triggered when the player clicks the fire tail
    {
        Tails.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 135);
        FireFoxBegin();
    }
    public void Restart()//will be triggered when the player uses the retry button
    {
        //SceneManager.LoadScene(sceneName);
        DamageTaken();
    }  

    public void DamageTaken()//will be triggered when the player takes damage, or uses the retry button
    {
        Debug.Log("Damage Taken");
        if(retrytimerbegin == false)//check if 1 second cooldown is over
        {
            Spin = true;
            retrytimerbegin = true;
            switch (damagetakencount)
            {
                case 0:
                    //First Instance of Damage Taken
                    damagetakencount++;
                    Heart1GO.SetActive(false);
                    BrokenHeart1GO.SetActive(true);
                    break;
                case 1:
                    //Second Instance of Damage Taken
                    damagetakencount++;
                    Heart2GO.SetActive(false);
                    BrokenHeart2GO.SetActive(true);
                    break;
                case 2:
                    //Third Instance of Damage Taken
                    damagetakencount++;
                    Heart3GO.SetActive(false);
                    BrokenHeart3GO.SetActive(true);
                    break;
                case 3:
                    //Third Instance of Damage Taken
                    damagetakencount++;
                    SceneManager.LoadScene("MainMenu");
                    break;

            }
        }
    }
    
    public void PlantFoxBegin()
    {
        normalfox = false;
        plantfox = true;
        waterfox = false;
        firefox = false;

        Heart1.sprite = PlantHeart;
        Heart2.sprite = PlantHeart;
        Heart3.sprite = PlantHeart;

        NormalAbility.SetActive(false);
        PlantAbility.SetActive(true);
        WaterAbility.SetActive(false);
        FireAbility.SetActive(false);
    }

    public void FireFoxBegin()
    {
        normalfox = false;
        plantfox = false;
        waterfox = false;
        firefox = true; 

        Heart1.sprite = FireHeart;
        Heart2.sprite = FireHeart;
        Heart3.sprite = FireHeart;

        NormalAbility.SetActive(false);
        PlantAbility.SetActive(false);
        WaterAbility.SetActive(false);
        FireAbility.SetActive(true);
    }

    public void WaterFoxBegin()
    {
        normalfox = false;
        plantfox = false;
        waterfox = true;
        firefox = false;

        Heart1.sprite = WaterHeart;
        Heart2.sprite = WaterHeart;
        Heart3.sprite = WaterHeart;

        NormalAbility.SetActive(false);
        PlantAbility.SetActive(false);
        WaterAbility.SetActive(true);
        FireAbility.SetActive(false);
    }

    public void NormalFoxBegin()
    {
        normalfox = true;
        plantfox = false;
        waterfox = false;
        firefox = false;

        Heart1.sprite = NormalHeart;
        Heart2.sprite = NormalHeart;
        Heart3.sprite = NormalHeart;

        NormalAbility.SetActive(true);
        PlantAbility.SetActive(false);
        WaterAbility.SetActive(false);
        FireAbility.SetActive(false);
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
