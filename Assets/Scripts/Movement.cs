using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento
    private Rigidbody2D rb; // Referência ao Rigidbody2D do objeto

    private Vector2 movementInput; // Armazena a entrada de movimento

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Captura a entrada do jogador
    private void GetMovementInput()
    {
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");
    }

    // Move o objeto
    private void Move()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }
}
