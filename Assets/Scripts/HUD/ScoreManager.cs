using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    int scoreCount = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    public void AddScore(int pontuacao)
    {
        scoreCount += pontuacao;
        scoreText.text = "Score: " + scoreCount.ToString();
    }
}
