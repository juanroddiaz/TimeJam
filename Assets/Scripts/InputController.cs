using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // up
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
        }
        // down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down");
        }
        // left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("left");
        }
        // right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("right");
        }
    }
}
