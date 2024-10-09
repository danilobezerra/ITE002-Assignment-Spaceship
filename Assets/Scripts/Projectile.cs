using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    public int dano = 1; // Dano causado pelo proj�til

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroi o proj�til se sair da tela
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Inimigo inimigo = other.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                inimigo.TomarDano(dano); // Aplica dano ao inimigo
                Destroy(gameObject); // Destroi o proj�til ap�s causar dano
            }
        }
        else if (other.CompareTag("Wall")) // Se o proj�til colidir com uma parede
        {
            Destroy(gameObject); // Destroi o proj�til
        }
    }
}
