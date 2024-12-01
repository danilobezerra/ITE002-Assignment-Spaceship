using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float xMin = -8f;
    public float xMax = 8f;
    public float yMin = -4f;
    public float yMax = 4f;

    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPosition = new(
            Random.Range(xMin, xMax),
            Random.Range(yMin, yMax),
            0f
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
