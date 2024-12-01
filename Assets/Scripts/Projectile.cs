using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    private Vector3 direction;

    void Start()
    {
        direction = transform.up;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
