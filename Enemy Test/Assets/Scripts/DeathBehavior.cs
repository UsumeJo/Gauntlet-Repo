using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehavior : MonoBehaviour
{
    public GameObject playerPos;
    public PlayerDetection playerDetect;
    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerDetect = gameObject.GetComponent<PlayerDetection>();
        if (playerDetect.trackPlayer == true)
        {
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
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        //Insert Death damage 
    }
}
