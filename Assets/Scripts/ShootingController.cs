using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public void FireProjectile(Projectile projectilePrefab)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}