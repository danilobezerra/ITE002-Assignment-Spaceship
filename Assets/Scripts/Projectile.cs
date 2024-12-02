using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    private Vector3 direction;

    void Start()
    {
        direction = transform.up;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(1);
            
            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
