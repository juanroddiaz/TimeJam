using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityProjectile : MonoBehaviour
{
    private bool _projectileReady;
    private Timeline _timeline;
    public GameObject projectilePrefab;
    [SerializeField]
    private float _reloadTime = 1f;
    private float _fireCooldown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _timeline = GetComponent<Timeline>();
        _projectileReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_projectileReady)
        {
            // shoot projectile
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = gameObject.transform.position;
            ProjectileLogic projectileLogic = projectile.GetComponent<ProjectileLogic>();
            projectileLogic.Init(gameObject.transform.forward.normalized, _timeline.globalClockKey);
            // then reload
            _projectileReady = false;
        }
        if (_fireCooldown < _reloadTime)
        {
            _fireCooldown += _timeline.deltaTime;
            if (_fireCooldown >= _reloadTime)
            {
                _projectileReady = true;
                _fireCooldown = 0.0f;
            }
        }
    }
}
