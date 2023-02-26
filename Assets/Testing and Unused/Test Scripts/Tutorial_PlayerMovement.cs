using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_PlayerMovement : MonoBehaviour//OLD tutorial movement script
{

    Ray ray;
    RaycastHit hit;

    public int PlayerPositionx = 4;
    public int PlayerPositiony = 1;

    public GameObject player;

    public GameObject UI;

    public GameObject Crow;

    public bool crowgone;

    public float timer;
    public bool timerbegin;

    // Update is called once per frame
    void Update()
    {
        if(timerbegin)//triggered when the player collects the plant element
        {
            timer = timer + 1 * Time.deltaTime;
        }

        if(timer > 5f)//when timer = 5, end the game
        {
            SceneManager.LoadScene("EndScreen");
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//raycasting
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))//if mouse over object and mouse click
        {
            //check the mouses position and what it is overlapping
            if (hit.transform.name == "MoveableSpot (5,1)")
            {
                //check players position
                if (PlayerPositionx == 4 && PlayerPositiony == 1)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-9.25f, 4.5f, -3f);
                    PlayerPositionx = 5;
                    PlayerPositiony = 1;
                }

                if (PlayerPositionx == 5 && PlayerPositiony == 2)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-9.25f, 4.5f, -3f);
                    PlayerPositionx = 5;
                    PlayerPositiony = 1;
                }

            }//done
            if (hit.transform.name == "MoveableSpot (4,1)")
            {
                if (PlayerPositionx == 3 && PlayerPositiony == 1)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-10f, 4.5f, -1.25f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 1;
                }

                if (PlayerPositionx == 5 && PlayerPositiony == 1)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-10f, 4.5f, -1.25f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 1;
                }

                if (PlayerPositionx == 4 && PlayerPositiony == 2)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-10f, 4.5f, -1.25f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 1;
                }
            }//done
            if(hit.transform.name == "MoveableSpot (3,1)")
            {
                if(PlayerPositionx == 4 && PlayerPositiony == 1)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-11f, 4.5f, 0.75f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 1;
                }

                if (PlayerPositionx == 3 && PlayerPositiony == 2)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-11f, 4.5f, 0.75f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 1;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (2,2)")
            {
                if(PlayerPositionx == 3 && PlayerPositiony == 2)
                {
                    player.transform.position = new Vector3(-10.35f, 4.5f, 3f);
                    PlayerPositionx = 2;
                    PlayerPositiony = 2;
                }
                
                if(PlayerPositionx == 2 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-10.35f, 4.5f, 3f);
                    PlayerPositionx = 2;
                    PlayerPositiony = 2;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (3,2)")
            {
                if(PlayerPositionx == 3 && PlayerPositiony == 1)
                {
                    player.transform.position = new Vector3(-9.5f, 4.5f, 1.25f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 2;
                }

                if (PlayerPositionx == 2 && PlayerPositiony == 2)
                {
                    player.transform.position = new Vector3(-9.5f, 4.5f, 1.25f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 2;
                }

                if (PlayerPositionx == 4 && PlayerPositiony == 2)
                {
                    player.transform.position = new Vector3(-9.5f, 4.5f, 1.25f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 2;
                }

                if (PlayerPositionx == 3 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-9.5f, 4.5f, 1.25f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 2;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (4,2)")
            {
                if(PlayerPositionx == 4 && PlayerPositiony == 3)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-8.6f, 4.5f, -0.45f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 2;
                }

                if (PlayerPositionx == 5 && PlayerPositiony == 2)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-8.6f, 4.5f, -0.45f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 2;
                }

                if (PlayerPositionx == 3 && PlayerPositiony == 2)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-8.6f, 4.5f, -0.45f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 2;
                }

                if (PlayerPositionx == 4 && PlayerPositiony == 1)
                {
                    UI.GetComponent<TutorialUI>().TutorialOneComplete();
                    player.transform.position = new Vector3(-8.6f, 4.5f, -0.45f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 2;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (5,2)")
            {
                if(PlayerPositionx == 5 && PlayerPositiony == 1)
                {
                    player.transform.position = new Vector3(-7.6f, 4.5f, -2.25f);
                    PlayerPositionx = 5;
                    PlayerPositiony = 2;
                }

                if (PlayerPositionx == 4 && PlayerPositiony == 2)
                {
                    player.transform.position = new Vector3(-7.6f, 4.5f, -2.25f);
                    PlayerPositionx = 5;
                    PlayerPositiony = 2;
                }

                if (PlayerPositionx == 5 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-7.6f, 4.5f, -2.25f);
                    PlayerPositionx = 5;
                    PlayerPositiony = 2;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (1,3)")
            {
                if(PlayerPositionx == 2 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-9.5f, 4.5f, 5.75f);
                    PlayerPositionx = 1;
                    PlayerPositiony = 3;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (2,3)")
            {
                if(PlayerPositionx == 3 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-8.75f, 4.5f, 4f);
                    PlayerPositionx = 2;
                    PlayerPositiony = 3;
                }

                if(PlayerPositionx == 1 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-8.75f, 4.5f, 4f);
                    PlayerPositionx = 2;
                    PlayerPositiony = 3;
                }

                if(PlayerPositionx == 2 && PlayerPositiony == 2)
                {
                    player.transform.position = new Vector3(-8.75f, 4.5f, 4f);
                    PlayerPositionx = 2;
                    PlayerPositiony = 3;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (3,3)")
            {
                if(PlayerPositionx == 3 && PlayerPositiony == 4)
                {
                    Debug.Log("Movement to 3,3");
                    player.transform.position = new Vector3(-7.75f, 4.5f, 2.25f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 3;
                }

                if (PlayerPositionx == 2 && PlayerPositiony == 3)
                {
                    Debug.Log("Movement to 3,3");
                    player.transform.position = new Vector3(-7.75f, 4.5f, 2.25f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 3;
                }

                if(PlayerPositionx == 3 && PlayerPositiony == 2)
                {
                    Debug.Log("Movement to 3,3");
                    player.transform.position = new Vector3(-7.75f, 4.5f, 2.25f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 3;
                }

                if(PlayerPositionx == 4 && PlayerPositiony == 3)
                {
                    Debug.Log("Movement to 3,3");
                    player.transform.position = new Vector3(-7.75f, 4.5f, 2.25f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 3;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (4,3)")
            {
                if(PlayerPositionx == 5 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-6.8f, 4.5f, 0.3f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 3;
                }

                if(PlayerPositionx == 3 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-6.8f, 4.5f, 0.3f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 3;
                }

                if(PlayerPositionx == 4 && PlayerPositiony == 2)
                {
                    player.transform.position = new Vector3(-6.8f, 4.5f, 0.3f);
                    PlayerPositionx = 4;
                    PlayerPositiony = 3;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (5,3)") //CROW POSITION
            {
                if (PlayerPositionx == 5 && PlayerPositiony == 2 && crowgone)
                {
                    player.transform.position = new Vector3(-6f, 4.5f, -1.3f);
                    PlayerPositionx = 5;
                    PlayerPositiony = 3;
                }
                else
                {
                    if(crowgone == false)
                    {
                        UI.GetComponent<TutorialUI>().DamageTaken();

                    }
                }
                if (PlayerPositionx == 4 && PlayerPositiony == 3 && crowgone)
                {
                    player.transform.position = new Vector3(-6f, 4.5f, -1.3f);
                    PlayerPositionx = 5;
                    PlayerPositiony = 3;
                }
                else
                {
                    if (crowgone == false)
                    {
                        UI.GetComponent<TutorialUI>().DamageTaken();

                    }
                }
            }//done
            if (hit.transform.name == "MoveableSpot (3,4)")
            {
                if(PlayerPositionx == 3 && PlayerPositiony == 3)
                {
                    player.transform.position = new Vector3(-6f, 4.5f, 3f);
                    PlayerPositionx = 3;
                    PlayerPositiony = 4;
                }
            }//done
            if (hit.transform.name == "MoveableSpot (5,4" || hit.transform.name == "Tutorial_PlantElement_CandiceDennis")
            {
                if(PlayerPositionx == 5 && PlayerPositiony == 3)
                {
                    UI.GetComponent<TutorialUI>().TutorialThreeComplete();
                    //player.transform.position = new Vector3(-9f, 2.56f, 1f);
                    PlayerPositionx = 10; // so the player cant move
                    PlayerPositiony = 5; //so the player cant move
                    timerbegin = true;
                }
            }
        }
    }

    public void CrowFly()//if player use ability and are by crow, crow fly away
    {
        if(PlayerPositionx == 5 && PlayerPositiony == 2)
        {
            Crow.SetActive(false);
            crowgone = true;
        }
        if(PlayerPositionx == 4 && PlayerPositiony == 3)
        {
            Crow.SetActive(false);
            crowgone = true;

        }
    }
}
