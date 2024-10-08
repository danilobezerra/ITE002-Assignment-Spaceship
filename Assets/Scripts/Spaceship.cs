using UnityEngine;

public class Spaceship : MonoBehaviour {
    private Tiro _tiro;
    private TiroDispersao _tiroDispersao;

    void Start() {
        _tiro = GetComponent<Tiro>();
        _tiroDispersao = GetComponent<TiroDispersao>();
    }

    void Update() {
        FireProjectile();
    }

    void FireProjectile() {
        if (Input.GetButtonDown("Fire1")) {
            _tiro.Disparo();
        }

        if (Input.GetButtonDown("Fire2")) {
            _tiroDispersao.Disparo();
        }
    }
}