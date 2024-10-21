using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{

    public GameObject[] spaceships;
    public Vector3 range;
    public float tempo;

    void Start()
    {
        InvokeRepeating("Create", 0, tempo);
    }

    void Create() {
        GameObject Spaceship = spaceships[Random.Range(0, spaceships.Length)];
        Vector3 pos = this.transform.position + Vector3.Lerp(-range, range, Random.value);
        Instantiate(Spaceship, pos, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
