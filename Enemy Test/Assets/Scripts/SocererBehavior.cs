using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocererBehavior : MonoBehaviour
{
    public GameObject playerPos;

    //Enemy movement
    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 5;

    public PlayerDetection playerDetect;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        playerDetect = gameObject.GetComponent<PlayerDetection>();
        if (playerDetect.trackPlayer == true)
        {
            //calls movement 
            Movement();
        }
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
            EnemyAttack();
        }

    }

    public void EnemyAttack()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        //Insert Damage here

    }
}
