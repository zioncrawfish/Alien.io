using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10; // Default damage amount for the alien prefab
    public float prolongedContactDelay = 1f;
    public int prolongedContactDamageAmount = 5;

    private bool isDamaging = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageAmount);
            isDamaging = true;
            StartCoroutine(StartProlongedContactDamage(playerHealth));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDamaging = false;
        }
    }

    private IEnumerator StartProlongedContactDamage(PlayerHealth playerHealth)
    {
        yield return new WaitForSeconds(prolongedContactDelay);

        while (isDamaging)
        {
            playerHealth.TakeDamage(prolongedContactDamageAmount);
            yield return new WaitForSeconds(prolongedContactDelay);
        }
    }
}


