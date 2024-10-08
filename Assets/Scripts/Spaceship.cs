using UnityEngine;

public class Spaceship : MonoBehaviour {
    private Tiro _tiro;
    private TiroDispersao _tiroDispersao;
    private Player _player;

    void Start() {
        _tiro = GetComponent<Tiro>();
        _tiroDispersao = GetComponent<TiroDispersao>();
        _player = GetComponent<Player>();
    }

    void Update() {
        ApplyMovement();
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

    void ApplyMovement() {
        _player.AplicarMovimentacao();
    }
}