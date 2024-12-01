using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Weapon weapon;
    private Movement movement;

    void Start()
    {
        weapon = GetComponent<Weapon>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        weapon.HandleShooting();
        movement.HandleMovement();
    }
}
