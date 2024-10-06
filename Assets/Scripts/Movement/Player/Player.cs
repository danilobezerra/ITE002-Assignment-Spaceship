using UnityEngine;

public class Player : Movement { 
    public override float speed { get; set; } = 10f;

    public override void AplicarMovimentacao() {
        var horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, 0));
    }
}
