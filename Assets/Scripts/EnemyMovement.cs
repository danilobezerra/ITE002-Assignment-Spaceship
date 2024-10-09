using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidade de movimento
    public Transform[] patrolPoints; // Pontos de patrulha
    private int currentPointIndex = 0;

    private void Update()
    {
        Patrol();
    }

    // Lógica de patrulha
    private void Patrol()
    {
        if (patrolPoints.Length == 0) return; // Retorna se não houver pontos de patrulha

        Transform targetPoint = patrolPoints[currentPointIndex];
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, step);

        // Verifica se o inimigo chegou ao ponto de patrulha
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length; // Avança para o próximo ponto
        }
    }
}
