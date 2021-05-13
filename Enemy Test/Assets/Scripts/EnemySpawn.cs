using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyObj;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyObj, new Vector3(transform.position.x + 5, transform.position.y, transform.position.z), Quaternion.identity); 
    }

}
