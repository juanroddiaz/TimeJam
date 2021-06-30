using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private EntityMovement _movement = default;

    void Awake()
    {
        _movement = GetComponent<EntityMovement>();
    }

    void Start()
    {
        _movement.Init(true);
        _movement.SetTarget(ScenarioController.Instance.Player.transform);
    }
}
