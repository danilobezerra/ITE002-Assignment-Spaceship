using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Button _buttonStart;

    [SerializeField]
    private Button _buttonQuit;

    private void Start()
    {
        
    }

    public void CallNewGames()
    {
        SceneManager.LoadScene("CenaCerta");
        Time.timeScale = 1f;
    }

    public void CallQuitGames()
    {
        Application.Quit();
    }
}
