using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] 
    FloatReference movementSpeed = null;
    [SerializeField]
    float paddingX = 0;
    [SerializeField]
    float paddingY = 0;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    void Start()
    {
        SetupMoveBoundaries();
    }

    void SetupMoveBoundaries()
    {
        var gameCamera = Camera.main;
        var min = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        xMin = min.x + paddingX;
        yMin = min.y + paddingY;
        xMax = Math.Abs(xMin);
        yMax = Math.Abs(yMin);
    }

    public void Move(Vector2 velocity)
    {
        var delta = velocity * Time.deltaTime * movementSpeed.Value;
        var newPosition = (Vector2)transform.position + delta;
        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);
        transform.position = newPosition;
    }
}
