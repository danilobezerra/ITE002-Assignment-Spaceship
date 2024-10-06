using UnityEngine;

public class IA : Movement {
    public override float speed { get; set; } = 2f;

    public override void AplicarMovimentacao() {
        transform.Translate(Time.deltaTime * speed * new Vector3(0, -1));
    }
}
