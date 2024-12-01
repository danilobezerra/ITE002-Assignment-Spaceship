using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public Slider healthBarSlider;

    private EnemySpawner spawner;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

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
        if (spawner != null)
        {
            spawner.SpawnEnemy();
        }

        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        if (healthBarSlider != null)
        {
            healthBarSlider.value = currentHealth;
        }
    }
}
