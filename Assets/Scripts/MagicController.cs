using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour, IInputListener
{
    [SerializeField] private float _defaultMagicDuration = 2.0f;

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
    }

    public void Subscribe()
    {
        InputController.Instance.SlowButtonDown += OnSlowMagic;
        InputController.Instance.FastButtonDown += OnFastMagic;
    }

    private void OnSlowMagic(bool buttonIsDown)
    {
        if (buttonIsDown)
        {
            TimeController.Instance.TriggerSlowMotion();
        } else
        {
            TimeController.Instance.TriggerNormalMotion();
        }
    }

    private void OnFastMagic(bool buttonIsDown)
    {
        if (buttonIsDown)
        {
            TimeController.Instance.TriggerFastMotion();
        }
        else
        {
            TimeController.Instance.TriggerNormalMotion();
        }
    }
}
