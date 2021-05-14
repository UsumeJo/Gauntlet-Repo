using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warriorScript : playerData
{
    //Weapon objects for players to use
    public GameObject axePrefab;
    public GameObject axe;


    void Awake()
    {
        pSE = true;

        //Functions to set
        warStats();
        setControls();
    }

    private void FixedUpdate()
    {
        pMovement();
        pAttackCheck();
    }

    //A function to set stats to Warrior stats
    private void warStats()
    {
        pM = 2;
        pSD = 5;
        pLD = 3;
        pLS = 2;
        pD = 4;
        pMS = 2 * .1f;
    }

    //A function to set all 
    private void attackElf()
    {
        //Check if long range attack or short range attack is true
        if (lRA == true)
        {
            //When long range attack occurs instantiate arrow
            axe = Instantiate(axePrefab) as GameObject;

            //Start it at player's position, dependant on which direction its being shot from
            axe.transform.position = this.transform.position;

            Vector3 destination = axe.transform.position;
            destination.y -= 2.6f;
            axe.GetComponent<pProjectileBehavior>().player = cPlayer;
            axe.GetComponent<pProjectileBehavior>().choice = cChoice;

            if (up == true)
            {
                destination.z += 1;
            }
            else if (left == true)
            {
                destination.x -= 1.1f;
                axe.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);
            }
            else if (right == true)
            {
                destination.x += 1.1f;
                axe.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);
            }
            else
            {
                destination.z -= 1;
            }

            //Return values to arrow
            axe.transform.position = destination;

            lRA = false;
        }

    }
}
