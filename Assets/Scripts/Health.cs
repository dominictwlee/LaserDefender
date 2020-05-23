using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    float startingHealth = 100;

    [SerializeField]
    GameObject explosionVFX;

    [SerializeField]
    AudioCue deathSFX;

    [SerializeField]
    FloatVariable score = null;

    GameObject level;

    private float health;
    private bool hasExploded = false;
    private bool hasDied = false;

    void Awake()
    {
        health = startingHealth;
        level = GameObject.FindGameObjectWithTag("Level");
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

            if (gameObject.CompareTag("EnemyLeader") || gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            } else
            {
                Destroy(gameObject);
            }

            if (!gameObject.CompareTag("Player"))
            {
                IncrementScore();
            } else
            {
                StartCoroutine(LoadGameOver());
            }

            hasDied = true;
        }
    }

    private void DealDamage(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.DamagePoints;
        damageDealer.OnHit();
    }

    private IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3);
        level.GetComponent<Level>().LoadGameOver();
    }



    private void IncrementScore() {
        if (score != null)
        {
            score.ApplyChange(50);
        }
    }
}
