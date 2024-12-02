using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private int currentHealth;
    private EnemySpawner spawner;
    private GameManager gameManager;

    public int maxHealth = 5;
    public Slider healthBarSlider;
    public SpriteRenderer enemyRenderer;

    public GameObject explosionPrefab;

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

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashRed()
    {
        enemyRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemyRenderer.color = Color.white;
    }

    void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        gameManager.IncrementKillCount();
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        healthBarSlider.value = currentHealth;
    }
}
