using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject projectilePrefab;
    public float shootingInterval = 2f;
    

    private Transform player;
    private float nextShootTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextShootTime = Time.time + shootingInterval;
    }

    private void Update()
    {
        MoveTowardsPlayer();

        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootingInterval;
        }
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector3 shootDirection = (player.position - transform.position).normalized;
            projectile.GetComponent<Projectile>().direction = shootDirection; 
        }
    }

    public void TakeDamage(int damage)
    {
        int health = 1;
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
