using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    //Game manager
    public GameObject gameManager;

    //Every player needs variables for their stats
    public float pMS; //Player Movement speed
    public int pHP; //Player Health Points
    public int pM; //Player Magic
    public int pLD; //Player Long-Range Damage
    public int pLS; //Player Long-Range Speed
    public int pSD; //Player Short-Range Damage
    public int pD; //Player Defense

    //Every player needs to track their coordinates
    public float cPX; //Current Player X value
    public float cPY; //Current Player Y value

    //Can short range attacks destroy Generators
    public bool pSE;

    //Variable for checking which player
    public int cPlayer;

    //Variables for controllers
    public float cX1; //Controller 1 horizontal axis
    public float cY1; //Controller 1 vertical axis

    //Variable for attacking
    public int potions;
    public bool sRA; //Potions
    public bool lRA; //Long Range Attack 
    public bool lRS; //Long Range Shot ended

    //Variable for direction
    public bool up;
    public bool left;
    public bool right;
    public bool down;

    //Variable for misc stats
    public int hp;
    public int hpcd;
    public int score;
    public int key;
    public int itPot;

    //Variable for character choice
    public int cChoice; //Character Choice| 1 = Warrior; 2 = Valkyrie; 3 = Wizard; 4 = Elf

    //Special items
    public int lootB;
    public int heart;


    public void setControls()
    {
        if (cPlayer > 1)
        {
            cX1 = Input.GetAxis("Joy" + (cPlayer - 1) + "X");
            cY1 = Input.GetAxis("Joy" + (cPlayer - 1) + "Y");
        }

        //Variable for direction
        up = true;
        left = false;
        right = false;
        down = false;

        //Variable for hp
        hp = 700;
        hpcd = 10;
        score = 0;
        key = 0;

        itPot = 0;
        lootB = 0;
        heart = 0;

        gameManager = GameObject.Find("Game Manager");
    }

    //Player Movement function
    public void pMovement()
    {
        //Check which player this is
        if (cPlayer == 1)
        {
            //Check for if player is within bounds and is being told to go up
            if (Input.GetKey(KeyCode.W))
            {
                cPY = cPY + pMS;

                //Variable for direction
                up = true;
                left = false;
                right = false;
                down = false;
            }

            //Check if player is told to go left within bounds
            if (Input.GetKey(KeyCode.A))
            {
                cPX = cPX - pMS;

                //Variable for direction
                up = false;
                left = true;
                right = false;
                down = false;
            }

            //Check if player is told to go right within bounds
            if (Input.GetKey(KeyCode.D))
            {
                cPX = cPX + pMS;

                //Variable for direction
                up = false;
                left = false;
                right = true;
                down = false;
            }

            //Check if player is told to go down within bounds
            if (Input.GetKey(KeyCode.S))
            {
                cPY = cPY - pMS;

                //Variable for direction
                up = false;
                left = false;
                right = false;
                down = true;
            }
        }

        else if (cPlayer > 1 && cPlayer < 5)
        {
            //Check if player is told to go up within bounds
            if (cX1 > 0)
            {
                cPX = cPX + pMS;

                //Variable for direction
                up = true;
                left = false;
                right = false;
                down = false;
            }
            //Check if player is told to go down within bounds
            else if (cX1 < 0)
            {
                cPX = cPX - pMS;

                //Variable for direction
                up = false;
                left = false;
                right = false;
                down = true;
            }

            //Check if player is told to go right within bounds
            if (cY1 > 0)
            {
                cPY = cPY + pMS;

                //Variable for direction
                up = false;
                left = false;
                right = true;
                down = false;
            }
            //Check if player is told to go left within bounds
            else if (cPY < 0)
            {
                cPY = cPY - pMS;

                //Variable for direction
                up = false;
                left = true;
                right = false;
                down = false;
            }
        }

        this.transform.position = new Vector3(cPX, 0, cPY);
    }

    public void hpDrain()
    {
        if (hp > 0 && hpcd <= 0)
        {
            hp--;
            hpcd = 100;
        }

        if (hpcd > 0)
        {
            hpcd--;
        }
    }

    //Player Attack function
    public void pAttackCheck()
    {
        //Check which player this is
        //If player 1 check keyboard
        if (cPlayer == 1)
        {
            //If player right shifts,  
            if (Input.GetKey(KeyCode.Space) && lRS == false)
            {
                lRS = true;
                lRA = true;
            }

            //if player presses return potions
            else if (Input.GetKey(KeyCode.Return) && potions > 0)
            {
                sRA = true;
                potions--;
            }
        }

        //If player is greater than 1 use joystick
        else if (cPlayer == 2)
        {
            //Press A to close range
            if (Input.GetKey(KeyCode.Joystick1Button0) && potions > 0)
            {
                sRA = true;
                potions--;
            }

            else if (Input.GetKey(KeyCode.Joystick1Button1) && lRS == false)
            {
                lRS = true;
                lRA = true;
            }
        }
        else if (cPlayer == 3)
        {
            //Press A to close range
            if (Input.GetKey(KeyCode.Joystick2Button0) && potions > 0)
            {
                sRA = true;
                potions--;
            }

            else if (Input.GetKey(KeyCode.Joystick2Button1) && lRS == false)
            {
                lRS = true;
                lRA = true;
            }
        }
        else if (cPlayer == 4)
        {
            //Press A to close range
            if (Input.GetKey(KeyCode.Joystick3Button0) && potions > 0)
            {
                sRA = true;
                potions--;
            }

            else if (Input.GetKey(KeyCode.Joystick3Button1) && lRS == false)
            {
                lRS = true;
                lRA = true;
            }
        }
    }

    public void nukeCheck()
    {
        if (sRA == true)
        {
            gameManager.GetComponent<GameManager>().nuke = true;
        }
    }
}
