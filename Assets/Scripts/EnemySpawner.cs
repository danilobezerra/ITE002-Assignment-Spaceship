using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float xMin = -8f;
    public float xMax = 8f;
    public float yMin = -4f;
    public float yMax = 4f;

    public float minDistanceFromPlayer = 5f;
    public int maxEnemies = 20;

    private Transform playerTransform;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;

        SpawnEnemy();
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

    public void SpawnEnemies(int count)
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
        }
    }
}
