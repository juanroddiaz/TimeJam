using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance { get; private set; }

    public Action<Direction> DirPushed;
    public Action<bool> SlowButtonDown;
    public Action<bool> FastButtonDown;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // up
        if(Input.GetKey(KeyCode.UpArrow))
        {
            DirPushed?.Invoke(Direction.Up);
        }
        // down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            DirPushed?.Invoke(Direction.Down);
        }
        // left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            DirPushed?.Invoke(Direction.Left);
        }
        // right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            DirPushed?.Invoke(Direction.Right);
        }
        // Q, Slow magic
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SlowButtonDown?.Invoke(true);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            SlowButtonDown?.Invoke(false);
        }
        // E, Fast magic
        if (Input.GetKeyDown(KeyCode.E))
        {
            FastButtonDown?.Invoke(true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            FastButtonDown?.Invoke(false);
        }
    }
}
