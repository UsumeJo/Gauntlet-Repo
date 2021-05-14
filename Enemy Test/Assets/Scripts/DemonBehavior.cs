using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBehavior : MonoBehaviour
{
    public GameObject playerPos;

    //Enemy movement
    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 5;
    public int bulletSpeedForward = 10;
    public int bulletDespawn;
    public int bulletSpawn;
    private int timeBetweenSpawns;

    public PlayerDetection playerDetect;

    private bool biteAttack;

    public GameObject projectileObj;
    public GameObject projectileSpawn;
    private GameObject bullet;

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
            timeBetweenSpawns++;
            //Here Call any function U want Like Shoot at here or something
            if (timeBetweenSpawns % 50 == 0)
            {
                if (biteAttack == false)
                {
                    EnemyAttack();
                }
            }

        }

        //Bite player if they get too close/stop shooting projectile
        if (Vector3.Distance(transform.position, playerPos.transform.position) <= 3)
        {
            biteAttack = true;
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        //If player is too far set biteAttack to false and return to shooting projectiles
        if(Vector3.Distance(transform.position, playerPos.transform.position) > 3)
        {
            biteAttack = false;
        }

    }

    public void EnemyAttack()
    {
        Projectile();
    }

    private void Projectile()
    {
        bullet = Instantiate(projectileObj, projectileSpawn.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeedForward);
        StartCoroutine(WaitAndDestroy(bullet));
    }

    IEnumerator WaitAndDestroy(GameObject bulletObj)
    {
        yield return new WaitForSeconds(5);
        Destroy(bulletObj);
    }

    private void OnCollisionEnter(Collision col)
    {
        
    }
}
