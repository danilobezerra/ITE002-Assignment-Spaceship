using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 movementDirection;

    // Boundaries
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Player's Sprite Half Size
    private float spriteHalfWidth;
    private float spriteHalfHeight;

    void Start()
    {
        // Calculate screen boundaries
        CalculateScreenBounds();

        // Get the SpriteRenderer component to determine the player's size
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteHalfWidth = spriteRenderer.bounds.size.x / 2;
            spriteHalfHeight = spriteRenderer.bounds.size.y / 2;
        }
        else
        {
            // Default half size if SpriteRenderer is missing
            spriteHalfWidth = 0.5f;
            spriteHalfHeight = 0.5f;
            Debug.LogWarning("SpriteRenderer not found on Player. Using default sprite half sizes.");
        }
    }

    void Update()
    {
        if (CompareTag("Player"))
        {
            HandleMovement();
            ClampPosition();
        }
    }

    public void HandleMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontal, vertical, 0f).normalized;

        Move();
    }

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime * movementDirection, Space.World);
    }

    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction.normalized;
    }

    private void CalculateScreenBounds()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Main Camera not found. Please tag your camera as 'MainCamera'.");
            return;
        }

        // Calculate the vertical and horizontal extents
        float verticalExtent = cam.orthographicSize;
        float horizontalExtent = verticalExtent * cam.aspect;

        minX = -horizontalExtent;
        maxX = horizontalExtent;
        minY = -verticalExtent;
        maxY = verticalExtent;
    }

    private void ClampPosition()
    {
        // Get the current position
        Vector3 pos = transform.position;

        // Clamp the position within the boundaries, considering the sprite size
        pos.x = Mathf.Clamp(pos.x, minX + spriteHalfWidth, maxX - spriteHalfWidth);
        pos.y = Mathf.Clamp(pos.y, minY + spriteHalfHeight, maxY - spriteHalfHeight);

        // Update the position
        transform.position = pos;
    }
}
