using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    public float spawnCycleTime;
    public float spawnDistance;
    public int spawnCount;

    [Header ("Data")]
    public List<Enemy> enemyList = new();

    private float spawnTimer;

    public void Start()
    {

    }

    public void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            spawnTimer = spawnCycleTime;
            CreateEnemiesAroundPoint(spawnCount, transform.position, spawnDistance);
        }
    }

    private int GetRandomEnemyIndex()
    {
        float rand = Random.Range(0f, 1f);
        float cumulative = 0f;

        for (int i = 0; i < enemyList.Count; i++)
        {
            cumulative += enemyList[i].probability;
            if (rand < cumulative)
            {
                return i;
            }
        }
        return enemyList.Count - 1; // In case of rounding errors
    }

    public void CreateEnemiesAroundPoint(int num, Vector3 point, float radius)
    {
        float randomOffset = Random.Range(0f, 2 * MathF.PI); // Random offset for the radians

        for (int i = 0; i < num; i++)
        {
            /* Distance around the circle with a random offset */
            var radians = 2 * MathF.PI / num * i + randomOffset;

            /* Get the vector direction */
            var vertical = MathF.Sin(radians);
            var horizontal = MathF.Cos(radians);

            var spawnDir = new Vector3(horizontal, 0, vertical);

            /* Get the spawn position */
            var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point

            /* Now spawn */
            int spawnIndex = GetRandomEnemyIndex();
            var enemy = Instantiate(enemyList[spawnIndex].shark, spawnPos, Quaternion.identity) as GameObject;

            /* Rotate the enemy to face towards player */
            enemy.transform.LookAt(point);

            /* Adjust height */
            enemy.transform.Translate(new Vector3(0, enemy.transform.localScale.y / 2, 0));
        }
    }
}
