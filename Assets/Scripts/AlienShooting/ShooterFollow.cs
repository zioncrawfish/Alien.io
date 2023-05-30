using UnityEngine;

public class ShooterFollow : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float minTimeBtwShots;
    public float maxTimeBtwShots;
    public int maxShots = 3; // Maximum number of shots to fire
    public float cooldownTime = 1f; // Cooldown time between shots

    [Header("References")]
    public GameObject laserPrefab;
    public Transform laserSpawn;
    public EnemyMuzzleFlash muzzleFlash;

    private Transform playerTransform;
    private float timeBtwShots;
    private int shotsFired; // Number of shots fired
    private float cooldownTimer; // Cooldown timer between shots

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = Random.Range(minTimeBtwShots, maxTimeBtwShots);
        shotsFired = 0; // Initialize shots fired counter
        cooldownTimer = 0f; // Initialize cooldown timer
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);
        }
        else if (distanceToPlayer > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }

        Vector2 directionToPlayer = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (cooldownTimer <= 0f && shotsFired < maxShots) // Check if cooldown time has passed and shots fired is less than the maximum allowed
        {
            RaycastHit2D hit = Physics2D.Raycast(laserSpawn.position, transform.right, Mathf.Infinity, LayerMask.GetMask("Default"));
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                GameObject laser = Instantiate(laserPrefab, laserSpawn.position, Quaternion.identity);
                Laser laserScript = laser.GetComponent<Laser>();
                if (laserScript != null)
                {
                    laserScript.SetVelocity(transform.right);
                }
                else
                {
                    Debug.LogWarning("Laser script not found on the laser prefab.");
                }

                muzzleFlash.PlayMuzzleFlash();

                shotsFired++; // Increment shots fired counter
                cooldownTimer = cooldownTime; // Start cooldown timer
            }
        }
        else if (shotsFired >= maxShots) // Reset shots fired counter if maximum shots reached
        {
            shotsFired = 0;
            cooldownTimer = cooldownTime; // Start cooldown timer
        }
        else
        {
            cooldownTimer -= Time.deltaTime; // Decrease cooldown timer
        }
    }
}
