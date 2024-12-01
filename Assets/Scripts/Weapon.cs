using UnityEngine;
using System.Collections;
using TMPro;

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
    public AudioClip reloadSound;
    private AudioSource audioSource;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI reloadText;

    void Start()
    {
        currentAmmo = ammoCapacity;
        audioSource = GetComponent<AudioSource>();
        UpdateAmmoText();
        reloadText.gameObject.SetActive(false);
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
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        currentAmmo--;
        audioSource.PlayOneShot(shootSound);
        UpdateAmmoText();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadText.gameObject.SetActive(true);
        audioSource.PlayOneShot(reloadSound);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = ammoCapacity;
        isReloading = false;
        reloadText.gameObject.SetActive(false);
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = $"Munição: {currentAmmo.ToString("D2")} / {ammoCapacity}";
    }
}
