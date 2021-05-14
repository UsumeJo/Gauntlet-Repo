using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    //Shared variables
    public int enemyHp = 2;
    public GameObject playerPos;
    public int randChance;
    public int randItem;
    public GameObject enemyType;

    //Spawners
    public GameObject ghostObj;
    public GameObject gruntObj;
    public GameObject demonObj;
    public GameObject lobberObj;
    public GameObject sorcererObj;

    //Enemy movement
    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 5;

    private void Start()
    {
        
    }

    public void Movement()
    {
        transform.LookAt(playerPos.transform.position); //Looks at players current position

        //moves enemy towards player
        if (Vector3.Distance(transform.position, playerPos.transform.position) >= minDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        //stops a chosen distance away from the player
        if (Vector3.Distance(transform.position, playerPos.transform.position) <= maxDist)
        {
            //Here Call any function U want Like Shoot at here or something
            EnemyAttack(enemyType);
        }
        
    }

    public void EnemyAttack(GameObject enemy)
    {
        
    }
}
