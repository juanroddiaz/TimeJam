using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEventData
{
    public Action<Transform> CollisionEnterAction;
    public Action<Transform> CollisionExitAction;
}

public class CollisionEventLogic : MonoBehaviour
{
    private CollisionEventData _data;
    private bool _initialized = false;

    public void Initialize(CollisionEventData data)
    {
        _data = data;
        _initialized = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("On collision enter: other " + collision.gameObject.name + ", collider: " + gameObject.name);
        if (_initialized)
        {
            _data.CollisionEnterAction?.Invoke(collision.transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        //Debug.Log("On collision exit: other " + collision.gameObject.name + ", collider: " + gameObject.name);
        if (_initialized)
        {
            _data.CollisionExitAction?.Invoke(collision.transform);
        }
    }
}