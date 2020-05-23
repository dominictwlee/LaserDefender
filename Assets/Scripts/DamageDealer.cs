using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    FloatReference damagePoints = null;
    public float DamagePoints
    {
        get => damagePoints;
    }

    public void OnHit()
    {
        gameObject.SetActive(false);
    }
}
