using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public int pontos = 0;
    private Queue<string> cores = new Queue<string>(); // Fila para rastrear as �ltimas cores
    private int navesAtingidasParaRecompenca = 3; // N�mero de naves consecutivas necess�rias

    public void Pontuar(string enemyColor) {
        // Adiciona a cor do inimigo destru�do na fila
        cores.Enqueue(enemyColor);

        // Remove elementos excedentes
        if (cores.Count > navesAtingidasParaRecompenca) {
            cores.Dequeue();
        }

        // Verifica se as �ltimas 3 cores s�o iguais
        if (cores.Count == navesAtingidasParaRecompenca && CoresIguais()) {
            pontos += 20; // Pontua��o b�nus
            cores.Clear(); // Reseta a sequ�ncia
        }
        else {
            pontos += 5; // Pontua��o padr�o
        }

        Debug.Log("Pontua��o atual: " + pontos);
    }

    private bool CoresIguais() {
        // Verifica se todas as cores na fila s�o iguais
        string primeiraCor = null;
        foreach (string cor in cores) {
            if (primeiraCor == null)
                primeiraCor = cor;
            else if (cor != primeiraCor)
                return false;
        }
        return true;
    }
}
