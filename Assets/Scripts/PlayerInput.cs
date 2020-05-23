using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private CharacterMovement characterMovement;
    private ProjectileLauncher projectileLauncher;
    [SerializeField]
    FloatReference delay = null;
    float cooldown = 0;

    void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        projectileLauncher = GetComponent<ProjectileLauncher>();

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleFireProjectile();
    }

    private void HandleMovementInput()
    {
        var velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        characterMovement.Move(velocity);
    }

    private void HandleFireProjectile()
    {
        if (Input.GetButton("Fire1"))
        {
            if (delay == 0)
            {
                projectileLauncher.Fire((Vector2)transform.position + (new Vector2(0, 0.6f)));
            } else
            {
                ThrottleFire();
            }
        }
    }

    private void ThrottleFire()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        {
            while (cooldown <= 0)
            {
                cooldown += delay;
                projectileLauncher.Fire((Vector2)transform.position + (new Vector2(0, 0.6f)));
            }
        }
    }
}
