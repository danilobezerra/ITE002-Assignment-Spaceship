using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Movement movement;
    private Transform playerTransform;

    void Start()
    {
        movement = GetComponent<Movement>();

        var player = GameObject.FindGameObjectWithTag("Player");

        playerTransform = player.transform;

    }

    void Update()
    {
        if (playerTransform != null)
        {
            var direction = (playerTransform.position - transform.position).normalized;

            movement.SetMovementDirection(direction);
            movement.Move();
        }
    }
}
