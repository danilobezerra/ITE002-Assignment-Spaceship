using UnityEngine;
public class PlayerMovement : MonoBehaviour 
{ 
    public float speed = 5f; 
    void Update() { 
        var horizontal = Input.GetAxis("Horizontal"); 
        var vertical = Input.GetAxis("Vertical"); 
        transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, vertical)); 
    } 
}