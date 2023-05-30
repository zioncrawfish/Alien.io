using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private float destroyTime = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, destroyTime);
    }

    public void SetVelocity(Vector2 direction)
    {
        if (rb != null)
        {
            rb.velocity = direction.normalized * speed;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the laser object.");
        }
    }
}
