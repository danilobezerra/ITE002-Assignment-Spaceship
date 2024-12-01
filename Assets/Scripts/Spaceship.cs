using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Weapon weapon;
    private Movement movement;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log(gameManager);
        weapon = GetComponent<Weapon>();
        movement = GetComponent<Movement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision!");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.RestartGame();
        }
    }

    void Update()
    {
        weapon.HandleShooting();
        movement.HandleMovement();
    }
}
