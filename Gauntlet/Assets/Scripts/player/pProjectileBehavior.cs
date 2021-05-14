using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pProjectileBehavior : MonoBehaviour
{
    //Variable for direction
    public bool up;
    public bool left;
    public bool right;
    public bool down;

    public int pLD;
    public int pLS;

    public int player;
    public int choice;

    private Vector3 spawn;
    private GameObject playerParent;

    private void Awake()
    {
        spawn = this.transform.position;
    }

    private void Start()
    {
        if (player == 1)
        {
            playerParent = GameObject.Find("Player1");
        }
        else if (player == 2)
        {
            playerParent = GameObject.Find("Player2");
        }
        else if (player == 3)
        {
            playerParent = GameObject.Find("Player3");
        }
        else if (player == 4)
        {
            playerParent = GameObject.Find("Player4");
        }
    }
    private void FixedUpdate()
    {
        
        arrowMovement();
    }

    private void arrowMovement()
    {
        Vector3 destination = this.transform.position;

        if (up == true)
        {
            destination.z += 0.05f * pLS;
        }
        else if (left == true)
        {
            destination.x -= 0.05f * pLS;
        }
        else if (right == true)
        {
            destination.x += 0.05f * pLS;
        }
        else if (down == true)
        {
            destination.z -= 0.05f * pLS;
        }

        this.transform.position = destination;

        if (destination.x > spawn.x + 25 || destination.x < spawn.x - 25 || destination.z < spawn.z - 25 || destination.z > 25 + spawn.z)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "sorcerer" || other.tag == "ghost" || other.tag == "spawner")
        {
            Destroy(this.gameObject);
            
        }
    }

    private void OnDestroy()
    {
        if (choice == 1)
        {
            playerParent.GetComponent<warriorScript>().lRS = false;
        }
        else if (choice == 2)
        {
            playerParent.GetComponent<valkScript>().lRS = false;
        }
        else if (choice == 3)
        {
            playerParent.GetComponent<wizardScript>().lRS = false;
        }
        else if (choice == 4)
        {
            playerParent.GetComponent<elfScript>().lRS = false;
        }
        
    }
}
