using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Projectile projectilePrefab;  
    public Transform firePoint;         
    public int maxAmmo = 10;
    public float fireRate = 0.5f;
    public float reloadTime = 2f;
    public bool isBurstMode = false;
    public int burstCount = 3;
    private int currentAmmo;
    private bool isReloading = false;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (isReloading)
            return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (currentAmmo > 0)
            {
                if (isBurstMode)
                {
                    StartCoroutine(FireBurst());
                }
                else
                {
                    FireSingleShot();
                }
            }
            else
            {
                Debug.Log("Sem munição! Pressione 'R' para recarregar.");
            }
        }
    }

    private void FireSingleShot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        currentAmmo--;
    }

    private IEnumerator FireBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            if (currentAmmo <= 0)
                break;

            FireSingleShot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Recarregando...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        Debug.Log("Recarregado!");
        isReloading = false;
    }
}
