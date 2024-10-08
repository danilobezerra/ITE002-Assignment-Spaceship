using UnityEngine;

public class IA : Movement {
    public override float speed { get; set; } = 5f;
    public float changeDirectionInterval = 1f;
    private Vector2 movementDirection;

    void Start() {
        AplicarMovimentacao();
    }

    void Update() {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    void ChangeDirection() {
        float randomAngle = Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
    }

    public override void AplicarMovimentacao() {
        ChangeDirection();
        InvokeRepeating("ChangeDirection", changeDirectionInterval, changeDirectionInterval);
    }
}
