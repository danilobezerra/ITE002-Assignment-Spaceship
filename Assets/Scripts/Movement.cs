using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 movementDirection;

    void Update()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        // Para o jogador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontal, vertical, 0f);

        Move();
    }

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime * movementDirection);
    }

    // Função para inimigos controlados pela IA
    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }
}
