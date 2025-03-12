using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public float minSpawnTime = 1f; // Tiempo mínimo entre spawns
    public float maxSpawnTime = 5f; // Tiempo máximo entre spawns
    public float enemyLifetime = 5f; // Tiempo de vida del enemigo antes de ser destruido

    private float nextSpawnTime;

    void OnEnable()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        nextSpawnTime -= Time.deltaTime;

        if (nextSpawnTime <= 0f)
        {
            SpawnEnemy();
            SetNextSpawnTime();
        }
    }

    void SpawnEnemy()
    {
        // Instanciar el enemigo
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

        // Destruir el enemigo después de cierto tiempo
        Destroy(enemy, enemyLifetime);
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}