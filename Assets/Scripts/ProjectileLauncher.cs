using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    Laser prefab = null;

    [SerializeField]
    AudioCue audioCue;
    

    [SerializeField]
    FloatReference projectileSpeed = null;

    [SerializeField]
    int poolSize = 0;

    Pool pool;

    AudioSource audioSource = null;

    public void Awake()
    {
        pool = Pool.GetPool(prefab, poolSize);
        audioSource = GetComponent<AudioSource>();
    }

    public void Fire(Vector2 startPosition)
    {
        var laser = pool.Get(startPosition, Quaternion.identity) as Laser;

        if (laser == null)
        {
            return;
        }

        laser.Move();

        if (audioCue != null)
        {
            audioCue.Play(audioSource);
        }
    }
}
