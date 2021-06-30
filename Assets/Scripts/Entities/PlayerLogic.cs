using Chronos;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, IInputListener
{
    private EntityMovement _movement = default;
    private Timeline _timeline = default;

    public void Subscribe()
    {

    }

    void Awake()
    {
        _movement = GetComponent<EntityMovement>();
        _timeline = GetComponent<Timeline>();
    }

    void Start()
    {
        _movement.Init(false);
    }
}
