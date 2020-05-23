using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    FloatRange attackFrequency = null;

    float cooldown;

    ProjectileLauncher projectileLauncher;

    void Awake()
    {
        cooldown = Random.Range(attackFrequency.Min, attackFrequency.Max);
        projectileLauncher = GetComponent<ProjectileLauncher>();
    }

    void Update()
    {
        if (cooldown <= 0)
        {
            projectileLauncher.Fire((Vector2)transform.position - (new Vector2(0, 0.6f)));
            cooldown = Random.Range(attackFrequency.Min, attackFrequency.Max);
        }

        cooldown -= Time.deltaTime;
    }
}
