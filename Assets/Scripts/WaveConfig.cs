using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Config", menuName = "ScriptableObjects/WaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField]
    GameObject pathPrefab = null;

    [SerializeField]
    GameObject enemyPrefab = null;
    public GameObject EnemyPrefab {
        get => enemyPrefab; 
    }

    [SerializeField]
    FloatReference timeBetweenSpawns = null;
    public float TimeBetweenSpawns
    {
        get => timeBetweenSpawns.Value;
    }

    [SerializeField]
    FloatReference spawnRandomFactor = null;
    public float SpawnRandomFactor
    {
        get => spawnRandomFactor.Value;
    }

    [SerializeField]
    int enemyCount = 0;
    public int EnemyCount
    {
        get => enemyCount;
    }

    [SerializeField]
    FloatReference moveSpeed = null;
    public float MoveSpeed
    {
        get => moveSpeed.Value;
    }

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }
}
