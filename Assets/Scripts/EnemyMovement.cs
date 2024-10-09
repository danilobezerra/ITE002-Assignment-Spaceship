using UnityEngine;
public class EnemyMovement : MonoBehaviour { 
    public float speed = 3f; 
    private Vector3 targetPosition; 
    
    void Start() { 
        SetNewTargetPosition(); 
    } 
    
    void Update() { 
        MoveTowardsTarget(); 
    } 
    
    void SetNewTargetPosition() { 
        targetPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0); 
    } 
    
    void MoveTowardsTarget() { 
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) { 
            SetNewTargetPosition(); 
        } 
    } 
}