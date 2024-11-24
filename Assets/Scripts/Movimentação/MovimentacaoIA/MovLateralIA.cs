using UnityEngine;

public class MovLateralAleatoria : MonoBehaviour {
    public float speed = 5f;
    public float tempoMinTroca = 1f; // Tempo m�nimo antes de trocar de dire��o
    public float tempoMaxTroca = 3f; // Tempo m�ximo antes de trocar de dire��o

    private float tempoTrocaDirecao;
    private float tempoAtual;
    private int direcao;

    void Start() {
        EscolherNovaDirecao();
    }

    void Update() {
        // Movimenta o objeto na dire��o atual
        transform.Translate(Vector3.right * direcao * speed * Time.deltaTime);

        // Atualiza o tempo e verifica se � hora de trocar de dire��o
        tempoAtual += Time.deltaTime;
        if (tempoAtual >= tempoTrocaDirecao) {
            EscolherNovaDirecao();
        }
    }

    void EscolherNovaDirecao() {
        // Escolhe aleatoriamente -1 (esquerda) ou 1 (direita)
        direcao = Random.Range(0, 2) == 0 ? -1 : 1;

        // Define um novo tempo aleat�rio para manter essa dire��o
        tempoTrocaDirecao = Random.Range(tempoMinTroca, tempoMaxTroca);

        // Reseta o temporizador
        tempoAtual = 0f;
    }
}
