using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBarsLogic : MonoBehaviour
{
    [SerializeField] Slider _slowManaSlider = default;
    [SerializeField] Slider _fastManaSlider = default;
    private bool _isActive = false;

    public void Activate()
    {
        _isActive = true;
        _slowManaSlider.maxValue = MagicController.Instance.CurrentSlowMagic.Limit;
        _fastManaSlider.maxValue = MagicController.Instance.CurrentFastMagic.Limit;
    }

    private void Update()
    {
        if(_isActive)
        {
            _slowManaSlider.value = MagicController.Instance.CurrentSlowMagic.Current;
            _fastManaSlider.value = MagicController.Instance.CurrentFastMagic.Current;
        }
    }
}
