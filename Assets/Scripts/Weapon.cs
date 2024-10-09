using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public Projectile projectilePrefab; // O prefab do proj�til
    public int maxAmmo = 12; // Muni��o m�xima
    public float fireRate = 0.3f; // Taxa de disparo (segundos entre os tiros)
    public int burstCount = 3; // N�mero de disparos em rajada
    public float reloadTime = 2f; // Tempo para recarregar

    private int currentAmmo;
    private float nextFireTime;
    private bool isReloading;

    private void Start()
    {
        currentAmmo = maxAmmo; // Inicializa a muni��o
    }

    private void Update()
    {
        if (isReloading)
            return;

        if (Input.GetButtonDown("Fire1")) // Tiro �nico
        {
            FireSingleShot();
        }
        else if (Input.GetButton("Fire2")) // Rajada
        {
            FireBurst();
        }
    }

    private void FireSingleShot()
    {
        if (currentAmmo > 0 && Time.time >= nextFireTime)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            currentAmmo--;
            nextFireTime = Time.time + fireRate;

            if (currentAmmo <= 0)
                StartCoroutine(Reload());
        }
    }

    private void FireBurst()
    {
        if (currentAmmo > 0 && Time.time >= nextFireTime)
        {
            int shotsToFire = Mathf.Min(burstCount, currentAmmo); // Garantir que n�o dispare mais do que a muni��o dispon�vel
            StartCoroutine(FireBurstCoroutine(shotsToFire));
            nextFireTime = Time.time + (shotsToFire * fireRate); // Define o tempo total para a pr�xima rajada
        }
    }

    private IEnumerator FireBurstCoroutine(int shotsToFire)
    {
        for (int i = 0; i < shotsToFire; i++)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            currentAmmo--;
            yield return new WaitForSeconds(fireRate); // Espera entre os disparos da rajada
        }

        if (currentAmmo <= 0)
            StartCoroutine(Reload());
    }


    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Recarregando...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Arma recarregada!");
    }
}
