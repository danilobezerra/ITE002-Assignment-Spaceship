using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    int municaoMaxima = 20;
    const float segRecarregar = 5f;
    protected int municaoAtual;
    
    void Start() {
        AplicarMunicao();
    }
    
    void Update() {
        ChecarMunicao();
    }
    
    void AplicarMunicao() {
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
        AplicarMunicao();
    }
    
    public void Logar(string arma, int municao) {
        Debug.Log($"{arma}, Munição atual: {municao}");
    }
    
    public abstract void Disparo();
}