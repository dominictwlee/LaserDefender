using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float Variable", menuName = "ScriptableObjects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField]
    private float _value;
    public float Value
    {
        get => _value;
        set => _value = value;
    }

    public void ApplyChange(float amount)
    {
        _value += amount;
    }
}
