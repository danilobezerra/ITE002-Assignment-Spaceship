using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; 
    public float damage = 10f;
    private Vector3 _direction;

    void Start()
    {
        
        Destroy(gameObject, 1f); 
    }

    void Update()
    {
       
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    public void Setup(Vector3 direction)
    {
        _direction = direction;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if ((col.tag == "Enemy") || (col.tag == "Projectile"))
        {
            Destroy(gameObject); 
        }
    }
}