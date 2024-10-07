using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject laserDoInimigo;
    public Transform localDoDisparo;
    public Transform localDoDisparo2;

    public float velocidadeDoInimigo;

    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
        AtirarLaser();
    }

    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.up * velocidadeDoInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if(tempoAtualDosLasers <= 0)
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 180f));
            Instantiate(laserDoInimigo, localDoDisparo2.position, Quaternion.Euler(0f, 0f, 180f));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }
}
