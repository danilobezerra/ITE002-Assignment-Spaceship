using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject explode;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.name.StartsWith("EnemySpaceship")){
            Vector3 pos = collision.transform.position;
            GameObject clone = (GameObject)Instantiate(explode, pos, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Destroy(clone, 0.05f);
        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
