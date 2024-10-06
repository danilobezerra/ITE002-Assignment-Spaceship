using UnityEngine;

public class TiroDispersao : Weapon {
    public override int municaoAtual { get; set; }

    const int projeteisPorDisparoSecundario = 5;
    const int dispersao = 30;

    Quaternion rotacao;

    public override void Disparo() {
        float anguloPorProjetil = (float)dispersao / (projeteisPorDisparoSecundario - 1);

        for (int i = 0; i < projeteisPorDisparoSecundario; i++) {
            if (municaoAtual <= 0) {
                break;
            }

            float anguloAtual = -dispersao / 2 + i * anguloPorProjetil;
            rotacao = Quaternion.Euler(0, 0, anguloAtual);

            Instantiate(projectilePrefab, transform.position, transform.rotation * rotacao);
            Logar("SHOTGUN", municaoAtual);
            municaoAtual--;
        }
    }
}
