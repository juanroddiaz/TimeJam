using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    private EntityMovement _movement;
    private Vector3 _dir;
    private Timeline _timeline;

    public void Init(Vector3 dir, string timelineKey)
    {
        _dir = dir;
        _timeline.globalClockKey = timelineKey;
    }

    // Start is called before the first frame update
    void Awake()
    {
        _movement = GetComponent<EntityMovement>();
        _timeline = GetComponent<Timeline>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement.Move(_dir);
    }
}
