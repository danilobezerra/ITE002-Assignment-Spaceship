using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudio : MonoBehaviour
{
    public float lifetime = 5f;

    void Start() {
        StartCoroutine(SeMatar());
    }

    IEnumerator SeMatar() {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
