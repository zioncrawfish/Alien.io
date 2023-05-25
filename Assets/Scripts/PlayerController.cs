using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationOffset = 270f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Handle movement input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        // Calculate the movement direction based on WASD input
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        // Rotate the player's gun towards the mouse position
        RotateGunTowardsMouse();

        // Apply movement using Rigidbody2D velocity
        rb.velocity = moveDirection.normalized * movementSpeed;
    }

    private void RotateGunTowardsMouse()
    {
        // Get the mouse position in the world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse position
        Vector2 direction = mousePosition - rb.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the gun
        transform.rotation = Quaternion.Euler(0f, 0f, angle + rotationOffset);
    }
}
