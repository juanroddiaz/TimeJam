using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private static TimeController _instance;
    public static TimeController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TimeController>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
