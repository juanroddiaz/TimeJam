using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityProjectile : MonoBehaviour
{
    private bool _projectileReady;
    private Timeline _timeline;
    public float reloadTime = 1f;
    public GameObject projectilePrefab;

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
            ProjectileLogic projectileLogic = projectile.GetComponent<ProjectileLogic>();
            projectileLogic.Init(gameObject.transform.forward.normalized, _timeline.globalClockKey);
            // then reload
            _projectileReady = false;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime / _timeline.timeScale);
        _projectileReady = true;
    }
}
