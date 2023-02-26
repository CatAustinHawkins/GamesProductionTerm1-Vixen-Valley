using UnityEngine;

public class Level2PlayerMovement : MonoBehaviour
{
    //raycasting
    Ray ray;
    RaycastHit hit;

    //get player character
    public GameObject player;

    //to work out if the player is near the targeted gameobject
    public int ZMaths;
    public int XMaths;
    public float YMaths;

    public int Pillar1ZMaths;
    public int Pillar1XMaths;

    public int Pillar2ZMaths;
    public int Pillar2XMaths;

    public int Pillar3ZMaths;
    public int Pillar3XMaths;

    //to hold the players x and z position
    public int PlayerXPosition;
    public int PlayerZPosition;
    public float PlayerYPosition;

    //to hold the targeted gameobjects x and z position
    public int GameObjectXPosition;
    public int GameObjectZPosition;
    public float GameObjectYPosition;

    public GameObject UI;

    public GameObject FlowerUnlock1a;
    public GameObject FlowerUnlock2a;
    public GameObject FlowerUnlock3a;
    public GameObject FlowerUnlock4a;

    public GameObject FlowerUnlock1b;
    public GameObject FlowerUnlock2b;
    public GameObject FlowerUnlock3b;
    public GameObject FlowerUnlock4b;

    public GameObject Flower1;
    public GameObject Flower2;
    public GameObject Flower3;
    public GameObject Flower4;

    public GameObject Flower1Watered;
    public GameObject Flower2Watered;
    public GameObject Flower3Watered;
    public GameObject Flower4Watered;



    public GameObject Pillar1;
    public GameObject Pillar2;
    public GameObject Pillar3;

    public GameObject UnlockedArea;
    public GameObject LockedArea;

    public int flowerunlockcount;

    public int Pillar1XPosition;
    public int Pillar1ZPosition;

    public int Pillar2XPosition;
    public int Pillar2ZPosition;

    public int Pillar3XPosition;
    public int Pillar3ZPosition;

    public bool PillarMovement2;
    public bool PillarMovement1;
    public bool PillarMovement3;

    public bool WaterAbility;

    public int PreviousPlayerXPosition;
    public int PreviousPlayerZPosition;

    public bool PillarinMovement;

    public int PillarCount;
    public bool BothPillarsinPlace;

    public Animation Frog;
    public GameObject FrogGO;
    public GameObject PondGO;
    public Animation Pond;
    public GameObject LilyPadGO;
    public Animation LilyPad;


    // Start is called before the first frame update
    void Start()
    {
        Frog = FrogGO.GetComponent<Animation>();
        Pond = PondGO.GetComponent<Animation>();
        LilyPad = LilyPadGO.GetComponent<Animation>();
        //store the players current position
        PlayerXPosition = (int)player.transform.position.x;
        PlayerZPosition = (int)player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Pillar1XPosition = (int)Pillar1.transform.position.x;//get the gameobjects x position
        Pillar1ZPosition = (int)Pillar1.transform.position.z;//get the gameobjects z position

        Pillar2XPosition = (int)Pillar2.transform.position.x;//get the gameobjects x position
        Pillar2ZPosition = (int)Pillar2.transform.position.z;//get the gameobjects z position

        Pillar3XPosition = (int)Pillar3.transform.position.x;
        Pillar3ZPosition = (int)Pillar3.transform.position.z;

        if (Pillar1XPosition == 2 && Pillar1ZPosition == 4 || Pillar1XPosition == 2 && Pillar1ZPosition == 5)
        {
            Pillar1.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }
        if (Pillar2XPosition == 2 && Pillar2ZPosition == 4 || Pillar2XPosition == 2 && Pillar2ZPosition == 5 || Pillar2XPosition == 3 && Pillar2ZPosition == 4 || Pillar2XPosition == 3 && Pillar2ZPosition == 5)
        {
            Pillar2.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }
        if (Pillar3XPosition == 2 && Pillar3ZPosition == 4 || Pillar3XPosition == 2 && Pillar3ZPosition == 5 || Pillar3XPosition == 3 && Pillar3ZPosition == 4 || Pillar3XPosition == 3 && Pillar3ZPosition == 5)
        {
            Pillar3.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//raycasting
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
        {
            if (hit.transform.name == "MoveableSpot" && PillarinMovement == false && PillarMovement1 == false && PillarMovement2 == false)//if the player clicks a gameobject that is labelled moveablespot
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                PreviousPlayerXPosition = PlayerXPosition;
                PreviousPlayerZPosition = PlayerZPosition;

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                {
                    player.transform.position = hit.transform.position;//set players position to the gameobjects position
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);//add more to the y position so the player is above the gameobject

                    PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
                    PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition

                    if (PlayerXPosition < PreviousPlayerXPosition)
                    {
                        player.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }

                    if (PlayerXPosition > PreviousPlayerXPosition)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }

                    if (PlayerZPosition > PreviousPlayerZPosition)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                    if (PlayerZPosition < PreviousPlayerZPosition)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }

                    XMaths = 0;//reset XMaths
                    ZMaths = 0;//reset ZMaths
                }
            }

            if(hit.transform.name == "Flower1" && WaterAbility == true)
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if(XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)
                {
                    FlowerUnlock1a.SetActive(false);
                    FlowerUnlock1b.SetActive(true);
                    WaterAbility = false;
                    Flower1.SetActive(false);
                    Flower1Watered.SetActive(true);
                    UI.GetComponent<Level2UI>().WaterAbilityIcon();
                    flowerunlockcount++;
                }
            }

            if (hit.transform.name == "Flower2" && WaterAbility == true)
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)
                {
                    FlowerUnlock2a.SetActive(false);
                    FlowerUnlock2b.SetActive(true);
                    WaterAbility = false;
                    Flower2.SetActive(false);
                    Flower2Watered.SetActive(true);
                    UI.GetComponent<Level2UI>().WaterAbilityIcon();
                    flowerunlockcount++;
                }
            }

            if (hit.transform.name == "Flower3" && WaterAbility == true)
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)
                {
                    FlowerUnlock3a.SetActive(false);
                    FlowerUnlock3b.SetActive(true);
                    WaterAbility = false;
                    Flower3.SetActive(false);
                    Flower3Watered.SetActive(true);
                    UI.GetComponent<Level2UI>().WaterAbilityIcon();
                    flowerunlockcount++;
                }
            }

            if (hit.transform.name == "Flower4" && WaterAbility == true)
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)
                {
                    FlowerUnlock4a.SetActive(false);
                    FlowerUnlock4b.SetActive(true);
                    WaterAbility = false;
                    Flower4.SetActive(false);
                    Flower4Watered.SetActive(true);
                    UI.GetComponent<Level2UI>().WaterAbilityIcon();
                    flowerunlockcount++;
                }
            }

            if (hit.transform.name == "FireElement")
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)
                {
                    UI.GetComponent<Level2UI>().ElementSwitchtoFire();
                }
            }

            if (hit.transform.name == "HighMoveableSpot")
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position
                GameObjectYPosition = (float)hit.transform.position.y;

                PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
                PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition
                PlayerYPosition = (float)player.transform.position.y;

                PreviousPlayerXPosition = PlayerXPosition;
                PreviousPlayerZPosition = PlayerZPosition;

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position
                YMaths = GameObjectYPosition - PlayerYPosition;

                Debug.Log("Player Moving Higher Up");
                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                {
                    Debug.Log("Player Close to Spot");
                    if (PlayerYPosition > 1f)
                    {
                        Debug.Log("Player Move");
                        player.transform.position = hit.transform.position;//set players position to the gameobjects position
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);//add more to the y position so the player is above the gameobject

                        PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
                        PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition
                        PlayerYPosition = player.transform.position.y;

                        if (PlayerXPosition < PreviousPlayerXPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, -90, 0);
                        }

                        if (PlayerXPosition > PreviousPlayerXPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 90, 0);
                        }

                        if (PlayerZPosition > PreviousPlayerZPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 0, 0);
                        }

                        if (PlayerZPosition < PreviousPlayerZPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 180, 0);
                        }

                        XMaths = 0;//reset XMaths
                        ZMaths = 0;//reset ZMaths
                        YMaths = 0;
                    }

                }
            }

        }
        if (PillarMovement1)
        {
            PreviousPlayerXPosition = PlayerXPosition;
            PreviousPlayerZPosition = PlayerZPosition;

            Debug.Log("worked!!");
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
            {
                if (hit.transform.name == "MoveableSpot")//if the player clicks a gameobject that is labelled moveablespot
                {
                    Debug.Log("PlayerBeginMove");
                    GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                    GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                    XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                    ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                    if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                    {
                        Debug.Log("Moved");
                        player.transform.position = hit.transform.position;//set players position to the gameobjects position
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);//add more to the y position so the player is above the gameobject

                        PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
                        PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition

                        if (PlayerXPosition < PreviousPlayerXPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, -90, 0);
                        }

                        if (PlayerXPosition > PreviousPlayerXPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 90, 0);
                        }

                        if (PlayerZPosition > PreviousPlayerZPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 0, 0);
                        }

                        if (PlayerZPosition < PreviousPlayerZPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 180, 0);
                        }

                        Pillar1.transform.position = new Vector3(PreviousPlayerXPosition, 1.25f, PreviousPlayerZPosition);//add more to the y position so the player is above the gameobject
                    }
                }
            }
        }

        if (PillarMovement2)
        {
            PreviousPlayerXPosition = PlayerXPosition;
            PreviousPlayerZPosition = PlayerZPosition;

            Debug.Log("worked!!");
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
            {
                if (hit.transform.name == "MoveableSpot")//if the player clicks a gameobject that is labelled moveablespot
                {
                    Debug.Log("PlayerBeginMove");
                    GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                    GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                    XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                    ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                    if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                    {
                        Debug.Log("Moved");
                        player.transform.position = hit.transform.position;//set players position to the gameobjects position
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);//add more to the y position so the player is above the gameobject

                        PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
                        PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition

                        if (PlayerXPosition < PreviousPlayerXPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, -90, 0);
                        }

                        if (PlayerXPosition > PreviousPlayerXPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 90, 0);
                        }

                        if (PlayerZPosition > PreviousPlayerZPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 0, 0);
                        }

                        if (PlayerZPosition < PreviousPlayerZPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 180, 0);
                        }

                        Pillar2.transform.position = new Vector3(PreviousPlayerXPosition, 1f, PreviousPlayerZPosition);//add more to the y position so the player is above the gameobject
                    }

                }
            }
        }

        if (PillarMovement3)
        {
            PreviousPlayerXPosition = PlayerXPosition;
            PreviousPlayerZPosition = PlayerZPosition;

            Debug.Log("worked!!");
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
            {
                if (hit.transform.name == "MoveableSpot")//if the player clicks a gameobject that is labelled moveablespot
                {
                    Debug.Log("PlayerBeginMove");
                    GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                    GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                    XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                    ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                    if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                    {
                        Debug.Log("Moved");
                        player.transform.position = hit.transform.position;//set players position to the gameobjects position
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);//add more to the y position so the player is above the gameobject

                        PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
                        PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition

                        if (PlayerXPosition < PreviousPlayerXPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, -90, 0);
                        }

                        if (PlayerXPosition > PreviousPlayerXPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 90, 0);
                        }

                        if (PlayerZPosition > PreviousPlayerZPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 0, 0);
                        }

                        if (PlayerZPosition < PreviousPlayerZPosition)
                        {
                            player.transform.rotation = Quaternion.Euler(0, 180, 0);
                        }

                        Pillar3.transform.position = new Vector3(PreviousPlayerXPosition, 1f, PreviousPlayerZPosition);//add more to the y position so the player is above the gameobject
                    }

                }
            }
        }

        if(flowerunlockcount == 4)
        {
            LockedArea.SetActive(false);
            //frog animation
            Frog.Play();
            Pond.Play();
            LilyPad.Play();
            UnlockedArea.SetActive(true);
            flowerunlockcount++;
        }

    }

    public void MovePillar()
    {
        if (PillarinMovement == false)
        {
            PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
            PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition

            Pillar1XPosition = (int)Pillar1.transform.position.x;//get the gameobjects x position
            Pillar1ZPosition = (int)Pillar1.transform.position.z;//get the gameobjects z position

            Pillar2XPosition = (int)Pillar2.transform.position.x;//get the gameobjects x position
            Pillar2ZPosition = (int)Pillar2.transform.position.z;//get the gameobjects z position

            Pillar3XPosition = (int)Pillar3.transform.position.x;
            Pillar3ZPosition = (int)Pillar3.transform.position.z;

            Pillar1XMaths = Pillar1XPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
            Pillar1ZMaths = Pillar1ZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

            Pillar2XMaths = Pillar2XPosition - PlayerXPosition;
            Pillar2ZMaths = Pillar2ZPosition - PlayerZPosition;

            Pillar3XMaths = Pillar3XPosition - PlayerXPosition;
            Pillar3ZMaths = Pillar3ZPosition - PlayerZPosition;


            if (Pillar1XMaths == -1 || Pillar1XMaths == 1 || Pillar1XMaths == 0)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
            {
                if (Pillar1ZMaths == 1 || Pillar1ZMaths == -1 || Pillar1ZMaths == 0)
                {
                    PillarMovement1 = true;
                    PillarinMovement = true;
                    UI.GetComponent<Level2UI>().PlantAbilityIcon();
                }
            }

            if (Pillar2XMaths == -1 || Pillar2XMaths == 1 || Pillar2XMaths == 0)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
            {
                if (Pillar2ZMaths == 1 || Pillar2ZMaths == -1 || Pillar2ZMaths == 0)
                {
                    PillarMovement2 = true;
                    PillarinMovement = true;
                    UI.GetComponent<Level2UI>().PlantAbilityIcon();
                }
            }

            if (Pillar3XMaths == -1 || Pillar3XMaths == 1 || Pillar3XMaths == 0)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
            {
                if (Pillar3ZMaths == 1 || Pillar3ZMaths == -1 || Pillar3ZMaths == 0)
                {
                    PillarMovement3 = true;
                    PillarinMovement = true;
                    UI.GetComponent<Level2UI>().PlantAbilityIcon();
                }
            }

        }

        else
        {
            PillarinMovement = false;
            PillarMovement1 = false;
            PillarMovement2 = false;
            PillarMovement3 = false;
            UI.GetComponent<Level2UI>().PlantAbilityIcon();
        }


    }


    public void FlowerWater()
    {
        WaterAbility = true;
        UI.GetComponent<Level2UI>().WaterAbilityIcon();
    }


}
