using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 5;
    private int enemiesToSpawn = 3; // Enemies to be spawn at a time
    public int enemiesSpawned = 0;

    void Update()
    {
        SpawnTheEnemies();
    }

    private void SpawnTheEnemies() // Enemies Spawing at random location
    {
        if (enemiesSpawned < enemiesToSpawn)
        {
            GameObject temp = Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
            temp.GetComponent<EnemyController>().GetEnemySpawner(this.gameObject.GetComponent<EnemySpawner>()); // Giving the reference of enemy spawner to enemy Controller
        }
    }
    private Vector3 GenerateRandomPosition() // Generating random position
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.8f, spawnPosZ);
        return randomPos;
    }
}
