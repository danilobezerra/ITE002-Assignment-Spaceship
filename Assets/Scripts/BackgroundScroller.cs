using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform playerTransform;
    public float parallaxFactorX = 0.1f;
    public float parallaxFactorY = 0.1f;

    private Renderer rend;
    private Vector2 savedOffset;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        rend = GetComponent<Renderer>();
        savedOffset = rend.material.mainTextureOffset;
        lastPlayerPosition = playerTransform.position;
    }

    void Update()
    {
        // Calculate the player's movement since the last frame
        Vector3 deltaMovement = playerTransform.position - lastPlayerPosition;

        // Update the texture offset based on the player's movement
        float x = deltaMovement.x * parallaxFactorX;
        float y = deltaMovement.y * parallaxFactorY;

        Vector2 offset = rend.material.mainTextureOffset;
        offset.x += x;
        offset.y += y;

        rend.material.mainTextureOffset = offset;

        // Update the last player position
        lastPlayerPosition = playerTransform.position;
    }

    void OnDisable()
    {
        // Reset the texture offset when the script is disabled
        rend.material.mainTextureOffset = savedOffset;
    }
}
