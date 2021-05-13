using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool trackPlayer;

    public void Start()
    {
           
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            trackPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            trackPlayer = false;
        }
    }
}
