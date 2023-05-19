using UnityEngine;

public class AlienDamage : MonoBehaviour
{
    public float alienDamagePercentage = 0.1f; // Percentage of health to deduct for this alien type

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player object
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // Check if the PlayerHealth component is found
            if (playerHealth != null)
            {
                // Calculate the damage based on the player's max health
                int damage = Mathf.RoundToInt(playerHealth.maxHealth * alienDamagePercentage);

                // Apply damage to the player
                playerHealth.TakeDamage(damage);
            }
        }
    }
}