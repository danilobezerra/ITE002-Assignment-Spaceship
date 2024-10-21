using UnityEngine;

public class MovementController : MonoBehaviour
{
    public void ApplyMovement(float speed)
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, vertical));
    }
}
