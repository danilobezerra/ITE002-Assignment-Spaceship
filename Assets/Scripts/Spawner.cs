using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyTypes;
    public int enemyCount;
    public enum Enemies { SWORDFISH, PJELLYFISH, BJELLYFISH, SHARK }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for(; ; )
        {
            Instantiate(enemyTypes[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }

}
