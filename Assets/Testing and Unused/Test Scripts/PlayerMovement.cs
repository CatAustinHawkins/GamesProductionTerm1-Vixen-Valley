using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour//OLD movement script, used in milestone 1 gameplay
{
    Ray ray;
    RaycastHit hit;
    public GameObject player;
    public GameObject puzzlecube;

    public int PlayerPositionx = 1;
    public int PlayerPositiony;

    public Text Goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if(hit.transform.name == "Puzzle")
            {
                if(PlayerPositionx == 1 && PlayerPositiony == 0)
                {
                    puzzlecube.transform.position = new Vector3(1, 1.2f, 2);
                }

                if(PlayerPositionx == 1 && PlayerPositiony == 1)
                {
                    puzzlecube.transform.position = new Vector3(2, 1.2f, 2);
                }
                Debug.Log("Puzzle Piece Touched");
            }

            if (hit.transform.name == "Cube (1,0)")
            {
                if (PlayerPositionx == 1 && PlayerPositiony == 1)
                {
                    Debug.Log("Moving to Cube 1,0");
                    player.transform.position = new Vector3(-1.35f, 0.5f, 2f);
                    PlayerPositionx = 1;
                    PlayerPositiony = 0;
                }

                if (PlayerPositionx == 2 && PlayerPositiony == 0)
                {
                    Debug.Log("Moving to Cube 1,0");
                    player.transform.position = new Vector3(-1.35f, 0.5f, 2f);
                    PlayerPositionx = 1;
                    PlayerPositiony = 0;
                }
            }

            if (hit.transform.name == "Cube (2,0)")
            {
                if(PlayerPositionx == 1 && PlayerPositiony == 0)
                {
                    Debug.Log("Moving to Cube 2,0");
                    player.transform.position = new Vector3(-1.35f, 0.5f, 1f);
                    PlayerPositionx = 2;
                    PlayerPositiony = 0;
                }

                if(PlayerPositionx == 3 && PlayerPositiony == 0 )
                {
                    Debug.Log("Moving to Cube 2,0");
                    player.transform.position = new Vector3(-1.35f, 0.5f, 1f);
                    PlayerPositionx = 2;
                    PlayerPositiony = 0;
                }

                if(PlayerPositionx == 3 && PlayerPositiony == 0)
                {
                    Debug.Log("Moving to Cube 2,0");
                    player.transform.position = new Vector3(-1.35f, 0.5f, 1f);
                    PlayerPositionx = 2;
                    PlayerPositiony = 0;
                }
            }

            ///if (hit.transform.name == "Cube (3,0)")
        //    {
       //         if(PlayerPositionx == 2 && PlayerPositiony == 0)
      //          {
      //              Debug.Log("Moving to Cube 3,0");
      //              player.transform.position = new Vector3(-1.35f, 0.5f, 0f);
       //             PlayerPositionx = 3;
       //             PlayerPositiony = 0;
     //           }
      //          if (PlayerPositionx == 4 && PlayerPositiony == 0)
    //            {
    //                Debug.Log("Moving to Cube 3,0");
    //                player.transform.position = new Vector3(-1.35f, 0.5f, 0f);
       //             PlayerPositionx = 3;
       //             PlayerPositiony = 0;
      //          }
        //        if(PlayerPositionx == 3 && PlayerPositiony == 1)
     //           {
      //              Debug.Log("Moving to Cube 3,0");
      //              player.transform.position = new Vector3(-1.35f, 0.5f, 0f);
    //                PlayerPositionx = 3;
  //                  PlayerPositiony = 0;
//                }
            //}

            if (hit.transform.name == "Cube (4,0)")
            {
                if(PlayerPositionx == 3 && PlayerPositiony == 0)
                {
                    Debug.Log("Moving to Cube 4,0");
                    player.transform.position = new Vector3(-1.35f, 0.5f, -1f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 0;
                }
                if(PlayerPositionx == 4 && PlayerPositiony == 1)
                {
                    Debug.Log("Moving to Cube 4,0");
                    player.transform.position = new Vector3(-1.35f, 0.5f, -1f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 0;
                }
            }

            if(hit.transform.name == "Cube (1,1)")
            {
                if (PlayerPositionx == 1 && PlayerPositiony == 0)
                {
                    player.transform.position = new Vector3(-0.35f, 0.5f, 2f);
                    PlayerPositionx = 1;
                    PlayerPositiony = 1;
                }

                if(PlayerPositionx == 1 && PlayerPositiony == 2)
                {
                    player.transform.position = new Vector3(-0.35f, 0.5f, 2f);
                    PlayerPositionx = 1;
                    PlayerPositiony = 1;
                }

                if(PlayerPositionx == 2 && PlayerPositiony == 1)
                {
                    player.transform.position = new Vector3(-0.35f, 0.5f, 2f);
                    PlayerPositionx = 1;
                    PlayerPositiony = 1;
                }

            }

            //UNDONE
            if(hit.transform.name == "Cube (1,2)")
            {
                player.transform.position = new Vector3(0.6f, 0.5f, 2f);
                PlayerPositionx = 1;
                PlayerPositiony = 2;
                //0.6, 0.5, 2
            }

            if(hit.transform.name == "Cube (1,3)")
            {
                player.transform.position = new Vector3(1.65f, 0.5f, 2);
                //1.65, 0.5, 2
                PlayerPositionx = 1;
                PlayerPositiony = 3;
            }

            if(hit.transform.name == "Cube (2,3)")
            {
                player.transform.position = new Vector3(1.65f, 0.5f, 1);
                //1.65, 0.5, 1
                PlayerPositionx = 2;
                PlayerPositiony = 3;
            }

            if(hit.transform.name == "Cube (3,3")
            {
                player.transform.position = new Vector3(1.65f, 0.5f, 0);
                //1.65, 0.5, 0
                PlayerPositionx = 3;
                PlayerPositiony = 3;
            }

            if(hit.transform.name == "Cube (4,3)")
            {
                player.transform.position = new Vector3(1.65f, 0.5f, -1);
                //1.65, 0.5, -1
                PlayerPositionx = 4;
                PlayerPositiony = 3;
            }

        //    if(hit.transform.name == "Cube (2,1)")
        //    {
        //        player.transform.position = new Vector3(-0.35f, 0.5f, 1);
                //-0.35, 0.5, 1
        //        PlayerPositionx = 2;
        //        PlayerPositiony = 1;
        //    }

            if(hit.transform.name == "Cube (2,2)")
            {
                player.transform.position = new Vector3(0.6f, 0.5f, 1);
                //0.6, 0.5, 1
                PlayerPositionx = 2;
                PlayerPositiony = 2;
            }

            if(hit.transform.name == "Cube (3,1)")
            {
                player.transform.position = new Vector3(-0.35f, 0.5f, 0);
                //-0.35, 0.5, 0
                PlayerPositionx = 3;
                PlayerPositiony = 1;
            }

            if(hit.transform.name == "Cube (3,2)")
            {
                player.transform.position = new Vector3(0.6f, 0.5f, 0);
                //0.6, 0.5, 0
                PlayerPositionx = 3;
                PlayerPositiony = 2;
            }

            if (hit.transform.name == "Cube (4,1)")
            {
                player.transform.position = new Vector3(-0.35f, 0.5f, -1);
                //-0.35, 0.5, -1
                PlayerPositionx = 4;
                PlayerPositiony = 1;
            }

            if (hit.transform.name == "Cube (4,2)")
            {
                player.transform.position = new Vector3(0.6f, 0.5f, -1);
                //0.6, 0.5, -1
                PlayerPositionx = 4;
                PlayerPositiony = 2;
            }
        }
        
        if(hit.transform.name == "Flower")
        {
            Debug.Log("Flower Touched");
            Goal.text = "Goal Reached";
        }
    }


}
