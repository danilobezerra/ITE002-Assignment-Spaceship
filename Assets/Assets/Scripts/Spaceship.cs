using UnityEngine;
using TMPro;
using System.Collections;

public class Spaceship : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Bounds _cameraBounds;
    public AudioClip laserSound;
    private AudioSource audioSource;
    public Projectile projectilePrefab;
    public GameObject projectileEffectPrefab;
    public float speed = 6f;

    private int maxAmmo = 10; 
    private int currentAmmo;
    private bool isReloading = false;
    public float reloadTime = 2.5f;

    public TMP_Text overheatText; // Referência ao texto da UI
    private bool isOverheated = false; 
    private float overheatTime = 5f;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = laserSound;
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Camera.main.aspect;
        _cameraBounds = new Bounds(Vector3.zero, new Vector3(width, height));
        currentAmmo = 0; 
        overheatText.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        var spriteWidth = _renderer.sprite.bounds.extents.x;
        var spriteHeight = _renderer.sprite.bounds.extents.y;

        var newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, _cameraBounds.min.x + spriteWidth, _cameraBounds.max.x - spriteWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, _cameraBounds.min.y + spriteHeight, _cameraBounds.max.y - spriteHeight);
        transform.position = newPosition;
    }

    void Update()
    {
        ApplyMovement();
        FireProjectile();
    }

    void FireProjectile()
    {
        if (isReloading || isOverheated) return;

        if (Input.GetButtonDown("Fire1") && currentAmmo < maxAmmo)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            audioSource.Play();
            currentAmmo++; // Incrementa a contagem de projeteis disparados

            if (currentAmmo >= maxAmmo)
            {
                StartCoroutine(Overheat());
            }
        }
    }

    void ApplyMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, vertical));
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = 0; // Munição total após a recarga
        isReloading = false;
    }

    IEnumerator Overheat()
    {
        isOverheated = true;
        overheatText.gameObject.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < overheatTime)
        {
            overheatText.text = $"Arma superaquecida, aguarde {Mathf.Ceil(overheatTime - elapsedTime)} segundos";
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        overheatText.gameObject.SetActive(false);
        currentAmmo = 0; 
        isOverheated = false;
    }
}
