﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    FloatReference startingHealth = null;

    [SerializeField]
    FloatVariable health = null;

    [SerializeField]
    GameObject explosionVFX;

    [SerializeField]
    AudioCue deathSFX;

    GameObject level;

    private bool hasExploded = false;
    private bool hasDied = false;

    void Awake()
    {
        health.Value = startingHealth.Value;
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

        if (health.Value <= 0)
        {
            if (!hasExploded)
            {
                Instantiate(explosionVFX, transform.position, transform.rotation);
                deathSFX.PlayClipAtCameraMain();
                hasExploded = true;
            }

            gameObject.GetComponent<Renderer>().enabled = false;

            StartCoroutine(LoadGameOver());

            hasDied = true;
        }
    }

    private void DealDamage(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health.Value -= damageDealer.DamagePoints;
        damageDealer.OnHit();
    }

    private IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3);
        level.GetComponent<Level>().LoadGameOver();
    }
}
