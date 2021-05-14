using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererManager : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject sorcererObj;

    public int visTime;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player");
        sorcererObj = GameObject.FindWithTag("sorcerer");
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(visTime);
            sorcererObj.GetComponent<Collider>().enabled = !sorcererObj.GetComponent<Collider>().enabled;
            sorcererObj.GetComponent<Renderer>().enabled = !sorcererObj.GetComponent<Collider>().enabled;
        }
    }
}
