using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    public Vector3 direction = Vector3.up;
    public int damage = 10; // Adicione uma variável de dano

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * direction);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Verifica se atingiu um inimigo
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Causa dano ao inimigo
                Destroy(gameObject); // Destrói o projetil após a colisão
            }
        }
    }
}
