using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player1" || other.tag == "player2" || other.tag == "player3" || other.tag == "player4")
        {
            Destroy(this.gameObject);

        }
    }
}
