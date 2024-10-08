using UnityEngine;
public class TiroDispersao : Weapon {

    public Projectile projectilePrefab;
    public GameObject AudioTiro;
    const int projeteisPorDisparoSecundario = 5;
    const int dispersao = 30;
    
    public override void Disparo() {
        if (municaoAtual <= 0) {
            return;
        }
        
        float anguloPorProjetil = (float) dispersao / (projeteisPorDisparoSecundario - 1);
        for (int i = 0; i < projeteisPorDisparoSecundario; i++) {
            if (municaoAtual <= 0) break;

            float anguloAtual = -dispersao / 2 + i * anguloPorProjetil;
            Quaternion rotacao = Quaternion.Euler(0, 0, anguloAtual);
            Instantiate(projectilePrefab, transform.position, transform.rotation * rotacao);
            Instantiate(AudioTiro, transform.position, transform.rotation);
            municaoAtual--;
            Logar("SHOTGUN", municaoAtual);
        }
    }
}