using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _rotationSpeed = 1.0f;

    private Transform _target = default;
    private Transform _transform = default;
    private bool _autoRotates = false;
    private Timeline _timeline = default;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _timeline = GetComponent<Timeline>();
    }

    public void Init(bool autoRotation)
    {
        _autoRotates = autoRotation;
    }

    public void SetTarget(Transform t)
    {
        _target = t;
    }

    private void Update()
    {
        if(_autoRotates)
        {
            UpdateOrientation();
        }
    }

    public void Move(Vector3 movement)
    {
        _transform.Translate(_transform.position + movement * _moveSpeed * _timeline.deltaTime);
    }

    private void UpdateOrientation()
    {
        Quaternion lookRotation = Quaternion.identity;
        bool hasTarget = _target != null;
        if (hasTarget)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(direction);
        }
        else
        {
            lookRotation = Quaternion.LookRotation(_transform.forward.normalized);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                lookRotation, _rotationSpeed * _timeline.deltaTime);
    }
}
