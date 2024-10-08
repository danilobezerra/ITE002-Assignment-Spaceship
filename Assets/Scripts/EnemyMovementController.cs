
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float speed = 2f; 
    public float movementRange = 10f; 
    private Vector3 startPosition;
    private bool movingRight = true; 

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
      
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); 
            if (transform.position.x >= startPosition.x + movementRange)
            {
                movingRight = false; 
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); 
            if (transform.position.x <= startPosition.x - movementRange)
            {
                movingRight = true; 
            }
        }
    }
}
