using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valkScript : playerData
{
    //Weapon objects for players to use
    public GameObject swordPrefab;
    public GameObject sword;

    private void Awake()
    {
        pSE = true;

        //Functions to set
        valkStats();
        setControls();
    }

    private void FixedUpdate()
    {
        pMovement();
        pAttackCheck();
        attackValk();
    }

    //A function to set valk stats
    private void valkStats()
    {
        pM = 3;
        pSD = 4;
        pLD = 1;
        pLS = 5;
        pD = 4;
        pMS = 4 * .1f;
    }

    //A function to set all 
    private void attackValk()
    {
        //Check if long range attack or short range attack is true
        if (lRA == true)
        {
            //When long range attack occurs instantiate arrow
            sword = Instantiate(swordPrefab) as GameObject;

            //Start it at player's position, dependant on which direction its being shot from
            sword.transform.position = this.transform.position;

            Vector3 destination = sword.transform.position;
            destination.y -= 2.6f;
            sword.GetComponent<pProjectileBehavior>().player = cPlayer;
            sword.GetComponent<pProjectileBehavior>().choice = cChoice;

            if (up == true)
            {
                destination.z += 1;
            }
            else if (left == true)
            {
                destination.x -= 1.1f;
                sword.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);
            }
            else if (right == true)
            {
                destination.x += 1.1f;
                sword.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);
            }
            else
            {
                destination.z -= 1;
            }

            //Return values to arrow
            sword.transform.position = destination;

            lRA = false;
        }

    }
}
