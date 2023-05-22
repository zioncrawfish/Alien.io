using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationOffset = 270f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Get the mouse position in the world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the current position to the target position
        Vector2 direction = mousePosition - rb.position;

        // Normalize the direction vector to ensure constant speed
        direction.Normalize();

        // Rotate the player towards the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle + rotationOffset;

        // Apply movement using Rigidbody2D velocity
        rb.velocity = direction * speed;
    }
}
