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
        if (collision.gameObject.CompareTag("Alien") || collision.gameObject.CompareTag("Alien1") ||
            collision.gameObject.CompareTag("Alien2") || collision.gameObject.CompareTag("Alien3"))
        {
            int damage = GetAlienDamageAmount(collision.gameObject);
            playerHealth.TakeDamage(damage);
        }
    }

    private int GetAlienDamageAmount(GameObject alien)
    {
        int damageAmount = 0;

        // Set the damage amount based on the specific alien prefab
        if (alien.CompareTag("Alien"))
        {
            damageAmount = 10;
        }
        else if (alien.CompareTag("Alien1"))
        {
            damageAmount = 15;
        }
        else if (alien.CompareTag("Alien2"))
        {
            damageAmount = 20;
        }
        else if (alien.CompareTag("Alien3"))
        {
            damageAmount = 25;
        }

        return damageAmount;
    }
}
