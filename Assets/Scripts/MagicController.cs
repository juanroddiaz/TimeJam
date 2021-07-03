using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MagicData
{
    public int Limit;
    public float Current;
}

public enum MagicStatus
{
    Slow,
    Fast,
    Normal,
}

public class MagicController : MonoBehaviour, IInputListener
{
    [SerializeField] private float _defaultMagicSpeed = 2.0f;
    [SerializeField] private MagicData _slowMagicData = default;
    [SerializeField] private MagicData _fastMagicData = default;

    private MagicStatus _currentStatus = MagicStatus.Normal;
    private MagicData _currentSlowMagicData = default;
    private MagicData _currentFastMagicData = default;

    public MagicData CurrentSlowMagic => _currentSlowMagicData;
    public MagicData CurrentFastMagic => _currentFastMagicData;

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

    void Start()
    {
        Subscribe();
        DontDestroyOnLoad(gameObject);
        _currentSlowMagicData = _slowMagicData;
        _currentFastMagicData = _fastMagicData;
    }

    public void Subscribe()
    {
        InputController.Instance.SlowButtonDown += OnSlowMagic;
        InputController.Instance.FastButtonDown += OnFastMagic;
    }

    void Update()
    {
        switch(_currentStatus)
        {
            case MagicStatus.Normal:
            {
                break;
            }
            case MagicStatus.Slow:
            {
                var delta = Time.deltaTime * _defaultMagicSpeed;
                _currentSlowMagicData.Current -= delta;
                _currentSlowMagicData.Current = Mathf.Max(0.0f, _currentSlowMagicData.Current);
                Debug.Log("slow: " + _currentSlowMagicData.Current);
                if (_currentSlowMagicData.Current <= 0.0f)
                {
                    OnSlowMagic(false);
                    return;
                }
                _currentFastMagicData.Current += delta;
                _currentFastMagicData.Current = 
                    Mathf.Min(_currentFastMagicData.Limit, _currentFastMagicData.Current);
                break;
            }
            case MagicStatus.Fast:
            {
                var delta = Time.deltaTime * _defaultMagicSpeed;
                _currentFastMagicData.Current -= delta;
                _currentFastMagicData.Current = Mathf.Max(0.0f, _currentFastMagicData.Current);
                Debug.Log("fast: " + _currentFastMagicData.Current);
                if (_currentFastMagicData.Current <= 0.0f)
                {
                    OnFastMagic(false);
                    return;
                }
                _currentSlowMagicData.Current += delta;
                _currentSlowMagicData.Current = 
                        Mathf.Min(_currentSlowMagicData.Limit, _currentSlowMagicData.Current);

                break;
            }
        }            
    }

    private void OnSlowMagic(bool toggle)
    {
        if(_currentStatus != MagicStatus.Normal && toggle)
        {
            Debug.Log("Trying slow magic while not in normal state");
            return;
        }
        if (_currentStatus != MagicStatus.Slow && !toggle)
        {
            Debug.Log("Trying to return to normal with no slow magic");
            return;
        }

        if(toggle)
        {
            TimeController.Instance.TriggerSlowMotion();
            _currentStatus = MagicStatus.Slow;
            return;
        }

        TimeController.Instance.TriggerNormalMotion();
        _currentStatus = MagicStatus.Normal;
    }

    private void OnFastMagic(bool toggle)
    {
        if (_currentStatus != MagicStatus.Normal && toggle)
        {
            Debug.Log("Trying fast magic while not in normal state");
            return;
        }
        if (_currentStatus != MagicStatus.Fast && !toggle)
        {
            Debug.Log("Trying to return to normal with no fast magic");
            return;
        }

        if (toggle)
        {
            TimeController.Instance.TriggerFastMotion();
            _currentStatus = MagicStatus.Fast;
            return;
        }

        TimeController.Instance.TriggerNormalMotion();
        _currentStatus = MagicStatus.Normal;
    }
}
