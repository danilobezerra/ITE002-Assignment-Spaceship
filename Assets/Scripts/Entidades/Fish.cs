using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    bool playerInside;
    float tugs=0;
    [SerializeField] float neededTugs;
    [SerializeField] int score;

    [SerializeField] Slider tugBar;

    // Update is called once per frame
    void Update()
    {
        TugCheck();
    }

    void TugCheck()
    {
        if (playerInside && Input.GetButtonDown("Submit"))
        {
            tugs++;
            tugBar.value = tugs / neededTugs;
            if (tugs >= neededTugs)
            {
                GetFished();
            }
        }
    }

    void GetFished()
    {
        ScoreManager.instance.AddScore(score);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
