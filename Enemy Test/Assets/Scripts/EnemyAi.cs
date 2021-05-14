using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : EnemyParent
{
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
            //calls movement from enemy parent 
            enemyType = this.gameObject;
            Movement();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(gameObject.tag == "grunt" && col.gameObject.tag == "Player")
        {
            //Insert damage player
        }

        if (gameObject.tag == "ghost" && col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            //Insert damage player
        }
    }
}
