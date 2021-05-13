using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        Vector3 temp;
        temp = transform.position;

        if (Input.GetKey("w"))
        {
            temp += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey("s"))
        {
            temp += Vector3.back * Time.deltaTime * speed;
        }
        //Player moves left when they press the A key
        if (Input.GetKey("a"))
        {
            temp += Vector3.left * Time.deltaTime * speed;
        }
        //Player moves right when they press the D key
        if (Input.GetKey("d"))
        {
            temp += Vector3.right * Time.deltaTime * speed;
        }
        transform.position = temp;
    }
}
