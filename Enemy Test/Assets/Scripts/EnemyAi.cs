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
            Movement();
        }
    }
}
