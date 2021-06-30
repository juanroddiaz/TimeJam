using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Transform _transform = default;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void Move(Vector3 movement)
    {
        _transform.Translate(_transform.position + movement * _speed);
    }
}
