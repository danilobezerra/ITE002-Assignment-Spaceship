using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private SpriteRenderer _renderer; // Componente para renderizar o sprite da nave
    private Bounds _cameraBounds; // Limites da câmera para restringir a movimentação da nave
    private PlayerMovement _movement; // Componente de movimentação da nave
    private Weapon _weapon; // Componente de arma da nave

    void Start()
    {
        // Inicializa os componentes necessários
        _renderer = GetComponent<SpriteRenderer>();
        _movement = GetComponent<PlayerMovement>(); // Usa o novo PlayerMovement
        _weapon = GetComponent<Weapon>();

        // Calcula os limites da câmera com base na ortografia
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Camera.main.aspect;
        _cameraBounds = new Bounds(Vector3.zero, new Vector3(width, height));
    }

    void LateUpdate()
    {
        // Limita a posição da nave para que não saia da tela
        var spriteWidth = _renderer.sprite.bounds.extents.x;
        var spriteHeight = _renderer.sprite.bounds.extents.y;

        var newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, _cameraBounds.min.x + spriteWidth, _cameraBounds.max.x - spriteWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, _cameraBounds.min.y + spriteHeight, _cameraBounds.max.y - spriteHeight);
        transform.position = newPosition; // Atualiza a posição da nave
    }

    void Update()
    {
        // Obtém a entrada do jogador para movimentação
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movement.Move(direction); // Chama o método de movimentação

        // Verifica se o jogador pressionou o botão de disparo
        if (Input.GetButtonDown("Fire1"))
        {
            _weapon.Fire(); // Chama o método de disparo da arma
        }

        // Recarregar munição se a tecla R for pressionada
        if (Input.GetKeyDown(KeyCode.R)) // Pressione R para recarregar
        {
            _weapon.Reload(); // Chama o método de recarga da arma
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Verifica se a nave colidiu com uma nave inimiga
        if (col.CompareTag("EnemyShip"))
        {
            Destroy(gameObject); // Destrói a nave do jogador
        }
    }
}
