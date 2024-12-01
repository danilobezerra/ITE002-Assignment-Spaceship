using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Slider healthBarSlider;

    private EnemySpawner spawner;

    void Start()
    {
        currentHealth = maxHealth;

        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;

        spawner = FindObjectOfType<EnemySpawner>();
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

        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        healthBarSlider.value = currentHealth;
    }
}
