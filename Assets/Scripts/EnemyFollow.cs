using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float separationDistance = 2f; // Distance for separation behavior
    public float closeDistance = 3f; // Distance at which enemies stop creating separation

    private GameObject playerObject;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private bool isPlayerAlive = true;
    private Collider2D[] nearbyColliders;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found.");
        }

        rb = GetComponent<Rigidbody2D>();
        nearbyColliders = new Collider2D[10]; // Adjust the size based on your requirements
    }

    private void FixedUpdate()
    {
        if (playerTransform != null)
        {
            if (!isPlayerAlive)
            {
                rb.velocity = Vector2.zero; // Stop enemy movement when player dies
                return;
            }

            Vector2 directionToPlayer = playerTransform.position - transform.position;
            transform.up = directionToPlayer.normalized;

            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer > separationDistance)
            {
                rb.velocity = transform.up * moveSpeed;
            }
            else if (distanceToPlayer > closeDistance)
            {
                Vector2 separationForce = CalculateSeparationForce();
                rb.velocity = separationForce.normalized * moveSpeed;
            }
            else
            {
                // Enemy is close to the player, stop separation behavior and move freely towards the player
                rb.velocity = directionToPlayer.normalized * moveSpeed;
            }
        }
    }

    private Vector2 CalculateSeparationForce()
    {
        Vector2 separationForce = Vector2.zero;

        int colliderCount = Physics2D.OverlapCircleNonAlloc(transform.position, separationDistance, nearbyColliders);
        for (int i = 0; i < colliderCount; i++)
        {
            Collider2D collider = nearbyColliders[i];
            if (collider != null && collider.gameObject != gameObject)
            {
                Vector2 separationDirection = transform.position - collider.transform.position;
                separationForce += separationDirection.normalized;
            }
        }

        return separationForce.normalized * moveSpeed;
    }

    public void SetPlayerAlive(bool isAlive)
    {
        isPlayerAlive = isAlive;
    }
}
