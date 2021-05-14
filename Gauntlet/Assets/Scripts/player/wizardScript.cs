using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardScript : playerData
{
    //Weapon objects for players to use
    public GameObject fireBallPrefab;
    public GameObject fireBall;

    void Awake()
    {
        pSE = false;

        //Functions to set
        wizStats();
        setControls();
    }

    private void FixedUpdate()
    {
        pMovement();
        pAttackCheck();
        attackWiz();
    }

    //A function to set stats to Wizard stats
    private void wizStats()
    {
        pM = 8;
        pSD = 2;
        pLD = 2;
        pLS = 8;
        pD = 0;
        pMS = 2 * .1f;
    }

    //A function to set all 
    private void attackWiz()
    {
        //Check if long range attack or short range attack is true
        if (lRA == true)
        {
            //When long range attack occurs instantiate fireBall
            fireBallPrefab = Instantiate(fireBallPrefab) as GameObject;

            //Start it at player's position, dependant on which direction its being shot from
            fireBall.transform.position = this.transform.position;

            Vector3 destination = fireBall.transform.position;
            destination.y -= 2.6f;
            fireBall.GetComponent<pProjectileBehavior>().player = cPlayer;
            fireBall.GetComponent<pProjectileBehavior>().choice = cChoice;

            if (up == true)
            {
                destination.z += 1;
                fireBall.GetComponent<pProjectileBehavior>().up = true;
                fireBall.GetComponent<pProjectileBehavior>().left = false;
                fireBall.GetComponent<pProjectileBehavior>().right = false;
                fireBall.GetComponent<pProjectileBehavior>().down = false;
            }
            else if (left == true)
            {
                destination.x -= 1.1f;
                fireBall.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);

                fireBall.GetComponent<pProjectileBehavior>().up = false;
                fireBall.GetComponent<pProjectileBehavior>().left = true;
                fireBall.GetComponent<pProjectileBehavior>().right = false;
                fireBall.GetComponent<pProjectileBehavior>().down = false;
            }
            else if (right == true)
            {
                destination.x += 1.1f;
                fireBall.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);

                fireBall.GetComponent<pProjectileBehavior>().up = false;
                fireBall.GetComponent<pProjectileBehavior>().left = false;
                fireBall.GetComponent<pProjectileBehavior>().right = true;
                fireBall.GetComponent<pProjectileBehavior>().down = false;
            }
            else
            {
                destination.z -= 1;

                fireBall.GetComponent<pProjectileBehavior>().up = false;
                fireBall.GetComponent<pProjectileBehavior>().left = false;
                fireBall.GetComponent<pProjectileBehavior>().right = false;
                fireBall.GetComponent<pProjectileBehavior>().down = true;
            }

            //Return values to fireBall
            fireBall.transform.position = destination;

            lRA = false;
        }

    }
}
