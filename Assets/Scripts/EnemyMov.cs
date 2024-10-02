using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoInimigo : MonoBehaviour
{
    public float speed = 3f;

    void ApplyMovement()
    {
        transform.Translate(Time.deltaTime * speed * new Vector3(0,-1,0));
    }
}
