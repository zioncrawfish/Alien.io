using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.maxHealth * 0.1f)); // Deduct 10% damage
        }
        else if (collision.gameObject.CompareTag("Alien1"))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.maxHealth * 0.1f)); // Deduct 10% damage
        }
        else if (collision.gameObject.CompareTag("Alien2"))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.maxHealth * 0.25f)); // Deduct 25% damage
        }
        else if (collision.gameObject.CompareTag("Alien3"))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.maxHealth * 0.25f)); // Deduct 25% damage
        }
    }
}







