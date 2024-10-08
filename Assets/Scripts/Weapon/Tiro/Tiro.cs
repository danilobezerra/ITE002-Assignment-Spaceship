using UnityEngine;
using UnityEngine.UI;

public class Tiro : Weapon {
    public override int municaoAtual { get; set; }

    public AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    public override void Disparo() {
        if (municaoAtual <= 0) {
            return;
        }
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        audio.Play();
        Logar("TIRO", municaoAtual);
        municaoAtual--;
    }
}
