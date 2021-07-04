using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    private EntityMovement _movement;
    private Vector3 _dir;
    private Timeline _timeline;
    private CollisionEventLogic _collisionLogic;

    public void Init(Vector3 dir, string timelineKey)
    {
        _dir = dir;
        _timeline.globalClockKey = timelineKey;
    }

    private void Start()
    {
        _collisionLogic.Initialize(new CollisionEventData
        {
            CollisionEnterAction = OnColliderHit,
            CollisionExitAction = null
        });
    }
    void Awake()
    {
        _movement = GetComponent<EntityMovement>();
        _timeline = GetComponent<Timeline>();
        _collisionLogic = GetComponent<CollisionEventLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement.Move(_dir);
    }

    private void OnColliderHit(Transform hit)
    {
        if(hit.gameObject.tag != "Projectile") Destroy(gameObject);
    }
}
