using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public Projectile projectilePrefab; // Prefab do projétil
    public float fireRate = 0.5f; // Taxa de disparo
    public int maxAmmo = 10; // Quantidade máxima de munição
    private int currentAmmo; // Munição atual
    private float lastFireTime = 0f; // Tempo do último disparo
    private bool isReloading = false; // Estado da recarga
    private WeaponUI weaponUI; // Referência ao gerenciador da UI

    public enum FireMode { Single, Burst } // Tipos de disparo
    public FireMode fireMode = FireMode.Single; // Tipo de disparo atual
    public int burstCount = 3; // Número de projéteis na rajada
    public float burstDelay = 0.1f; // Delay entre disparos na rajada

    void Start()
    {
        currentAmmo = maxAmmo; // Inicia a munição atual com o máximo
        weaponUI = FindObjectOfType<WeaponUI>(); // Encontra o gerenciador da UI
        weaponUI.UpdateAmmo(currentAmmo, maxAmmo); // Atualiza a UI no início
        weaponUI.UpdateFireMode(GetFireModeString()); // Atualiza o modo de tiro na UI
    }

    void Update()
    {
        // Troca de modo de disparo com a tecla "Q"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchFireMode(); // Alterna o modo de disparo
        }
        
        // Atira com a tecla "Space"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire(); // Executa o disparo
        }
    }

    public void Fire()
    {
        if (!isReloading && currentAmmo > 0 && Time.time >= lastFireTime + fireRate)
        {
            if (fireMode == FireMode.Single)
            {
                Shoot(); // Atira um projétil
            }
            else if (fireMode == FireMode.Burst)
            {
                StartCoroutine(BurstFire()); // Atira múltiplos projéteis
            }
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        lastFireTime = Time.time; // Atualiza o tempo do último disparo
        currentAmmo--; // Diminui a munição
        weaponUI.UpdateAmmo(currentAmmo, maxAmmo); // Atualiza a UI
    }

    private IEnumerator BurstFire()
    {
        for (int i = 0; i < burstCount; i++)
        {
            Shoot(); // Atira um projétil
            yield return new WaitForSeconds(burstDelay); // Espera entre disparos da rajada
        }
        lastFireTime = Time.time; // Atualiza o tempo do último disparo após a rajada
    }

    public void SwitchFireMode()
    {
        fireMode = (fireMode == FireMode.Single) ? FireMode.Burst : FireMode.Single; // Alterna entre modos
        weaponUI.UpdateFireMode(GetFireModeString()); // Atualiza o texto do modo de tiro na UI
        Debug.Log("Modo de Tiro: " + GetFireModeString()); // Para depuração, você pode ver o modo atual no console
    }

    private string GetFireModeString()
    {
        return fireMode == FireMode.Single ? "Único" : "Rajada"; // Retorna o nome do modo de tiro em português
    }

    public void Reload()
    {
        // Inicia a recarga se não estiver recarregando
        if (!isReloading)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true; // Define o estado como recarregando
        weaponUI.ShowReloading(); // Mostra o texto de recarga
        yield return new WaitForSeconds(3f); // Delay de 3 segundos
        currentAmmo = maxAmmo; // Recarrega a munição para o máximo
        weaponUI.HideReloading(); // Esconde o texto de recarga
        weaponUI.UpdateAmmo(currentAmmo, maxAmmo); // Atualiza a UI
        isReloading = false; // Define o estado como não recarregando
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo; // Retorna a munição atual
    }

    public int GetMaxAmmo()
    {
        return maxAmmo; // Retorna a quantidade máxima de munição
    }
}
