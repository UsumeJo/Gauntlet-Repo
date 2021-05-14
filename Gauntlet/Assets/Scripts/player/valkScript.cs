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

        cChoice = 2;

        //Functions to set
        valkStats();
        setControls();

        swordPrefab = gameManager.GetComponent<GameManager>().arrowPrefab;
    }

    private void FixedUpdate()
    {
        itPot--;
        pMovement();
        pAttackCheck();
        attackValk();
        hpDrain();
        nukeCheck();
        deathCheck();
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

                sword.GetComponent<pProjectileBehavior>().up = true;
                sword.GetComponent<pProjectileBehavior>().left = false;
                sword.GetComponent<pProjectileBehavior>().right = false;
                sword.GetComponent<pProjectileBehavior>().down = false;
            }
            else if (left == true)
            {
                destination.x -= 1.1f;
                sword.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);

                sword.GetComponent<pProjectileBehavior>().up = false;
                sword.GetComponent<pProjectileBehavior>().left = true;
                sword.GetComponent<pProjectileBehavior>().right = false;
                sword.GetComponent<pProjectileBehavior>().down = false;
            }
            else if (right == true)
            {
                destination.x += 1.1f;
                sword.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);

                sword.GetComponent<pProjectileBehavior>().up = false;
                sword.GetComponent<pProjectileBehavior>().left = false;
                sword.GetComponent<pProjectileBehavior>().right = true;
                sword.GetComponent<pProjectileBehavior>().down = false;
            }
            else
            {
                destination.z -= 1;

                sword.GetComponent<pProjectileBehavior>().up = false;
                sword.GetComponent<pProjectileBehavior>().left = false;
                sword.GetComponent<pProjectileBehavior>().right = false;
                sword.GetComponent<pProjectileBehavior>().down = true;
            }

            //Return values to arrow
            sword.transform.position = destination;
            sword.GetComponent<pProjectileBehavior>().pLS = pLS;
            sword.GetComponent<pProjectileBehavior>().pLD = pLD;

            lRA = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (itPot <= 0)
        {
            if (other.tag == "nuPotion")
            {
                potions++;
            }
            if (other.tag == "lootB")
            {
                score += 50;
                lootB++;
            }
            if (other.tag == "treasure")
            {
                score += 100;
            }
            if (other.tag == "key")
            {
                key++;
                score += 100;
            }
            if (other.tag == "food")
            {
                hp += 100;
            }
            if (other.tag == "heart")
            {
                hp += 50;
                heart++;
            }
            if (other.tag == "lock")
            {
                key--;
            }
            itPot = 5;
        }

        if (other.tag == "death")
        {
            hp--;
        }
    }
}
