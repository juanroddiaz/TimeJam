using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhLogic : MonoBehaviour
{
    [SerializeField] private int _initialHp = 5;

    private int _currentHp = 0;
    private int _maxHp = 0;
    private bool _isAlive = false;
    private Action _onHit = default;
    private Action _onDeath = default;
    private HealthBarLogic _bar = default;

    public void Init(Action onHit, Action onDeath, HealthBarLogic bar = null)
    {
        _currentHp = _initialHp;
        _maxHp = _initialHp;
        _isAlive = true;
        _onHit = onHit;
        _onDeath = onDeath;
        if(bar != null)
        {
            _bar = bar;
            _bar.Init(_maxHp);
        }
    }

    public void OnHit(int damage = 1)
    {
        if(!_isAlive)
        {
            return;
        }

        _currentHp--;
        OnHit();
        if (_currentHp <= 0)
        {
            OnDeath();
        }
    }

    private void OnHit()
    {
        _onHit?.Invoke();
        if(_bar != null)
        {
            _bar.Refresh(_currentHp, _maxHp);
        }
    }

    private void OnDeath()
    {
        _isAlive = false;
        _onDeath?.Invoke();
    }
}
