using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private Laser prefab = null;

    [SerializeField]
    FloatReference projectileSpeed = null;

    [SerializeField]
    int poolSize = 0;

    private Pool pool;

    public void Awake()
    {
        pool = Pool.GetPool(prefab, poolSize);
    }

    public void Fire(Vector2 startPosition)
    {
        var laser = pool.Get(startPosition, Quaternion.identity) as Laser;

        if (laser == null)
        {
            return;
        }

        laser.Move();
    }
}
