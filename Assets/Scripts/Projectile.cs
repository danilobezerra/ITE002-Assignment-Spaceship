using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    public int damage;

    private void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Arma").GetComponent<Gun>().damage;
    }
    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.right);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            ApplyDamage(collision);
        }
    }

    private void ApplyDamage(Collider2D inimigo)
    {
        inimigo.GetComponent<Health>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
