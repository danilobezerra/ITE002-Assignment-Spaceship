using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Movement movement;
    public Transform playerTransform;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        movement.SetMovementDirection(direction);
    }
}
