using UnityEngine;
public class Level3PlayerMovement : MonoBehaviour
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

    public GameObject Pillar1;
    public GameObject Pillar2;
    public GameObject Pillar3;

    public GameObject LockedArea;
    public GameObject UnlockedArea;

    public GameObject FlowerUnlock1a;
    public GameObject FlowerUnlock2a;

    public GameObject FlowerUnlock1b;
    public GameObject FlowerUnlock2b;

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
    public bool FireAbility;

    public int PreviousPlayerXPosition;
    public int PreviousPlayerZPosition;

    public bool PillarinMovement;

    public int PillarCount;
    public bool BothPillarsinPlace;

    public GameObject Guardian1;
    public GameObject Guardian1Interacted;
    public GameObject Guardian2;
    public GameObject Guardian2Interacted;
    public GameObject Guardian3;
    public GameObject Guardian3Interacted;

    public int GuardiansCount;

    public GameObject Next;

    public GameObject Flower1;
    public GameObject Flower2;
    public GameObject Flower1Watered;
    public GameObject Flower2Watered;

    // Start is called before the first frame update
    void Start()
    {
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

        if (Pillar1XPosition == 3 && Pillar1ZPosition == 8 || Pillar1XPosition == 4 && Pillar1ZPosition == 8 || Pillar1XPosition == 5 && Pillar1ZPosition == 8 || Pillar1XPosition == 6 && Pillar1ZPosition == 8 || Pillar1XPosition == 4 && Pillar1ZPosition == 7 || Pillar1XPosition == 5 && Pillar1ZPosition == 7)
        {
            Pillar1.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }
        if (Pillar2XPosition == 3 && Pillar2ZPosition == 8 || Pillar2XPosition == 4 && Pillar2ZPosition == 8 || Pillar2XPosition == 5 && Pillar2ZPosition == 8 || Pillar2XPosition == 6 && Pillar2ZPosition == 8 || Pillar2XPosition == 4 && Pillar2ZPosition == 7 || Pillar2XPosition == 5 && Pillar2ZPosition == 7)
        {
            Pillar2.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }
        
        if(GuardiansCount == 3)
        {
            Next.SetActive(true);
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//raycasting
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
        {
            if (hit.transform.name == "MoveableSpot" && PillarinMovement == false)//if the player clicks a gameobject that is labelled moveablespot
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                PreviousPlayerXPosition = PlayerXPosition;
                PreviousPlayerZPosition = PlayerZPosition;

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

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

            if (hit.transform.name == "Burnable" && FireAbility == true)
            {
                Debug.Log("Burn!");
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                {
                    Debug.Log("Burned!");
                    Object.Destroy(hit.transform.gameObject);
                    UI.GetComponent<Level3UI>().FireAbilityIcon();
                    FireAbility = false;

                    XMaths = 0;//reset XMaths
                    ZMaths = 0;//reset ZMaths
                }
            }

            if (hit.transform.name == "Flower1" && WaterAbility == true)
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)
                {
                    FlowerUnlock1a.SetActive(false);
                    FlowerUnlock1b.SetActive(true);
                    Flower1.SetActive(false);
                    Flower1Watered.SetActive(true);
                    flowerunlockcount++;
                    UI.GetComponent<Level3UI>().WaterAbilityIcon();
                    WaterAbility = false;  
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
                    flowerunlockcount++;
                    Flower2.SetActive(false);
                    Flower2Watered.SetActive(true);
                    UI.GetComponent<Level3UI>().WaterAbilityIcon();
                    WaterAbility = false;
                }
            }

            if(hit.transform.name == "Guardian1")
            {
                if (PlayerXPosition == 1 && PlayerZPosition == 3 || PlayerXPosition == 2 && PlayerZPosition == 3)
                {
                    GuardiansCount++;
                    Guardian1.SetActive(false);
                    Guardian1Interacted.SetActive(true);
                }
            }

            if (hit.transform.name == "Guardian2")
            {
                if (PlayerXPosition == 12 && PlayerZPosition == 1 || PlayerXPosition == 12 && PlayerZPosition == 2 || PlayerXPosition == 11 && PlayerZPosition == 3 || PlayerXPosition == 10 && PlayerZPosition == 3)
                {
                    GuardiansCount++;
                    Guardian2.SetActive(false);
                    Guardian2Interacted.SetActive(true);
                }
            }

            if (hit.transform.name == "Guardian3")
            {
                if (PlayerXPosition == 12 && PlayerZPosition == 12 || PlayerXPosition == 11 && PlayerZPosition == 12)
                {
                    GuardiansCount++;
                    Guardian3.SetActive(false);
                    Guardian3Interacted.SetActive(true);
                    Next.SetActive(true);
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

                        Pillar1.transform.position = new Vector3(PreviousPlayerXPosition, 1.5f, PreviousPlayerZPosition);//add more to the y position so the player is above the gameobject
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

                        Pillar2.transform.position = new Vector3(PreviousPlayerXPosition, 1.5f, PreviousPlayerZPosition);//add more to the y position so the player is above the gameobject
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

                        Pillar3.transform.position = new Vector3(PreviousPlayerXPosition, 1.5f, PreviousPlayerZPosition);//add more to the y position so the player is above the gameobject
                    }

                }
            }
        }

        if (flowerunlockcount == 2)
        {
            LockedArea.SetActive(false);
            UnlockedArea.SetActive(true);
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
                    UI.GetComponent<Level3UI>().PlantAbilityIcon();
                }
            }

            if (Pillar2XMaths == -1 || Pillar2XMaths == 1 || Pillar2XMaths == 0)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
            {
                if (Pillar2ZMaths == 1 || Pillar2ZMaths == -1 || Pillar2ZMaths == 0)
                {
                    PillarMovement2 = true;
                    PillarinMovement = true;
                    UI.GetComponent<Level3UI>().PlantAbilityIcon();
                }
            }

            if (Pillar3XMaths == -1 || Pillar3XMaths == 1 || Pillar3XMaths == 0)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
            {
                if (Pillar3ZMaths == 1 || Pillar3ZMaths == -1 || Pillar3ZMaths == 0)
                {
                    PillarMovement3 = true;
                    PillarinMovement = true;
                    UI.GetComponent<Level3UI>().PlantAbilityIcon();
                }
            }

        }

        else
        {
            PillarinMovement = false;
            PillarMovement1 = false;
            PillarMovement2 = false;
            PillarMovement3 = false;
            UI.GetComponent<Level3UI>().PlantAbilityIcon();
        }
    }


    public void FlowerWater()
    {
        WaterAbility = true;
        UI.GetComponent<Level3UI>().WaterAbilityIcon();
    }

    public void BurnObject()
    {
        FireAbility = true;
        UI.GetComponent<Level3UI>().FireAbilityIcon();
    }
}
