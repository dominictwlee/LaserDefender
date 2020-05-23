using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour, IPoolable
{
    Rigidbody2D myRigidBody2D;

    [SerializeField]
    FloatReference speed = null;

    [SerializeField]
    private float lifetime = 10f;

    private float timer;

    public event Action OnDestroyEvent = delegate {};

    void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnDisable() { OnDestroyEvent(); }
    private void OnEnable()
    {
        Reset();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
            SelfDestruct();
    }

    protected void SelfDestruct()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Reset()
    {
        timer = 0f;
        myRigidBody2D.velocity = Vector3.zero;
    }

    public void Move()
    {
        myRigidBody2D.velocity = new Vector2(0, speed);
    }
}
