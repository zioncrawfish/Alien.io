using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public string playerTag = "Player";
    public float speed = 2f; // Adjust the speed value to control the movement speed of enemies

    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;

            // Move towards the player
            rb.velocity = direction.normalized * speed;

            // Face the player
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}