using UnityEngine;

public class TutorialMovementController : MonoBehaviour
{
    //raycasting
    Ray ray;
    RaycastHit hit;

    //get player character
    public GameObject player;

    //to work out if the player is near the targeted gameobject
    public int ZMaths;
    public int XMaths;

    //to hold the players x and z position
    public int PlayerXPosition;
    public int PlayerZPosition;

    public int PreviousPlayerXPosition;
    public int PreviousPlayerZPosition;

    //to hold the targeted gameobjects x and z position
    public int GameObjectXPosition;
    public int GameObjectZPosition;

    public bool crowgone;
    public GameObject Crow;

    public GameObject UI;

    public GameObject MainCamera;

    public Camera cam;

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
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//raycasting

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
        {
            if (hit.transform.name == "MoveableSpot")//if the player clicks a gameobject that is labelled moveablespot
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                PreviousPlayerXPosition = PlayerXPosition;
                PreviousPlayerZPosition = PlayerZPosition;

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = hit.transform.position;//set players position to the gameobjects position
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);//add more to the y position so the player is above the gameobject

                    PlayerXPosition = (int)player.transform.position.x;//update the players XPosition
                    PlayerZPosition = (int)player.transform.position.z;//update the players ZPosition

                    if(PlayerXPosition < PreviousPlayerXPosition)
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

            if(hit.transform.name == "Crow") 
            {
                UI.GetComponent<TutorialUI>().DamageTaken();
                MainCamera.GetComponent<CameraShake>().CameraBeginShake();
            }

            if(hit.transform.name == "PlantElement")
            {
                GameObjectXPosition = (int)hit.transform.position.x;//get the gameobjects x position
                GameObjectZPosition = (int)hit.transform.position.z;//get the gameobjects z position

                XMaths = GameObjectXPosition - PlayerXPosition;//takeaway the players x position fron the gameobjects x position
                ZMaths = GameObjectZPosition - PlayerZPosition;//takeaway the players z position fron the gameobjects z position

                if (XMaths == -1 && ZMaths == 0 || XMaths == 1 && ZMaths == 0 || XMaths == 0 && ZMaths == -1 || XMaths == 0 && ZMaths == 1)//if xmaths = -1, 1 or 0, Essentially if the player is 1, -1 or 0 coordinates away from the gameobject.
                {
                    UI.GetComponent<TutorialUI>().TutorialThreeComplete();
                    MainCamera.GetComponent<CameraShake>().CameraBeginShake();
                }
            }
        }
    }

    public void CrowFly()
    {
        if (PlayerXPosition == 5 && PlayerZPosition == 2)
        {
            Crow.SetActive(false);
            crowgone = true;
        }
        if (PlayerXPosition == 4 && PlayerZPosition == 3)
        {
            Crow.SetActive(false);
            crowgone = true;

        }
    }
}
