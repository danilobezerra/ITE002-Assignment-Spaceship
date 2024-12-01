using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public Slider healthBarSlider;

    private EnemySpawner spawner;
    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;

        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;

        spawner = FindObjectOfType<EnemySpawner>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        spawner.SpawnEnemies(2);
        gameManager.IncrementKillCount();

        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        healthBarSlider.value = currentHealth;
    }
}
