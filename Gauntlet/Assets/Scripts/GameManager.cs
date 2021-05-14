using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //The GameManager needs the GameObjects it controls.
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject titlScreen;
    public GameObject gameUI;
    public GameObject scoreScreen;

    public GameObject arrowPrefab;

    //Game Manager needs to check for the choice players make
    public int choice1;
    public int choice2;
    public int choice3;
    public int choice4;
    public bool choiceMade;
    public bool choiceMade2;
    public bool choiceMade3;
    public bool choiceMade4;

    //Public bool for if the player is on the title screen
    public bool title;
    public bool afterGameScore;

    //Public bool for if enemies are to be nuked
    public bool nuke;
    public bool dead1;
    public bool dead2;
    public bool dead3;
    public bool dead4;


    private void Start()
    {
        title = true;
        afterGameScore = false;
        nuke = false;
        dead1 = false;
        dead2 = false;
        dead3 = false;
        dead4 = false;

        choiceMade = false;
        choiceMade2 = false;
        choiceMade3 = false;
        choiceMade4 = false;
    }

    private void FixedUpdate()
    {
        //Start functions
        choice();
        titleScreen();
        

        //Functions running during Game
        nuketime();
        uiSwitch();

        //Function to end game
        resetGame();
    }

    //Code for Title
    private void titleScreen()
    {
        //Title screen
        if (title == true && choiceMade == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            player1.SetActive(true);
            player1.transform.position = new Vector3(0, 0, 0);
            title = false;
        }
    }

    private void resetGame()
    {
        if (title == false && afterGameScore == false && (dead1 == true || player1.activeSelf == false) && (dead2 == true || player2.activeSelf == false) && (dead3 == true || player3.activeSelf == false) && (dead4 == true || player4.activeSelf == false))
        {
            //Reset all enemies in this level
            killEnemies();

            //Turn all players off
            dead1 = false;
            dead2 = false;
            dead3 = false;
            dead4 = false;
            choice1 = 5;
            choice2 = 5;
            choice3 = 5;
            choice4 = 5;
            choiceMade = false;
            choiceMade2 = false;
            choiceMade3 = false;
            choiceMade4 = false;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);

            //Load Title Screen
            SceneManager.LoadScene(2);
            afterGameScore = true;
        }

        if (afterGameScore == true && Input.GetKey(KeyCode.Space))
        {
            //Change to title screen
            SceneManager.LoadScene(0);
            afterGameScore = false;
            title = true;
            Destroy(this.gameObject);
        }
    }

    private void uiSwitch()
    {
        if (title == true && afterGameScore == false)
        {
            titlScreen.SetActive(true);
            //gameUI.SetActive(false);
            //scoreScreen.SetActive(false);
        }
        else if (title == false && afterGameScore == false)
        {
            titlScreen.SetActive(false);
            //gameUI.SetActive(true);
            //scoreScreen.SetActive(false);
        }
        else if (title == false && afterGameScore == true)
        {
            titlScreen.SetActive(false);
            //gameUI.SetActive(false);
            //scoreScreen.SetActive(true);
        }
    }

    private void nuketime()
    {
        if (nuke == true)
        {
            killEnemies();
            nuke = false;
        }
    }

    private void killEnemies()
    {
        //Group all enemies
        GameObject[] dos = GameObject.FindGameObjectsWithTag("death");
        GameObject[] gos = GameObject.FindGameObjectsWithTag("ghost");
        GameObject[] sos = GameObject.FindGameObjectsWithTag("sorcerer");
        GameObject[] des = GameObject.FindGameObjectsWithTag("demon");
        GameObject[] grs = GameObject.FindGameObjectsWithTag("grunt");
        GameObject[] los = GameObject.FindGameObjectsWithTag("lobber");
        GameObject[] tos = GameObject.FindGameObjectsWithTag("thief");

        //Nuke all enemies
        foreach (GameObject pTemp in dos)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in sos)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in des)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in grs)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in los)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in tos)
        {
            Destroy(pTemp);
        }
    }

    private void choice()
    {
        if (choiceMade == false)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                choice1 = 1;
                player1.AddComponent<warriorScript>();
                player1.GetComponent<warriorScript>().cPlayer = 1;
                player1.GetComponent<warriorScript>().hp = 700;
                choiceMade = true;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                choice1 = 2;
                player1.AddComponent<valkScript>();
                player1.GetComponent<valkScript>().cPlayer = 1;
                choiceMade = true;
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                choice1 = 3;
                player1.AddComponent<wizardScript>();
                player1.GetComponent<wizardScript>().cPlayer = 1;
                choiceMade = true;
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                choice1 = 4;
                player1.AddComponent<elfScript>();
                player1.GetComponent<elfScript>().cPlayer = 1;
                choiceMade = true;
            }
        }

        else if (choiceMade == true && choiceMade2 == false)
        {
            if (Input.GetKey(KeyCode.Joystick1Button0) && choice1 != 1)
            {
                player2.AddComponent<warriorScript>();
                player2.GetComponent<warriorScript>().cPlayer = 2;

                player2.transform.position = player1.transform.position;
                player2.SetActive(true);
                choiceMade2 = true;

                choice2 = 1;
            }

            else if (Input.GetKey(KeyCode.Joystick1Button1) && choice1 != 2)
            {
                player2.AddComponent<valkScript>();
                player2.GetComponent<valkScript>().cPlayer = 2;

                player2.transform.position = player1.transform.position;
                player2.SetActive(true);
                choiceMade2 = true;

                choice2 = 2;
            }

            else if (Input.GetKey(KeyCode.Joystick1Button2) && choice1 != 3)
            {
                player2.AddComponent<wizardScript>();
                player2.GetComponent<wizardScript>().cPlayer = 2;

                player2.transform.position = player1.transform.position;
                player2.SetActive(true);
                choiceMade2 = true;

                choice2 = 3;
            }

            else if (Input.GetKey(KeyCode.Joystick1Button3) && choice1 != 4)
            {
                player2.AddComponent<elfScript>();
                player2.GetComponent<elfScript>().cPlayer = 2;

                player2.transform.position = player1.transform.position;
                player2.SetActive(true);
                choiceMade2 = true;

                choice2 = 4;
            }
        }

        else if (choiceMade == true && choiceMade2 == true && choiceMade3 == false)
        {
            if (Input.GetKey(KeyCode.Joystick2Button0) && choice1 != 1 && choice2 != 1)
            {
                player3.AddComponent<warriorScript>();
                player3.GetComponent<warriorScript>().cPlayer = 3;

                player3.transform.position = player1.transform.position;
                player3.SetActive(true);
                choiceMade3 = true;

                choice3 = 1;
            }

            else if (Input.GetKey(KeyCode.Joystick2Button1) && choice1 != 2 && choice2 != 2)
            {
                player3.AddComponent<valkScript>();
                player3.GetComponent<valkScript>().cPlayer = 3;

                player3.transform.position = player1.transform.position;
                player3.SetActive(true);
                choiceMade3 = true;

                choice3 = 2;
            }

            else if (Input.GetKey(KeyCode.Joystick2Button2) && choice1 != 3 && choice2 != 3)
            {
                player3.AddComponent<wizardScript>();
                player3.GetComponent<wizardScript>().cPlayer = 3;

                player3.transform.position = player1.transform.position;
                player3.SetActive(true);
                choiceMade3 = true;

                choice3 = 3;
            }

            else if (Input.GetKey(KeyCode.Joystick2Button3) && choice1 != 4 && choice2 != 4)
            {
                player3.AddComponent<elfScript>();
                player3.GetComponent<elfScript>().cPlayer = 3;

                player3.transform.position = player1.transform.position;
                player3.SetActive(true);
                choiceMade3 = true;

                choice3 = 4;
            }
        }

        else if (choiceMade == true && choiceMade2 == true && choiceMade3 == true && choiceMade4 == false)
        {
            if (Input.GetKey(KeyCode.Joystick3Button0) && choice1 != 1 && choice2 != 1 && choice3 != 1)
            {
                player4.AddComponent<warriorScript>();
                player4.GetComponent<warriorScript>().cPlayer = 4;

                player4.transform.position = player1.transform.position;
                player4.SetActive(true);
                choiceMade4 = true;

                choice4 = 1;
            }

            else if (Input.GetKey(KeyCode.Joystick3Button1) && choice1 != 2 && choice2 != 2 && choice3 != 2)
            {
                player4.AddComponent<valkScript>();
                player4.GetComponent<valkScript>().cPlayer = 4;

                player4.transform.position = player1.transform.position;
                player4.SetActive(true);
                choiceMade4 = true;

                choice4 = 2;
            }

            else if (Input.GetKey(KeyCode.Joystick3Button2) && choice1 != 3 && choice2 != 3 && choice3 != 3)
            {
                player4.AddComponent<wizardScript>();
                player4.GetComponent<wizardScript>().cPlayer = 4;

                player4.transform.position = player1.transform.position;
                player4.SetActive(true);
                choiceMade4 = true;

                choice4 = 3;
            }

            else if (Input.GetKey(KeyCode.Joystick3Button3) && choice1 != 4 && choice2 != 4 && choice3 != 4)
            {
                player4.AddComponent<elfScript>();
                player4.GetComponent<elfScript>().cPlayer = 4;

                player4.transform.position = player1.transform.position;
                player4.SetActive(true);
                choiceMade4 = true;

                choice4 = 4;
            }
        }
    }
}
