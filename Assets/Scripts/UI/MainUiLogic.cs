using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUiLogic : MonoBehaviour
{
    [SerializeField] MagicBarsLogic _manaBars;

    public void Init()
    {
        _manaBars.Activate();
    }
}
