using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemySpaceship;
    float maxSpawnRateInSeconds = 5f;

    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        // Aumentar a taxa de spawn de inimigo a cada 30s
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = Instantiate(EnemySpaceship);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        NextSpawn();
    }

    void NextSpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}
