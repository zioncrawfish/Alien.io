using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health value
    private int currentHealth; // Current health value

    public HealthBarBehaviour healthBar; // Reference to the health bar behavior script

    private void Start()
    {
        currentHealth = maxHealth; // Set the current health to maximum health on start

        // Update the health bar appearance
        UpdateHealthBar();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Subtract the damage amount from the current health

        // Update the health bar appearance
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            // Player is dead, trigger game over or respawn logic here
            Die();
        }
    }

    private void Die()
    {
        // Perform any necessary actions when the player dies, such as showing game over screen or respawning
        // You can also destroy the player object if needed
        Destroy(gameObject);
    }

    private void UpdateHealthBar()
    {
        // Ensure the health bar reference is assigned
        if (healthBar != null)
        {
            // Calculate the health percentage
            float healthPercentage = (float)currentHealth / maxHealth;

            // Update the health bar with the current health and max health values
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }
}

