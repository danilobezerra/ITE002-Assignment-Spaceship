using UnityEngine;

public class Player : Movement { 
    public override float speed { get; set; } = 10f;

    public AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();   
    }

    public override void AplicarMovimentacao() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, vertical);

        transform.Translate(Time.deltaTime * speed * movement);
        audio.Play();
    }
}
