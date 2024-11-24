using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int initialEnemyCount = 5; // Quantidade inicial de inimigos
    public float timeBetweenWaves = 5f; // Tempo de espera entre as ondas
    public TMP_Text waveMessageText; // Refer�ncia ao TMP_Text para a mensagem da onda
    public float messageDisplayTime = 2f; // Tempo que a mensagem fica na tela

    private int currentWave = 1;
    private EnemySpawner enemySpawner;
    private int activeEnemies = 0; // Contador de inimigos ativos

    void Start() {
        enemySpawner = GetComponent<EnemySpawner>();
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave() {
        while (true) {
            // Espera at� que todos os inimigos sejam derrotados
            if (activeEnemies == 0) {
                // Exibe a mensagem de onda
                ShowWaveMessage();

                // Aguarda o tempo entre waves antes de iniciar a pr�xima
                yield return new WaitForSeconds(timeBetweenWaves);

                // Inicia a pr�xima onda
                SpawnWave();
                currentWave++;
            }

            yield return null; // Checa a cada frame
        }
    }

    void SpawnWave() {
        int enemyCount = initialEnemyCount + (currentWave - 1) * 2; // Incrementa o n�mero de inimigos
        activeEnemies = enemyCount; // Atualiza a quantidade de inimigos ativos
        enemySpawner.SpawnEnemies(enemyCount);
    }

    // M�todo chamado quando um inimigo � derrotado
    public void OnEnemyDefeated() {
        activeEnemies--;
    }

    void ShowWaveMessage() {
        waveMessageText.color = Color.white; // Define a cor do texto como branco
        waveMessageText.gameObject.SetActive(true); // Exibe o texto
        waveMessageText.text = "Wave " + currentWave; // Define o texto
        StartCoroutine(HideWaveMessage());
    }

    IEnumerator HideWaveMessage() {
        float duration = 2f; // Dura��o do fade out
        float elapsed = 0f;

        Color originalColor = waveMessageText.color; // Armazena a cor original

        while (elapsed < duration) {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(originalColor.a, 0f, elapsed / duration); // Interpola a opacidade
            waveMessageText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null; // Espera o pr�ximo frame
        }

        waveMessageText.gameObject.SetActive(false); // Esconde o texto ap�s o fade out
    }
}
