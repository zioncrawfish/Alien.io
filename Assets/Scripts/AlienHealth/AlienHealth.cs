using UnityEngine;

public class AlienHealth : MonoBehaviour
{
    public int maxHits = 3;
    public int currentHits = 0;

    public void TakeDamage(int damageAmount)
    {
        currentHits += damageAmount;

        if (currentHits >= maxHits)
        {
            Kill();
        }
    }

    private void Kill()
    {
        // Perform necessary actions to destroy the alien
        Destroy(gameObject);
    }

    public int GetCurrentHits()
    {
        return currentHits;
    }

    public int GetMaxHits()
    {
        return maxHits;
    }
}

