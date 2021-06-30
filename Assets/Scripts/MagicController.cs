using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour, IInputListener
{
    private static MagicController _instance;
    public static MagicController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MagicController>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Subscribe()
    {
        
    }
}
