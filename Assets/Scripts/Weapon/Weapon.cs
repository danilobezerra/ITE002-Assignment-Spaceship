using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    public Projectile projectilePrefab;

    public int municaoMaxima = 20;
    public const float segRecarregar = 5f;

    public abstract int municaoAtual { get; set; }

    void Start() {
        AplicarMunicao();
    }

    void Update() {
        ChecarMunicao();
    }

    private void AplicarMunicao() {
        municaoAtual = municaoMaxima;
    }

    void ChecarMunicao() {
        if (municaoAtual <= 0) {
            StartCoroutine(Recarregar());
        }
    }

    IEnumerator Recarregar() {
        Debug.Log("Recarregando...");
        yield return new WaitForSeconds(segRecarregar);
        municaoAtual = municaoMaxima;
    }

    public void Logar(string arma, int municao) {
        Debug.Log($"{arma}, Munição atual: {municao}");
    }

    public abstract void Disparo();
}
