using UnityEngine;

public class Spaceship : MonoBehaviour
{

    public float speed = 5f;
    public Projectile projectilePrefab;

    private MovementController _movementController;
    private ShootingController _shootingController;
    private BoundaryController _boundaryController;


    void Start()
    {
        _movementController = GetComponent<MovementController>();
        _shootingController = GetComponent<ShootingController>();
        _boundaryController = GetComponent<BoundaryController>();

        _boundaryController.Initialize(GetComponent<SpriteRenderer>());
    }

    void Update()
    {
        _movementController.ApplyMovement(speed);
        _shootingController.FireProjectile(projectilePrefab);
    }

    void LateUpdate()
    {
        _boundaryController.ClampPosition();
    }

}
