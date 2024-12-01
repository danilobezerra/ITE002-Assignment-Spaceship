using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Movement movement;
    private Transform playerTransform;

    void Start()
    {
        movement = GetComponent<Movement>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        playerTransform = player.transform;

    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            movement.SetMovementDirection(direction);
            movement.Move();
        }
    }
}
