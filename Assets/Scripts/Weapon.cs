using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public Projectile projectilePrefab;
    public int ammoCapacity = 30;
    private int currentAmmo;
    public float fireRate = 0.1f;
    private bool isReloading = false;
    public float reloadTime = 2f;
    private float nextFireTime = 0f;

    public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = ammoCapacity;
    }

    public void HandleShooting()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        currentAmmo--;
        audioSource.PlayOneShot(shootSound);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        // Adicione feedback de recarregamento aqui
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = ammoCapacity;
        isReloading = false;
    }
}
