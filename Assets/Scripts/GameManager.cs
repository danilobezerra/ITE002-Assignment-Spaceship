using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int enemiesKilled = 0;

    public TextMeshProUGUI killCountText; 

    void Start()
    {
        UpdateKillCountUI();
    }

    public void IncrementKillCount()
    {
        enemiesKilled++;
        UpdateKillCountUI();
    }

    private void UpdateKillCountUI()
    {
        if (killCountText != null)
        {
            killCountText.text = $"Inimigos Mortos: {enemiesKilled}";
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
