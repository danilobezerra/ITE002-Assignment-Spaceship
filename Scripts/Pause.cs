using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject Pausa;
    public GameObject GameOver;

    private void Start()
    {
        GameOver.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Pause()
    {
        Pausa.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void Resume()
    {
        Pausa.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
}
