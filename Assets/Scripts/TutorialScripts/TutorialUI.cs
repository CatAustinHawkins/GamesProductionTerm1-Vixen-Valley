using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//This Script will control tutorial specfic UI
public class TutorialUI : MonoBehaviour
{
    [Header("GameManager")]
    public DontDestory Script;
    public GameObject GameManager;

    [Header("Heart UI GameObjects on Screen")]
    public GameObject Heart1GO;
    public GameObject Heart2GO;
    public GameObject Heart3GO;

    [Header("Broken Heart UI GameObjects")]
    public GameObject BrokenHeart1GO;
    public GameObject BrokenHeart2GO;
    public GameObject BrokenHeart3GO;

    [Header("Tails")]
    public Image GreyTail;
    public Image NormalTail;

    public Sprite PlantTails;
    public Sprite NormalTails;

    [Header("Foxes")]
    public GameObject PlantFox;
    public GameObject NormalFox;

    [Header("Hearts")]
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public Sprite PlantHeart;

    [Header("Player Info")]
    public GameObject Player;

    //Private Variables; that I don't need to access in editor
    private Scene currentScene;
    private string sceneName;

    private float retrytimer;
    private bool retrytimerbegin;

    private int damagetakencount;

    private bool Spin;
    private float spintimer;

    [Header("Ability Buttons")]
    public GameObject normalability;
    public GameObject plantability;

    [Header("Other UI GameObjects")]
    public GameObject FoxRetryButton;

    [Header("Audio")]
    public AudioSource Barking_Audio;

    [Header("Checkmarks")]
    public GameObject checkmark1;
    public GameObject checkmark2;
    public GameObject checkmark3;

    [Header("End Of Level")]
    public GameObject TutorialWin;
    public GameObject NextLevel;

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

    public void TutorialOneComplete()
    {
        checkmark1.SetActive(true);
    }

    public void TutorialTwoComplete()
    {
        checkmark2.SetActive(true);
    }

    public void TutorialThreeComplete()
    {
        CameraShake.GetComponent<CameraShake>().CameraBeginShake();
        checkmark3.SetActive(true);
        Heart1.sprite = PlantHeart;
        Heart2.sprite = PlantHeart;
        Heart3.sprite = PlantHeart;
        NormalTail.sprite = PlantTails;
        GreyTail.sprite = NormalTails;
        NormalFox.SetActive(false);
        PlantFox.SetActive(true);
        normalability.SetActive(false);
        plantability.SetActive(true);
        TutorialWin.SetActive(true);
        NextLevel.SetActive(true);
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
            SceneManager.LoadScene(sceneName);
            FoxRetryButton.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            //setting it back to 0 for next time
        }
    }

    public void NormalFoxAbility()
    {
        //bark
        Debug.Log("Bark");
        Barking_Audio.Play();
        TutorialTwoComplete();
        Player.GetComponent<TutorialMovementController>().CrowFly();
    }

    public void Restart()//will be triggered when the player uses the retry button
    {
        if (retrytimerbegin == false)//check if 1 second cooldown is over
        {
            Spin = true;
            retrytimerbegin = true;
        }
        DamageTaken();
    }

    public void DamageTaken()//will be triggered when the player takes damage, or uses the retry button
    {
        Script.LifeTracker();

        if(Script.Lives == 2)
        {
            Heart1GO.SetActive(false);
            BrokenHeart1GO.SetActive(true);
        }

        if (Script.Lives == 1)
        {
            Heart2GO.SetActive(false);
            BrokenHeart2GO.SetActive(true);
        }

        if(Script.Lives == 0)
        {
            Heart3GO.SetActive(false);
            BrokenHeart3GO.SetActive(true);
        }
    }

    public void NextLevelGo()
    {
        SceneManager.LoadScene("VisualNovelLevelTutorial");
    }

}
