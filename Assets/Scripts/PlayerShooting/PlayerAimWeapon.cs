using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    public Transform bulletSpawnPosition;
    public MuzzleFlash muzzleFlash;
    public Transform muzzleFlashTransform;
    public GameObject tracerPrefab;
    public float tracerSpeed = 10f;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Flip the gun object on the y-axis when looking up or down
        bool flipY = angle > 90f || angle < -90f;
        Vector3 scale = transform.localScale;
        scale.y = flipY ? -1f : 1f;
        transform.localScale = scale;

        if (Input.GetMouseButtonDown(0))
        {
            muzzleFlash.PlayMuzzleFlash();
            ShootTracer(aimDirection);
        }
    }

    private void ShootTracer(Vector3 aimDirection)
    {
        GameObject tracer = Instantiate(tracerPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        SpriteRenderer tracerRenderer = tracer.GetComponent<SpriteRenderer>();
        tracerRenderer.sortingLayerName = muzzleFlash.GetComponent<SpriteRenderer>().sortingLayerName;
        tracerRenderer.sortingOrder = muzzleFlash.GetComponent<SpriteRenderer>().sortingOrder - 1;
        Rigidbody2D tracerRigidbody = tracer.GetComponent<Rigidbody2D>();
        tracerRigidbody.velocity = aimDirection * tracerSpeed;
    }
}
