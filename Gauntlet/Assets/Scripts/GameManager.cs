using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //The GameManager needs the GameObjects it controls.
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public bool nuke;

    private void Start()
    {
        nuke = false;
    }

    private void FixedUpdate()
    {
        nuketime();
    }

    private void nuketime()
    {
        if (nuke == true)
        {
            killEnemies();
            nuke = false;
        }
    }

    private void killEnemies()
    {
        //Group all enemies
        GameObject[] dos = GameObject.FindGameObjectsWithTag("death");
        GameObject[] gos = GameObject.FindGameObjectsWithTag("ghost");
        GameObject[] sos = GameObject.FindGameObjectsWithTag("sorcerer");
        GameObject[] des = GameObject.FindGameObjectsWithTag("demon");
        GameObject[] grs = GameObject.FindGameObjectsWithTag("grunt");
        GameObject[] los = GameObject.FindGameObjectsWithTag("lobber");
        GameObject[] tos = GameObject.FindGameObjectsWithTag("thief");

        //Nuke all enemies
        foreach (GameObject pTemp in dos)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in sos)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in des)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in grs)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in los)
        {
            Destroy(pTemp);
        }
        foreach (GameObject pTemp in tos)
        {
            Destroy(pTemp);
        }
    }
}
