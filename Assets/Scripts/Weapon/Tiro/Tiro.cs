using UnityEngine;

public class Tiro : Weapon {
    public Projectile projectilePrefab;
    public GameObject AudioTiro;
    public override void Disparo() {
        if (municaoAtual <= 0) {
            return;
        }
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        Instantiate(AudioTiro, transform.position, transform.rotation);
        municaoAtual--;
        Logar("TIRO", municaoAtual);
    }
}