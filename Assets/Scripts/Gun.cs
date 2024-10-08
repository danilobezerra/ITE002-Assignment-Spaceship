using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Projectile projectilePrefab;
    public float fireRate = 0.5f; 
    public int ammo = 10; 
    private float nextFireTime = 0f;


    public enum FireMode { Single, Burst }
    public FireMode currentFireMode = FireMode.Single;
    public int burstCount = 3;
    public AudioSource shootSound;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            if (currentFireMode == FireMode.Single)
            {
                Fire();
            }
            else if (currentFireMode == FireMode.Burst)
            {
                StartCoroutine(FireBurst());
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Reload(5); 
        }
    }
    void Fire()
    {
        if (Time.time >= nextFireTime)
        {
            
            Vector3 offset = transform.up * 0.7f; 
            Projectile newProjectile = Instantiate(projectilePrefab, transform.position + offset, transform.rotation);

            newProjectile.Setup(transform.up); 

            ammo--; 
            nextFireTime = Time.time + 1f / fireRate; 

            shootSound.Play();

        }
    }


    IEnumerator FireBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            Fire();
            if (ammo <= 0) break; 
            yield return new WaitForSeconds(1f / fireRate); 
        }
    }

    public void Reload(int ammoAmount)
    {
        ammo += ammoAmount; 
        Debug.Log($"Recarregado: {ammo} balas restantes."); 
    }
}
