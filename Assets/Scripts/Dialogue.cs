using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour//For the visual novel
{
    public TMP_Text NameText; //Get the Name TMPro Object

    public TMP_Text DialogueText; //Get the Dialogue TMPro Object

    public string DialogueString;

    public int DialogueCount = 0;//Dialogue Count 

    public DontDestory Script;
    public GameObject GameManager;

    private string CurrentScene;

    [Header("Fox")]
    public GameObject FoxNormalGO;
    public GameObject FoxConfusedGO;
    public GameObject FoxHappyGO;
    public GameObject FoxShockedGO;
    public GameObject FoxWorriedGO;

    public Image FoxNormalImage;
    public Image FoxConfusedImage;
    public Image FoxHappyImage;
    public Image FoxShockedImage;
    public Image FoxWorriedImage;

    [Header("Aura (Butterfly)")]
    public GameObject AuraNormalGO;

    [Header("Aura (Butterfly)")]
    public Image AuraNormalImage;

    [Header("Amber(Squirrel)")]
    public GameObject AmberNormalGO;
    public GameObject AmberHappyGO;

    public Image AmberNormalImage;
    public Image AmberHappyImage;

    [Header("Maki (Snake)")]
    public GameObject MakiNormalGO;
    public GameObject MakiHappyGO;

    public Image MakiNormalImage;
    public Image MakiHappyImage;

    [Header("Pie (Pigeon)")]
    public GameObject PieNormalGO;
    public GameObject PieConfusedGO;
    public GameObject PieWorriedGO;
    public GameObject PieHappyGO;

    public Image PieNormalImage;
    public Image PieConfusedImage;
    public Image PieWorriedImage;
    public Image PieHappyImage;

    [Header("Vine (Frog)")]
    public GameObject VineNormalGO;
    public GameObject VineConfusedGO;
    public GameObject VineHappyGO;
    public GameObject VineWorriedGO;

    public Image VineNormalImage;
    public Image VineConfusedImage;
    public Image VineHappyImage;
    public Image VineWorriedImage;

    [Header("Herb (Hedgehog)")]
    public GameObject HerbNormalGO;
    public GameObject HerbWorriedGO;

    public Image HerbNormalImage;
    public Image HerbWorriedImage;

    private Image ImageToFade;


    public bool timerbegin;
    public float timer;

    public bool FadeInBegin;
    public bool FadeOutBegin;


    public void Start()
    {
        //GameManager = GameObject.FindGameObjectWithTag("GameManager");
        //Script = GameManager.GetComponent<DontDestory>();
        //^^^ commented out whilst I test

        CurrentScene = SceneManager.GetActiveScene().name;

        if (CurrentScene == "VisualNovelLevelTutorial")
        {
            //fox fades in
            FoxNormalGO.SetActive(true);
            FoxNormalImage.color = new Color(255, 255, 255, 0);
            ImageToFade = FoxNormalImage;
            FoxNormalGO.SetActive(true);
            FadeInBegin = true;
            timerbegin = true;
        }

        if (CurrentScene == "VisualNovelLevelOne")
        {
            FoxHappyGO.SetActive(true);
            FoxHappyImage.color = new Color(255, 255, 255, 0);
            ImageToFade = FoxHappyImage;
            FadeInBegin = true;
            timerbegin = true;
        }

        if (CurrentScene == "VisualNovelLevelTwo")
        {
            FoxHappyGO.SetActive(true);
            VineHappyGO.SetActive(true);
            VineHappyImage.color = new Color(255, 255, 255, 0);
            FoxHappyImage.color = new Color(255, 255, 255, 0);
            ImageToFade = VineHappyImage;
            FadeInBegin = true;
            timerbegin = true;
        }

        if (CurrentScene == "VisualNovelLevelThree")
        {
            FoxWorriedGO.SetActive(true);
            MakiHappyGO.SetActive(true);
            AmberHappyGO.SetActive(true);
            FoxWorriedImage.color = new Color(255, 255, 255, 0);
            MakiHappyImage.color = new Color(255, 255, 255, 0);
            AmberHappyImage.color = new Color(255, 255, 255, 0);
            ImageToFade = FoxWorriedImage;
            FadeInBegin = true;
            timerbegin = true;
        }
    }

    private void Update()
    {
        //fade in, or out, an animal
        if (timerbegin)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        if (FadeInBegin)
        {
            FadeIn();
        }
        if (FadeOutBegin)
        {
            FadeOut();
        }
    }

    public void Next()
    {
        if (CurrentScene == "VisualNovelLevelTutorial")
        {
            switch (DialogueCount)//Cycle Through the Dialogue
            {
                case 0:
                    FoxNormalGO.SetActive(false);
                    FoxHappyGO.SetActive(true);
                    NameText.text = "Fox";
                    DialogueText.text = "I've made it to The Forest!";
                    DialogueCount++;
                    break;

                case 1:
                    FoxHappyGO.SetActive(false);
                    FoxShockedGO.SetActive(true);
                    DialogueText.text = "Wait, but... the elemental balance feels off?";
                    DialogueCount++;
                    break;

                case 2:
                    FoxShockedGO.SetActive(false);
                    FoxNormalGO.SetActive(true);
                    DialogueText.text = "I need to figure out what's going on here.";
                    AuraNormalImage.color = new Color(255, 255, 255, 0);
                    AuraNormalGO.SetActive(true);
                    ImageToFade = AuraNormalImage;
                    FadeInBegin = true;
                    timerbegin = true;
                    DialogueCount++;
                    break;

                case 3:
                    NameText.text = "Aura";
                    DialogueText.text = "…!";
                    DialogueCount++;
                    break;

                case 4:
                    FoxNormalGO.SetActive(false);
                    FoxWorriedGO.SetActive(true);
                    NameText.text = "Fox";
                    DialogueText.text = "I… can’t seem to hear you…";
                    PieWorriedImage.color = new Color(255, 255, 255, 0);
                    PieWorriedGO.SetActive(true);
                    ImageToFade = PieWorriedImage;
                    FadeInBegin = true;
                    timerbegin = true;
                    DialogueCount++;
                    break;

                case 5:
                    NameText.text = "Pie";
                    DialogueText.text = "Aura, there you are! I hope they weren’t bothering you.";
                    DialogueCount++;
                    break;

                case 6:
                    FoxHappyGO.SetActive(true);
                    FoxWorriedGO.SetActive(false);
                    NameText.text = "Fox";
                    DialogueText.text = "No, not at all, but I think they were trying to say something?";
                    DialogueCount++;
                    break;

                case 7:
                    NameText.text = "Aura";
                    DialogueText.text = "...! ....!";
                    DialogueCount++;
                    break;

                case 8:
                    PieWorriedGO.SetActive(false);
                    PieConfusedGO.SetActive(true);
                    NameText.text = "Pie";
                    DialogueText.text = "Oh?";
                    DialogueCount++;
                    break;

                case 9:
                    PieConfusedGO.SetActive(false);
                    PieNormalGO.SetActive(true);
                    NameText.text = "Pie";
                    DialogueText.text = "They said you did a great job at completing ‘the level’";
                    DialogueCount++;
                    break;

                case 10:
                    DialogueText.text = "…whatever that means. ";
                    DialogueCount++;
                    break;

                case 11:
                    NameText.text = "Fox";
                    DialogueText.text = "Thank you!";
                    DialogueCount++;
                    break;

                case 12:
                    NameText.text = "Aura";
                    DialogueText.text = "!!";
                    DialogueCount++;
                    break;

                case 13:
                    PieNormalGO.SetActive(false);
                    PieHappyGO.SetActive(true);
                    NameText.text = "Pie";
                    DialogueText.text = "We do need to get going, though. We have more flower inspection work to do.";
                    DialogueCount++;
                    break;

                case 14:
                    DialogueText.text = "See you later!";
                    DialogueCount++;
                    break;

                case 15:
                    NameText.text = "Fox";
                    DialogueText.text = "See you!";
                    DialogueCount++;
                    break;

                case 16:
                    //exit
                    ImageToFade = PieHappyImage;
                    FadeOutBegin = true;
                    timerbegin = true;
                    DialogueCount++;
                    break;

                case 17:
                    //exit
                    ImageToFade = AuraNormalImage;
                    FadeOutBegin = true;
                    timerbegin = true;
                    DialogueCount++;
                    break;

                case 18:
                    FoxHappyGO.SetActive(false);
                    FoxNormalGO.SetActive(true);
                    DialogueText.text = "I should also keep going...";
                    DialogueCount++;
                    break;

                case 19:
                    SceneManager.LoadScene("Level1");
                    break;
            }
        }

        if (CurrentScene == "VisualNovelLevelOne")
        {
            switch (DialogueCount)//Cycle Through the Dialogue
            {
                case 0:
                    NameText.text = "Fox";
                    DialogueText.text = "I got the Grass Element!";
                    DialogueCount++;
                    break;
                case 1:
                    DialogueText.text = "Now I can harness the power of plants and nature!";
                    DialogueCount++;
                    break;
                case 2:
                    FoxHappyGO.SetActive(false);
                    FoxConfusedGO.SetActive(true);
                    DialogueText.text = "...That robot back there... It's strange, I didn't think I'd see one up so close.";
                    DialogueCount++;
                    break;
                case 3:
                    FoxConfusedGO.SetActive(false);
                    FoxNormalGO.SetActive(true);
                    DialogueText.text = "After what happened during The Great Mechanisation,";
                    DialogueCount++;
                    break;
                case 4:
                    FoxNormalGO.SetActive(false);
                    FoxWorriedGO.SetActive(true);
                    DialogueText.text = "I don’t think any of us can see them in the same light as before...";
                    DialogueCount++;
                    break;
                case 5:
                    FoxNormalGO.SetActive(true);
                    FoxWorriedGO.SetActive(false);
                    DialogueText.text = "Ah, I don't have time to ponder about this. I need to move on.";
                    DialogueCount++;
                    break;
                case 6:
                    SceneManager.LoadScene("Level2");
                    break;

            }

        }

        if (CurrentScene == "VisualNovelLevelTwo")
        {
            switch (DialogueCount)//Cycle Through the Dialogue
            {
                case 0:
                    ImageToFade = FoxHappyImage;
                    FadeInBegin = true;
                    timerbegin = true;
                    NameText.text = "Vine";
                    DialogueText.text = "Thank you so so much for restoring water back to my pond!";
                    DialogueCount++;
                    break;
                case 1:
                    NameText.text = "Fox";
                    DialogueText.text = "Of course!";
                    DialogueCount++;
                    break;
                case 2:
                    NameText.text = "Vine";
                    DialogueText.text = "It’s so bizarre, I thought the spirits above had something against me, personally!";
                    DialogueCount++;
                    break;
                case 3:
                    NameText.text = "Fox";
                    DialogueText.text = "That explains the weird feeling I’ve been getting…";
                    DialogueCount++;
                    break;
                case 4:
                    NameText.text = "Vine";
                    DialogueText.text = "Yes, the Guardians of this forest seem to have weakened…";
                    DialogueCount++;
                    break;
                case 5:
                    NameText.text = "Fox";
                    DialogueText.text = "The Guardians?";
                    DialogueCount++;
                    break;
                case 6:
                    HerbWorriedGO.SetActive(true);
                    HerbWorriedImage.color = new Color(255, 255, 255, 0);
                    ImageToFade = HerbWorriedImage;
                    FadeInBegin = true;
                    timerbegin = true;
                    DialogueText.text = "That's not good, I'll have to-";
                    DialogueCount++;
                    break;
                case 7:
                    NameText.text = "Herb";
                    DialogueText.text = "You there! Please help!!";
                    DialogueCount++;
                    break;
                case 8:
                    NameText.text = "Fox";
                    DialogueText.text = "Oh?!";
                    DialogueCount++;
                    break;
                case 9:
                    NameText.text = "Herb";
                    DialogueText.text = "My friends are trapped up there, on those islands! Please, help them!!";
                    DialogueCount++;
                    break;
                case 10:
                    NameText.text = "Fox";
                    DialogueText.text = "That’s terrible! Don’t worry, I’ll get there right away!";
                    DialogueCount++;
                    break;
                case 11:
                    //Vine leaves
                    VineWorriedImage.color = new Color(255, 255, 255, 0);
                    ImageToFade = VineWorriedImage;
                    FadeOutBegin = true;
                    timerbegin = true;
                    DialogueCount++;
                    break;
                case 12:
                    //herb leaves
                    HerbWorriedImage.color = new Color(255, 255, 255, 0);
                    ImageToFade = HerbWorriedImage;
                    FadeOutBegin = true;
                    timerbegin = true;
                    DialogueCount++;
                    break;
                case 13:
                    SceneManager.LoadScene("Level3");
                    break;
            }

        }

        if (CurrentScene == "VisualNovelLevelThree")
        {
            switch (DialogueCount)//Cycle Through the Dialogue
            {
                case 0:
                    ImageToFade = MakiHappyImage;
                    FadeInBegin = true;
                    timerbegin = true;
                    NameText.text = "Fox";
                    DialogueText.text = "Phew... I got it all under control.";
                    DialogueCount++;
                    break;
                case 1:
                    ImageToFade = AmberHappyImage;
                    FadeInBegin = true;
                    timerbegin = true;
                    NameText.text = "Maki";
                    DialogueText.text = "You're a hero!";
                    DialogueCount++;
                    break;
                case 2:
                    NameText.text = "Amber";
                    DialogueText.text = "Those elemental powers of yours are nuts! You’re the best.";
                    DialogueCount++;
                    break;
                case 3:
                    FoxWorriedGO.SetActive(false);
                    FoxHappyGO.SetActive(true);
                    NameText.text = "Fox";
                    DialogueText.text = "Thank you...!";
                    DialogueCount++;
                    break;
                case 4:
                    FoxNormalGO.SetActive(false);
                    FoxHappyGO.SetActive(true);
                    NameText.text = "Fox";
                    DialogueText.text = "But this doesn’t look like the end of the elemental imbalance.";
                    DialogueCount++;
                    break;
                case 5:
                    NameText.text = "Fox";
                    DialogueText.text = "There’s still a lot I need to discover.";
                    DialogueCount++;
                    break;
                case 6:
                    //Maki Leave
                    ImageToFade = MakiHappyImage;
                    FadeOutBegin = true;
                    timerbegin = true;
                    DialogueCount++;
                    break;
                case 7:
                    //amber leave
                    ImageToFade = AmberHappyImage;
                    FadeOutBegin = true;
                    timerbegin = true;
                    DialogueCount++;
                    break;
                case 8:
                    SceneManager.LoadScene("EndScreen");
                    break;
            }
        }
    }

    public void FadeIn()
    {
        if (timer > 0.1f && timer < 0.2f)
        {
            ImageToFade.color = new Color(255, 255, 255, 0.25f);
        }
        if (timer > 0.2f && timer < 0.3f)
        {
            ImageToFade.color = new Color(255, 255, 255, 0.50f);
        }
        if (timer > 0.3f && timer < 0.4f)
        {
            ImageToFade.color = new Color(255, 255, 255, 0.75f);
        }
        if (timer > 0.4f)
        {
            ImageToFade.color = new Color(255, 255, 255, 1);
            timerbegin = false;
            FadeInBegin = false;
            timer = 0f;
        }
    }

    public void FadeOut()
    {
        if (timer > 0.1f && timer < 0.2f)
        {
            ImageToFade.color = new Color(255, 255, 255, 0.75f);
        }
        if (timer > 0.2f && timer < 0.3f)
        {
            ImageToFade.color = new Color(255, 255, 255, 0.50f);
        }
        if (timer > 0.3f && timer < 0.4f)
        {
            ImageToFade.color = new Color(255, 255, 255, 0.25f);
        }
        if (timer > 0.4f)
        {
            ImageToFade.color = new Color(255, 255, 255, 0);
            timerbegin = false;
            FadeOutBegin = false;
            timer = 0f;
        }
    }
}
