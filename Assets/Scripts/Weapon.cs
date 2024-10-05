using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform pontoDisparo;
    public float segRecarregar = 2f;
    private int municaoAtual;
    public int municaoMaxima = 7;
    private bool carregandoMuni = false;
    private float proximoDisparo = 0f;
    private float segPorTiro = 1f;
    // Start is called before the first frame update
    void Start()
    {
        municaoAtual = municaoMaxima; //inicializando a municacao atual p 7
    }

    // Update is called once per frame
    void Update()
    {
        if (carregandoMuni)
            return; //não permitindo atirar caso estiver carregando

        if (municaoAtual <= 0)
        {
            StartCoroutine(Recarregar()); //função do Unity para executar uma função de forma assincrona
        }

        //botao esquerdo do mouse
        if (Input.GetButtonDown("Fire1") && Time.time >= proximoDisparo)
        {
            TiroUnico();
            proximoDisparo = Time.time + 1f / segPorTiro;
        }

        //botao direito do mouse
        if (Input.GetButtonDown("Fire2") && Time.time >= proximoDisparo)
        {
            StartCoroutine(TiroExplodir(3)); //com rajada de três tiros
            proximoDisparo = Time.time + 1f / segPorTiro *3;
        }
    }

    void TiroUnico()
    {
        if (municaoAtual <= 0)
            return;

        Instantiate(projectilePrefab, pontoDisparo.position, pontoDisparo.rotation); //disparando um projétil

        municaoAtual--;
    }

    IEnumerator TiroExplodir(int explosoes)
    {
        if (municaoAtual <= 0)
            yield break;

        //disparando vários projéteis em rajada
        for (int i = 0; i < explosoes; i++)
        {
            if (municaoAtual <= 0)
                break;

            Instantiate(projectilePrefab, pontoDisparo.position, pontoDisparo.rotation);
            municaoAtual--;

            yield return new WaitForSeconds(1f/segPorTiro);
        }
    }

    IEnumerator Recarregar()
    {
        carregandoMuni = true;
        Debug.Log("Recarregando...");

        yield return new WaitForSeconds(segRecarregar);

        municaoAtual = municaoMaxima;
        carregandoMuni = false;
    }
}

