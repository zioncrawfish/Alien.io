using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public UnityAction OnPlayerDeath;

    private HealthBarBehaviour healthBar;
    private EnemyFollow[] enemyFollows;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthBarBehaviour>();
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }

        enemyFollows = FindObjectsOfType<EnemyFollow>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Call the OnPlayerDeath event
        OnPlayerDeath?.Invoke();

        // Notify enemy objects that the player has died
        foreach (EnemyFollow enemyFollow in enemyFollows)
        {
            enemyFollow.SetPlayerAlive(false);
        }

        // Destroy the player object
        Destroy(gameObject);
    }
}
