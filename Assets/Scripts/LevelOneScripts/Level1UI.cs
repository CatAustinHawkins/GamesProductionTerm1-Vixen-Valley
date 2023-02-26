using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1UI : MonoBehaviour
{
    [Header("GameManager")]
    public DontDestory Script;
    public GameObject GameManager;

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

    [Header("Player Info")]
    public GameObject Player;

    [Header("Ability GameObjects")]
    public GameObject NormalAbility;
    public GameObject PlantAbility;
    public GameObject WaterAbility;

    [Header("Ability Images")]
    public Image PlantAbilityImage;
    public Sprite PlantAbilityInProgress;
    public Sprite PlantAbilityNOTinProgress;
    public bool PlantAbilityActive;

    [Header("Other UI GameObjects")]
    public GameObject Tails;
    public GameObject FoxRetryButton;
    public GameObject Next;

    [Header("Audio")]
    public AudioSource Barking_Audio;

    [Header("Fox Models")]
    public GameObject NormalFox;
    public GameObject PlantFox;
    public GameObject WaterFox;
    public GameObject WaterTail;

    //Private Variables; that I don't need to access in editor
    private Scene currentScene;
    private string sceneName;

    private float retrytimer;
    private bool retrytimerbegin;

    private int damagetakencount;

    private bool Spin;
    private float spintimer;

    public GameObject CameraShake;

    private void Start()
    {
        Barking_Audio = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        Script = GameManager.GetComponent<DontDestory>();

        if (Script.Lives == 2)
        {
            Heart1GO.SetActive(false);
            BrokenHeart1GO.SetActive(true);
        }

        if (Script.Lives == 1)
        {
            Heart2GO.SetActive(false);
            BrokenHeart2GO.SetActive(true);
        }

        if (Script.Lives == 0)
        {
            Heart3GO.SetActive(false);
            BrokenHeart3GO.SetActive(true);
        }
    }

    public void Update()
    {
        if (retrytimerbegin == true)
        {
            retrytimer = retrytimer + 1 * Time.deltaTime;
        }
        if (retrytimer > 1)
        {
            retrytimer = 0;
            retrytimerbegin = false;
        }
        if (Spin)
        {
            spintimer = spintimer + 1 * Time.deltaTime;
        }
        if (spintimer > 0.16)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 60);
        }
        if (spintimer > 0.32)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 120);
        }
        if (spintimer > 0.48)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
        }
        if (spintimer > 0.64)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 240);
        }
        if (spintimer > 0.8)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 300);
        }
        if (spintimer > 0.96)
        {
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 360);
            Spin = false;
            spintimer = 0;
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            SceneManager.LoadScene(sceneName);
            //setting it back to 0 for next time
        }
    }

    public void NormalFoxAbility()
    {
        //bark
        Barking_Audio.Play();
        CameraShake.GetComponent<CameraShake>().CameraBeginShake();
    }

    public void PlantFoxAbility()
    {
        Player.GetComponent<Level1_PlayerMovement>().MovePillar();
    }

    public void PlantAbilityIcon()
    {
        if(PlantAbilityActive == false)
        {
            PlantAbilityActive = true;
            PlantAbilityImage.sprite = PlantAbilityInProgress;
        }
        else
        {
            PlantAbilityActive = false;
            PlantAbilityImage.sprite = PlantAbilityNOTinProgress;
        }
    }

    public void ElementSwitchToPlant()//
    {
        //when the player clicks the green tail 
        //spin tail wheel to face the plant tail 
        //trigger plant fox begin function to update the UI visually
        //same for other element switching
        Tails.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 45);
        PlantFoxBegin();
        CameraShake.GetComponent<CameraShake>().CameraBeginShake();
    }

    public void ElementSwitchtoNormal()//will be triggered when the player clicks the normal tail
    {
        Tails.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        NormalFoxBegin();
        CameraShake.GetComponent<CameraShake>().CameraBeginShake();
    }

    public void ElementSwitchtoWater()//will be triggered when the player clicks the normal tail
    {
        Tails.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        WaterFoxBegin();
        CameraShake.GetComponent<CameraShake>().CameraBeginShake();
    }

    public void Restart()//will be triggered when the player uses the retry button
    {
        if (retrytimerbegin == false)//check if 1 second cooldown is over
        {
            Spin = true;
            retrytimerbegin = true;
            DamageTaken();
        }
    }

    public void DamageTaken()//will be triggered when the player takes damage, or uses the retry button
    {
        Script.LifeTracker();

        if (Script.Lives == 2)
        {
            Heart1GO.SetActive(false);
            BrokenHeart1GO.SetActive(true);
        }

        if (Script.Lives == 1)
        {
            Heart2GO.SetActive(false);
            BrokenHeart2GO.SetActive(true);
        }

        if (Script.Lives == 0)
        {
            Heart3GO.SetActive(false);
            BrokenHeart3GO.SetActive(true);
        }

    }

    public void PlantFoxBegin()
    {
        normalfox = false;
        plantfox = true;
        waterfox = false;

        Heart1.sprite = PlantHeart;
        Heart2.sprite = PlantHeart;
        Heart3.sprite = PlantHeart;

        NormalAbility.SetActive(false);
        PlantAbility.SetActive(true);
        WaterAbility.SetActive(false);

        NormalFox.SetActive(false);
        PlantFox.SetActive(true);
        WaterFox.SetActive(false);
    }

    public void WaterFoxBegin()
    {
        normalfox = false;
        plantfox = false;
        waterfox = true;

        Heart1.sprite = WaterHeart;
        Heart2.sprite = WaterHeart;
        Heart3.sprite = WaterHeart;

        NormalAbility.SetActive(false);
        PlantAbility.SetActive(false);
        WaterAbility.SetActive(true);

        NormalFox.SetActive(false);
        PlantFox.SetActive(false);
        WaterFox.SetActive(true);

        Next.SetActive(true);

        WaterTail.SetActive(true);
    }

    public void NormalFoxBegin()
    {
        normalfox = true;
        plantfox = false;
        waterfox = false;

        Heart1.sprite = NormalHeart;
        Heart2.sprite = NormalHeart;
        Heart3.sprite = NormalHeart;

        NormalAbility.SetActive(true);
        PlantAbility.SetActive(false);
        WaterAbility.SetActive(false);

        NormalFox.SetActive(true);
        PlantFox.SetActive(false);
        WaterFox.SetActive(false);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("VisualNovelLevelOne");
    }    
}