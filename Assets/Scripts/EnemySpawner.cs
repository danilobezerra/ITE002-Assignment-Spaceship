using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float xMin = -8f;
    public float xMax = 8f;
    public float yMin = -4f;
    public float yMax = 4f;

    public float minDistanceFromPlayer = 10f;
    public int maxEnemies = 20;

    public float initialSpawnInterval = 3f;
    public float spawnIntervalDecrease = 0.05f;
    public float minimumSpawnInterval = 0.5f;

    private Transform playerTransform;

    private float currentSpawnInterval;
    private float timeSinceStart = 0f;

    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;


        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnEnemiesRegularly());
    }

    IEnumerator SpawnEnemiesRegularly()
    {
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(currentSpawnInterval);

            timeSinceStart += currentSpawnInterval;

            currentSpawnInterval = Mathf.Max(initialSpawnInterval - (spawnIntervalDecrease * timeSinceStart), minimumSpawnInterval);
        }
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPosition;

        do
        {
            spawnPosition = new Vector3(
                Random.Range(xMin, xMax),
                Random.Range(yMin, yMax),
                0f
            );
        } while (playerTransform != null && Vector3.Distance(spawnPosition, playerTransform.position) < minDistanceFromPlayer);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
