using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Transform playerTransform;
    private Rigidbody2D rb;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found.");
        }

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Set the enemy as kinematic
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            Vector2 directionToPlayer = playerTransform.position - transform.position;
            transform.up = directionToPlayer.normalized;

            Vector2 movement = transform.up * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }
}
