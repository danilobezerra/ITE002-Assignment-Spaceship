using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveSpeed = 3f;
        public Transform[] waypoints;
        private int waypointIndex = 0;
        public GameObject explosionPrefab;

        void Update()
        {
            Move();
        }

        void Move()
        {
            Transform targetWaypoint = waypoints[waypointIndex];
            Vector2 direction = (targetWaypoint.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
            }
        }

        public void Explode()
        {
            // Instanciar a explosão
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject); // Destroi o inimigo
        }
    }
}
