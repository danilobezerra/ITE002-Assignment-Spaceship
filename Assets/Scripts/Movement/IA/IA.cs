using UnityEngine;

public class IA : Movement {
    public override float speed { get; set; } = 2f;

    public AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    public override void AplicarMovimentacao() {
        transform.Translate(Time.deltaTime * speed * new Vector3(0, -1));
        audio.Play();
    }
}
