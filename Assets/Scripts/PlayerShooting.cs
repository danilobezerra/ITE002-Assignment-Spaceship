using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float nextFireTime;
    private Weapon weapon;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if(weapon.ammo > 0)
        {
            if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                SpreadShot();
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                BarrageShot();
            }
        }

    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 10f;
    }

    void SpreadShot()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            float angle = i * 15f;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            rb.velocity = rotation * transform.up * 10f;
            weapon.ammo--;
        }
    }

    void BarrageShot()
    {
        StartCoroutine(BarrageCoroutine());
    }

    private System.Collections.IEnumerator BarrageCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {
            Shoot();
            yield return new WaitForSeconds(0.1f);
            weapon.ammo--;
        }
    }
}
