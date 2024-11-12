using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public GameObject efeitoMorte;
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(DamagedEffect());
        if (health < 1)
        {
            Instantiate(efeitoMorte, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    IEnumerator DamagedEffect()
    {
        //FF1B21
        Debug.Log("Tomou Dano");
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;
        }
        else
        {
            foreach (SpriteRenderer sprite  in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.color = Color.red;
            }
            yield return new WaitForSeconds(0.1f);
            foreach (SpriteRenderer sprite in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.color = Color.white;
            }
        }
    }
}
