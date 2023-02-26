using UnityEngine;

public class Level1_PlayerMovement : MonoBehaviour
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

    public int Pillar1XPosition;
    public int Pillar1ZPosition;

    public int Pillar2XPosition;
    public int Pillar2ZPosition;

    public bool PillarMovement2;
    public bool PillarMovement1;

    public int PreviousPlayerXPosition;
    public int PreviousPlayerZPosition;

    public bool PillarinMovement;

    public int PillarCount;
    public bool BothPillarsinPlace; 

    // Start is called before the first frame update
    void Start()
    {
        //store the players current position
        PlayerXPosition = (int)player.transform.position.x;
        PlayerZPosition = (int)player.transform.position.z;
        PlayerYPosition = player.transform.position.y;

        Pillar1XPosition = (int)Pillar1.transform.position.x;
        Pillar1ZPosition = (int)Pillar1.transform.position.z;

        Pillar2XPosition = (int)Pillar2.transform.position.x;
        Pillar2ZPosition = (int)Pillar2.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        if (Pillar1XPosition == 5 && Pillar1ZPosition == 10 || Pillar1XPosition == 6 && Pillar1ZPosition == 10 || Pillar1XPosition == 7 && Pillar1ZPosition == 10)
        {
            Pillar1.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }
        if (Pillar2XPosition == 5 && Pillar2ZPosition == 10 || Pillar2XPosition == 6 && Pillar2ZPosition == 10 || Pillar2XPosition == 7 && Pillar2ZPosition == 10)
        {
            Pillar2.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }
        
        Pillar1XPosition = (int)Pillar1.transform.position.x;//get the gameobjects x position
        Pillar1ZPosition = (int)Pillar1.transform.position.z;//get the gameobjects z position

        Pillar2XPosition = (int)Pillar2.transform.position.x;//get the gameobjects x position
        Pillar2ZPosition = (int)Pillar2.transform.position.z;//get the gameobjects z position

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//raycasting
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
        {
            if (hit.transform.name == "MoveableSpot" && PillarinMovement == false && PillarMovement1 == false && PillarMovement2 == false)//if the player clicks a gameobject that is labelled moveablespot
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position
                GameObjectYPosition = (float)hit.transform.position.y;

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position
                YMaths = GameObjectYPosition - PlayerYPosition;

                PreviousPlayerXPosition = PlayerXPosition;
                PreviousPlayerZPosition = PlayerZPosition;

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                {
                    player.transform.position = hit.transform.position;//set players position to the gameobjects position
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);//add more to the y position so the player is above the gameobject

                    PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
                    PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition
                    PlayerYPosition = (float)player.transform.position.y;

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


            if(hit.transform.name == "WaterElement")
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position
                GameObjectYPosition = (float)hit.transform.position.y;

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                {
                    UI.GetComponent<Level1UI>().WaterFoxBegin();

                    XMaths = 0;//reset XMaths
                    ZMaths = 0;//reset ZMaths
                }
            }

            if(hit.transform.name == "HighMoveableSpot")
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
                    if (PlayerYPosition == 1.7f || PlayerYPosition == 2.5f)
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

                        Pillar1.transform.position = new Vector3(PreviousPlayerXPosition, 0.85f, PreviousPlayerZPosition);//add more to the y position so the player is above the gameobject
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

                        Pillar2.transform.position = new Vector3(PreviousPlayerXPosition, 1.2f, PreviousPlayerZPosition);//add more to the y position so the player is above the gameobject
                    }

                }
            }
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

            Pillar1XMaths = Pillar1XPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
            Pillar1ZMaths = Pillar1ZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

            Pillar2XMaths = Pillar2XPosition - PlayerXPosition;
            Pillar2ZMaths = Pillar2ZPosition - PlayerZPosition;

            if (Pillar1XMaths == -1 || Pillar1XMaths == 1 || Pillar1XMaths == 0)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
            {
                if (Pillar1ZMaths == 1 || Pillar1ZMaths == -1 || Pillar1ZMaths == 0)
                {
                    PillarMovement1 = true;
                    UI.GetComponent<Level1UI>().PlantAbilityIcon();
                    PillarinMovement = true;
                }
            }

            if (Pillar2XMaths == -1 || Pillar2XMaths == 1 || Pillar2XMaths == 0)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
            {
                if (Pillar2ZMaths == 1 || Pillar2ZMaths == -1 || Pillar2ZMaths == 0)
                {
                    PillarMovement2 = true;
                    UI.GetComponent<Level1UI>().PlantAbilityIcon();
                    PillarinMovement = true;
                }
            }

        }

        else
        {
            PillarinMovement = false;
            PillarMovement1 = false;
            PillarMovement2 = false;
            UI.GetComponent<Level1UI>().PlantAbilityIcon();
        }

        if (Pillar1XPosition == 5 && Pillar1ZPosition == 10 || Pillar1XPosition == 6 && Pillar1ZPosition == 10 || Pillar1XPosition == 7 && Pillar1ZPosition == 10)
        {
            Pillar1.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }
        if (Pillar2XPosition == 5 && Pillar2ZPosition == 10 || Pillar2XPosition == 6 && Pillar2ZPosition == 10 || Pillar2XPosition == 7 && Pillar2ZPosition == 10)
        {
            Pillar2.name = "MoveableSpot";//enables the player to move ontop of the pillar
        }

    }


}
