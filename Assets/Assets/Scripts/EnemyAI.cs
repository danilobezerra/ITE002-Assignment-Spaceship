using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f; 
    public float attackRange = 1.5f;
    public float moveSpeed = 3f;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void ExecuteAI()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            if (distanceToPlayer > attackRange)
            {
                ChasePlayer();
            }
            else
            {
                AttackPlayer();
            }
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void AttackPlayer()
    {
        Debug.Log("Inimigo atacando!");
    }
}
