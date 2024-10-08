using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Projectile projectilePrefab; 
    public Transform player;  

    public float shootCooldown = 2f; 
    private float shootTimer;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        shootTimer = shootCooldown;
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            Atirar();
            shootTimer = shootCooldown; 
        }
    }

    public void Atirar()
    {
        Vector3 direction = (player.position - transform.position).normalized;

       
        Projectile newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        newProjectile.Setup(direction);
    }
}
