using System.Collections;
using System.Collections.Generic;
using Chronos;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private string _slowClockName = "Slow";
    [SerializeField]
    private string _fastClockName = "Fast";

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
    private Clock _slowClock;
    private Clock _fastClock;

    public Clock SlowClock => _slowClock;
    public Clock FastClock => _fastClock;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _slowClock = Timekeeper.instance.Clock(_slowClockName);
        _fastClock = Timekeeper.instance.Clock(_fastClockName);
    }

    public void TriggerSlowMotion()
    {        
    }

    public void TriggerFastMotion()
    {
    }

    public void TriggerNormalMotion()
    {
    }

}
