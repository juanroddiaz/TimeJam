using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarLogic : MonoBehaviour
{
    [SerializeField] Slider _slider = default;

    public void Init(int max)
    {
        _slider.maxValue = max;
        _slider.value = max;
    }

    public void Refresh(int current, int max)
    {
        _slider.maxValue = max;
        _slider.value = current;
    }
}
