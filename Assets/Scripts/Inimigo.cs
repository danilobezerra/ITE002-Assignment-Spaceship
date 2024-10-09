using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar a cena
using System.Collections; // Para corrotinas

public class Inimigo : MonoBehaviour
{
    public Transform jogador; // Referência ao jogador
    public float velocidade = 3f; // Velocidade de movimento do inimigo
    public float raioDeVisao = 10f; // Distância em que o inimigo pode ver o jogador
    public float distanciaDeAtaque = 2f; // Distância em que o inimigo pode atacar
    public int vida = 1; // Vida do inimigo
    public GameObject explosaoPrefab; // Prefab da explosão

    private void Update()
    {
        // Verifica se o inimigo ainda está vivo
        if (vida > 0)
        {
            // Calcula a distância até o jogador
            float distanciaParaJogador = Vector3.Distance(transform.position, jogador.position);

            // Verifica se o jogador está dentro do raio de visão
            if (distanciaParaJogador < raioDeVisao)
            {
                MoverEmDirecaoAoJogador(distanciaParaJogador);
            }
        }
    }

    private void MoverEmDirecaoAoJogador(float distanciaParaJogador)
    {
        // Se o jogador estiver dentro da distância de ataque
        if (distanciaParaJogador < distanciaDeAtaque)
        {
            Atacar(); // Chama a função de ataque
        }
        else
        {
            // Move o inimigo em direção ao jogador
            Vector3 direcao = (jogador.position - transform.position).normalized;
            transform.position += direcao * velocidade * Time.deltaTime;
        }
    }

    private void Atacar()
    {
        // Encerrar o jogo ao colidir com o jogador
        Debug.Log("Inimigo atacou o jogador! O jogo terminou.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TomarDano(int dano)
    {
        vida -= dano; // Reduz a vida do inimigo

        if (vida <= 0)
        {
            Explodir(); // Chama a função de explosão se a vida for menor ou igual a zero
        }
    }

    private void Explodir()
    {
        // Instancia a explosão na posição do inimigo
        Instantiate(explosaoPrefab, transform.position, transform.rotation);

        // Destroi o inimigo
        Destroy(gameObject);
    }
}
