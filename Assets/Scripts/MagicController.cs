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

    void Awake()
    {
        Subscribe();
        DontDestroyOnLoad(gameObject);
    }

    public void Subscribe()
    {
        InputController.Instance.SlowButtonPushed += OnSlowMagic;
        InputController.Instance.FastButtonPushed += OnFastMagic;
    }

    private void OnSlowMagic()
    {
        TimeController.Instance.TriggerSlowMotion();
        StartCoroutine(OnMagicRoutine());
    }

    private void OnFastMagic()
    {
        TimeController.Instance.TriggerSlowMotion();
        StartCoroutine(OnMagicRoutine());
    }

    private IEnumerator OnMagicRoutine()
    {
        yield return new WaitForSeconds(_defaultMagicDuration);
        TimeController.Instance.TriggerNormalMotion();
    }
}
