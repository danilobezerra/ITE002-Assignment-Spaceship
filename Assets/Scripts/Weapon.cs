using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile projectilePrefab;
    public int ammo = 10;
    public int maxAmmo = 10;
    public float fireRate = 0.5f;
    private float lastFireTime;

    void Update()
    {
        // Disparo
        if (Input.GetButtonDown("Fire1") && Time.time > lastFireTime + fireRate)
        {
            if (ammo > 0)
            {
                Fire();
                ammo--;
                lastFireTime = Time.time;
            }
        }

        // Recarregar a arma (pressione R)
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    void Reload()
    {
        ammo = maxAmmo; // Recarrega a munição
        Debug.Log("Arma recarregada!"); // Feedback no console
    }
}
