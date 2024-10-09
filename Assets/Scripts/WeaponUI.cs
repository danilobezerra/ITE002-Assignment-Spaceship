using UnityEngine;
using TMPro; // Importando o namespace do TextMesh Pro

public class WeaponUI : MonoBehaviour
{
    public TMP_Text ammoText; // Texto para mostrar a munição
    public TMP_Text reloadingText; // Texto para mostrar que está recarregando
    public TMP_Text fireModeText; // Texto para mostrar o modo de tiro

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        ammoText.text = "Munição: " + currentAmmo + "/" + maxAmmo; // Atualiza o texto da munição
    }

    public void ShowReloading()
    {
        reloadingText.gameObject.SetActive(true); // Ativa o texto de recarregando
    }

    public void HideReloading()
    {
        reloadingText.gameObject.SetActive(false); // Desativa o texto de recarregando
    }

    public void UpdateFireMode(string fireMode)
    {
        fireModeText.text = "Modo de tiro: " + fireMode; // Atualiza o texto do modo de tiro
    }
}
