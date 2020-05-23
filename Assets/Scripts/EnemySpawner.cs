using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<WaveConfig> waveConfigs = null;

    private int currentWaveIndex = 0;
    private float timeBetweenWaves = 5f;
    private float waveCooldown = 2f;

    void Update()
    {
        if (waveCooldown <= 0)
        {
            StartCoroutine(SpawnWave(waveConfigs[currentWaveIndex]));
            waveCooldown = timeBetweenWaves;
            currentWaveIndex = (currentWaveIndex + 1) % waveConfigs.Count;
        }

        waveCooldown -= Time.deltaTime;
    }

    IEnumerator SpawnWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.EnemyCount; i++)
        {
            var newEnemy = SpawnEnemy(waveConfig);
            newEnemy.GetComponent<EnemyPath>().WaveConfig = waveConfig;
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }

    GameObject SpawnEnemy(WaveConfig waveConfig)
    {
        var waypoints = waveConfig.GetWaypoints();
        return Instantiate(waveConfig.EnemyPrefab, waypoints[0].position, waypoints[0].rotation);
    }
}
