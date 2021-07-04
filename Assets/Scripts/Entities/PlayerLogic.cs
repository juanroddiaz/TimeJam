using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, IInputListener
{
    private EntityMovement _movement = default;
    private CollisionEventLogic _collisionLogic = default;
    private HealhLogic _healthLogic = default;

    public void Subscribe()
    {
        InputController.Instance.DirPushed += OnDirPushed;
    }

    private void OnDirPushed(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                _movement.Move(Vector3.forward);
                break;
            case Direction.Down:
                _movement.Move(Vector3.back);
                break;
            case Direction.Left:
                _movement.Move(Vector3.left);
                break;
            case Direction.Right:
                _movement.Move(Vector3.right);
                break;
        }
    }

    void Awake()
    {
        Subscribe();
        _movement = GetComponent<EntityMovement>();
        _collisionLogic = GetComponent<CollisionEventLogic>();
        _healthLogic = GetComponent<HealhLogic>();
    }

    void Start()
    {
        _movement.Init(false);
        _healthLogic.Init(OnHit, OnDeath, ScenarioController.Instance.UI.PlayerHealthBar);
        _collisionLogic.Initialize(new CollisionEventData
        {
            CollisionEnterAction = OnColliderHit,
            CollisionExitAction = null
        });
    }

    void OnHit()
    {

    }

    void OnDeath()
    {

    }

    void OnColliderHit(Transform t)
    {
        //Debug.Log("Player Hit by " + t.name);
        if (t.CompareTag("Projectile"))
        {
            _healthLogic.OnHit();
        }
    }
}
