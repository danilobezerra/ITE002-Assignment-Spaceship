using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo
    public float spawnInterval = 5f; // Intervalo de tempo para spawnar inimigos
    public Transform[] spawnPoints; // Posições de spawn

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval); // Spawn repetido
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // Seleciona ponto de spawn aleatório
        Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity); // Instancia o inimigo
    }
}
