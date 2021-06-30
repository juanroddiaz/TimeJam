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
    [SerializeField]
    private string _normalClockName = "Normal";
    [Header("slow, fast, normal")]
    [SerializeField]
    private Vector3 _slowSpeeds = Vector3.one;
    [SerializeField]
    private Vector3 _fastSpeeds = Vector3.one;
    [SerializeField]
    private Vector3 _normalSpeeds = Vector3.one;

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
    private Clock _normalClock;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _normalClock = Timekeeper.instance.Clock(_normalClockName);
        _slowClock = Timekeeper.instance.Clock(_slowClockName);
        _fastClock = Timekeeper.instance.Clock(_fastClockName);
        TriggerNormalMotion();
    }

    public void TriggerSlowMotion()
    {
        _slowClock.localTimeScale = _slowSpeeds.x;
        _fastClock.localTimeScale = _slowSpeeds.y;
        _normalClock.localTimeScale = _slowSpeeds.z;
    }

    public void TriggerFastMotion()
    {
        _slowClock.localTimeScale = _fastSpeeds.x;
        _fastClock.localTimeScale = _fastSpeeds.y;
        _normalClock.localTimeScale = _fastSpeeds.z;
    }

    public void TriggerNormalMotion()
    {
        _slowClock.localTimeScale = _normalSpeeds.x;
        _fastClock.localTimeScale = _normalSpeeds.y;
        _normalClock.localTimeScale = _normalSpeeds.z;
    }
}
