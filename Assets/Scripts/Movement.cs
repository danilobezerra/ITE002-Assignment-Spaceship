using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 movementDirection;

    void Update()
    {
        if (CompareTag("Player"))
        {
            HandleMovement();
        }
    }

    public void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontal, vertical, 0f).normalized;

        Move();
    }

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime * movementDirection);
    }

    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction.normalized;
    }
}
