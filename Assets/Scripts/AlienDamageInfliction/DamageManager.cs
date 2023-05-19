using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public float alienDamagePercentage = 0.1f; // Percentage of health to deduct for regular aliens
    public float alien1DamagePercentage = 0.2f; // Percentage of health to deduct for alien1
    public float alien2DamagePercentage = 0.25f; // Percentage of health to deduct for alien2
    public float alien3DamagePercentage = 0.25f; // Percentage of health to deduct for alien3

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); // Find the PlayerHealth component in the scene
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.maxHealth * alienDamagePercentage)); // Deduct health based on alienDamagePercentage
        }
        else if (collision.gameObject.CompareTag("Alien1"))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.maxHealth * alien1DamagePercentage)); // Deduct health based on alien1DamagePercentage
        }
        else if (collision.gameObject.CompareTag("Alien2"))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.maxHealth * alien2DamagePercentage)); // Deduct health based on alien2DamagePercentage
        }
        else if (collision.gameObject.CompareTag("Alien3"))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.maxHealth * alien3DamagePercentage)); // Deduct health based on alien3DamagePercentage
        }
    }
}
