using UnityEngine;

public class TracerBullet : MonoBehaviour
{
    public int damageAmount = 1;

    private void HandleCollision(Collider2D collision)
    {
        // Check if the collision is with an alien
        AlienHealth alienHealth = collision.gameObject.GetComponent<AlienHealth>();
        if (alienHealth != null)
        {
            // Inflict damage on the alien
            alienHealth.TakeDamage(damageAmount);

            // Destroy the alien if it has taken its maximum hits
            if (alienHealth.GetCurrentHits() >= alienHealth.GetMaxHits())
            {
                Destroy(collision.gameObject);
            }
        }

        // Destroy the bullet
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision);
    }
}
