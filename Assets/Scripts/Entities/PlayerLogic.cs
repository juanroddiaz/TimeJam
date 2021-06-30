using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, IInputListener
{
    private EntityMovement _movement = default;

    public void Subscribe()
    {

    }

    void Awake()
    {
        _movement = GetComponent<EntityMovement>();
    }

    void Start()
    {
        _movement.Init(false);
    }
}
