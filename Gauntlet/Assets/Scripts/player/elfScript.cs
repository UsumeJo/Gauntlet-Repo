using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elfScript : playerData
{
    //Weapon objects for players to use
    public GameObject arrowPrefab;
    public GameObject arrow;

    private void Awake()
    {
        pSE = false;
        cChoice = 4;

        //Functions to set
        elfStats();
        setControls();
        arrowPrefab = gameManager.GetComponent<GameManager>().arrowPrefab;
    }

    private void FixedUpdate()
    {
        itPot--;
        pMovement();
        pAttackCheck();
        attackElf();
        hpDrain();
        nukeCheck();
        deathCheck();
    }

    //A function to set elf stats
    private void elfStats()
    {
        pM = 6;
        pSD = 3;
        pLD = 1;
        pLS = 9;
        pD = 2;
        pMS = 6 * .1f;
    }

    //A function to set all 
    private void attackElf()
    {
        //Check if long range attack or short range attack is true
        if (lRA == true)
        {
            //When long range attack occurs instantiate arrow
            arrow = Instantiate(arrowPrefab) as GameObject;

            //Start it at player's position, dependant on which direction its being shot from
            arrow.transform.position = this.transform.position;

            Vector3 destination = arrow.transform.position;
            destination.y -= 2.6f;
            arrow.GetComponent<pProjectileBehavior>().player = cPlayer;
            arrow.GetComponent<pProjectileBehavior>().choice = cChoice;

            if (up == true)
            {
                destination.z += 1;
                arrow.GetComponent<pProjectileBehavior>().up = true;
                arrow.GetComponent<pProjectileBehavior>().left = false;
                arrow.GetComponent<pProjectileBehavior>().right = false;
                arrow.GetComponent<pProjectileBehavior>().down = false;
            }
            else if (left == true)
            {
                destination.x -= 1.1f;
                arrow.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);

                arrow.GetComponent<pProjectileBehavior>().up = false;
                arrow.GetComponent<pProjectileBehavior>().left = true;
                arrow.GetComponent<pProjectileBehavior>().right = false;
                arrow.GetComponent<pProjectileBehavior>().down = false;
            }
            else if (right == true)
            {
                destination.x += 1.1f;
                arrow.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 90);

                arrow.GetComponent<pProjectileBehavior>().up = false;
                arrow.GetComponent<pProjectileBehavior>().left = false;
                arrow.GetComponent<pProjectileBehavior>().right = true;
                arrow.GetComponent<pProjectileBehavior>().down = false;
            }
            else
            {
                destination.z -= 1;

                arrow.GetComponent<pProjectileBehavior>().up = false;
                arrow.GetComponent<pProjectileBehavior>().left = false;
                arrow.GetComponent<pProjectileBehavior>().right = false;
                arrow.GetComponent<pProjectileBehavior>().down = true;
            }

            //Return values to arrow
            arrow.transform.position = destination;
            arrow.GetComponent<pProjectileBehavior>().pLS = pLS;
            arrow.GetComponent<pProjectileBehavior>().pLD = pLD;

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
