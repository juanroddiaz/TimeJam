using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUiLogic : MonoBehaviour
{
    [SerializeField] MagicBarsLogic _manaBars;
    [SerializeField] HealthBarLogic _playerHealthBar;

    public HealthBarLogic PlayerHealthBar => _playerHealthBar;

    public void Init()
    {
        _manaBars.Activate();
    }
}
