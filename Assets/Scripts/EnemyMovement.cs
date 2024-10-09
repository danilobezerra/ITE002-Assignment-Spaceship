using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.01f; // Velocidade em unidades por segundo

    void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        // O movimento é calculado em unidades por segundo
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
        // Verificar se o inimigo saiu da tela
        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerShip") || col.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }
}
