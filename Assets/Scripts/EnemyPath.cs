using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    WaveConfig waveConfig;
    public WaveConfig WaveConfig
    {
        set => waveConfig = value;
    }

    int currentPointIndex = 0;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waveConfig == null)
        {
            return;
        }

        var waypoints = waveConfig.GetWaypoints();

        if (currentPointIndex <= waypoints.Count - 1)
        {
            var targetWaypoint = waypoints[currentPointIndex].transform.position;

            transform.position = Vector2.MoveTowards(
                transform.position,
                targetWaypoint,
                waveConfig.MoveSpeed * Time.deltaTime);

            if (transform.position == targetWaypoint)
            {
                currentPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
