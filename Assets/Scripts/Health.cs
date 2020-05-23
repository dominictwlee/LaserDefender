using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float startingHealth = 100;

    [SerializeField]
    GameObject explosionVFX;

    [SerializeField]
    AudioCue deathSFX;

    private float health;
    private bool hasExploded = false;
    private bool hasDied = false;

    void Awake()
    {
        health = startingHealth;
    }

    void Update()
    {
        OnDie();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DealDamage(other);
    }

    private void OnDie()
    {
        if (hasDied)
        {
            return;
        }

        if (health <= 0)
        {
            if (!hasExploded)
            {
                Instantiate(explosionVFX, transform.position, transform.rotation);
                deathSFX.PlayClipAtCameraMain();
                hasExploded = true;
            }


            if (gameObject.CompareTag("EnemyLeader"))
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            } else
            {
                Destroy(gameObject);
            }
        }
    }

    private void DealDamage(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.DamagePoints;
        damageDealer.OnHit();
    }
}
