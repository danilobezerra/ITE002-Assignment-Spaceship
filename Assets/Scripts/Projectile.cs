using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    public int dano = 1; // Dano causado pelo projétil

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroi o projétil se sair da tela
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Inimigo inimigo = other.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                inimigo.TomarDano(dano); // Aplica dano ao inimigo
                Destroy(gameObject); // Destroi o projétil após causar dano
            }
        }
        else if (other.CompareTag("Wall")) // Se o projétil colidir com uma parede
        {
            Destroy(gameObject); // Destroi o projétil
        }
    }
}
