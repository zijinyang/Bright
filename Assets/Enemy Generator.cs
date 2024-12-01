using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;       // Enemy prefab to spawn
    public Transform spawnPoint;         // Spawn position for the enemies
    public float minSpawnInterval = 5f;  // Minimum spawn interval in seconds
    public float maxSpawnInterval = 10f; // Maximum spawn interval in seconds

    public GameObject aStarPrefab;       // Reference to the A* prefab in your scene
    private AstarPath astarInstance;     // Reference to the A* instance
    void Start()
    {
        astarInstance = aStarPrefab.GetComponent<AstarPath>();

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        // Rescan the A* grid after spawning
        astarInstance.Scan();
    }
}
