using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float Range", menuName = "ScriptableObjects/FloatRange")]
public class FloatRange : ScriptableObject
{
    [SerializeField]
    FloatReference min = null;
    public float Min
    {
        get => min.Value;
    }

    [SerializeField]
    FloatReference max = null;
    public float Max
    {
        get => max.Value;
    }
}
