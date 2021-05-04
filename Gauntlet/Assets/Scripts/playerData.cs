using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
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
            }

            //Check if player is told to go left within bounds
            if (Input.GetKey(KeyCode.A))
            {
                cPX = cPX - pMS;
            }

            //Check if player is told to go right within bounds
            if (Input.GetKey(KeyCode.D))
            {
                cPX = cPX + pMS;
            }

            //Check if player is told to go down within bounds
            if (Input.GetKey(KeyCode.S))
            {
                cPY = cPY - pMS;
            }
        }

        else if (cPlayer == 2)
        {
            //Check if player is told to go up within bounds
            
        }
    }

    //Player Attack function
}
