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
        cChoice = 1;

        //Functions to set
        warStats();
        setControls();
        axePrefab = gameManager.GetComponent<GameManager>().arrowPrefab;
    }

    private void FixedUpdate()
    {
        itPot--;
        pMovement();
        pAttackCheck();
        attackElf();
        hpDrain();
        nukeCheck();
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

                axe.GetComponent<pProjectileBehavior>().up = true;
                axe.GetComponent<pProjectileBehavior>().left = false;
                axe.GetComponent<pProjectileBehavior>().right = false;
                axe.GetComponent<pProjectileBehavior>().down = false;
            }
            else if (left == true)
            {
                destination.x -= 1.1f;
                axe.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);

                axe.GetComponent<pProjectileBehavior>().up = false;
                axe.GetComponent<pProjectileBehavior>().left = true;
                axe.GetComponent<pProjectileBehavior>().right = false;
                axe.GetComponent<pProjectileBehavior>().down = false;
            }
            else if (right == true)
            {
                destination.x += 1.1f;
                axe.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);

                axe.GetComponent<pProjectileBehavior>().up = false;
                axe.GetComponent<pProjectileBehavior>().left = false;
                axe.GetComponent<pProjectileBehavior>().right = true;
                axe.GetComponent<pProjectileBehavior>().down = false;

            }
            else
            {
                destination.z -= 1;

                axe.GetComponent<pProjectileBehavior>().up = false;
                axe.GetComponent<pProjectileBehavior>().left = false;
                axe.GetComponent<pProjectileBehavior>().right = false;
                axe.GetComponent<pProjectileBehavior>().down = true;
            }

            //Return values to arrow
            axe.transform.position = destination;
            axe.GetComponent<pProjectileBehavior>().pLS = pLS;
            axe.GetComponent<pProjectileBehavior>().pLD = pLD;

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
