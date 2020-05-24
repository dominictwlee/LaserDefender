using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    FloatReference startingHealth = null;

    float health = 0;

    [SerializeField]
    GameObject explosionVFX;

    [SerializeField]
    AudioCue deathSFX;

    [SerializeField]
    FloatVariable score = null;

    private bool hasExploded = false;
    private bool hasDied = false;

    void Awake()
    {
        health = startingHealth.Value;
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

            IncrementScore();

            hasDied = true;
        }
    }

    private void DealDamage(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.DamagePoints;
        damageDealer.OnHit();
    }

    private void IncrementScore() {
        if (score != null)
        {
            score.ApplyChange(50);
        }
    }
}
