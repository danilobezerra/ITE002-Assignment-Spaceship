using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int valorPontos;
    public GameObject efeitoMorte;
    public WaveManager waveManager;

    bool fishActive = false;
    public bool isPlayer = false;
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(DamagedEffect());
        if (health < 1)
        {
            Instantiate(efeitoMorte, transform.position, Quaternion.identity);
            ScoreManager.instance.AddScore(valorPontos);
            if (!isPlayer)
            {
                waveManager.ReduceEnemyCount();
                fishActive = false;
            }
            Destroy(gameObject);
        }
        
    }

    IEnumerator DamagedEffect()
    {
        //FF1B21
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;
        }
    }

    private void OnBecameVisible()
    {
        fishActive = true;
    }
    private void OnBecameInvisible()
    {
        if (fishActive & waveManager != null)
        {
            waveManager.ReduceEnemyCount();
            Destroy(gameObject);
        }
    }
}
