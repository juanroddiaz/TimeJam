using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _rotationSpeed = 1.0f;
    [SerializeField] private Rigidbody _body = default;

    private Transform _target = default;
    private Transform _transform = default;
    private bool _autoRotates = false;
    private bool _useRigidbody = false;
    private Timeline _timeline = default;
    private Vector3 _moveTo = Vector3.zero;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _timeline = GetComponent<Timeline>();
    }

    public void Init(bool autoRotation)
    {
        _autoRotates = autoRotation;
        _useRigidbody = _body != null;
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
        
        if(_useRigidbody)
        { 
            return; 
        }

        if(_moveTo == Vector3.zero)
        {
            return;
        }

        _transform.Translate(_moveTo * _moveSpeed * _timeline.deltaTime);
        _moveTo = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (_useRigidbody)
        {
            var pos = _body.position + _moveTo * _moveSpeed * _timeline.fixedDeltaTime;
            _body.MovePosition(pos);
            _moveTo = Vector3.zero;
        }
    }

    public void Move(Vector3 movement)
    {
        _moveTo = movement;
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
