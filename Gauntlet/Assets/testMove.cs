using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testMove : MonoBehaviour
{
    public float playerSpeedLR = .1f;

    public int playerSpeedDU = 10;

    private void Update()
    {
        transform.position += new Vector3(Input.GetAxis("cHorizontal") * playerSpeedLR, 0, Input.GetAxis("cVertical") * playerSpeedDU * Time.deltaTime);
    }
}
