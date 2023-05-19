using UnityEngine;

public class Alien2Damage : MonoBehaviour
{
    public float alienDamagePercentage = 0.25f; // Percentage of health to deduct for this alien type

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                int damage = Mathf.RoundToInt(playerHealth.maxHealth * alienDamagePercentage);
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
