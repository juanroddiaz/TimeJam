using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
    [SerializeField] private PlayerLogic _player = default;
    [SerializeField] private MainUiLogic _ui = default;

    public PlayerLogic Player => _player;
    public MainUiLogic UI => _ui;

    private static ScenarioController _instance;
    public static ScenarioController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScenarioController>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _ui.Init();
    }
}
