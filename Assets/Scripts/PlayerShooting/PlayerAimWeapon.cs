using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    public Transform aimTransform;
    public MuzzleFlash muzzleFlash;
    public Transform muzzleFlashTransform;
    public GameObject tracerPrefab;
    public float tracerSpeed = 10f;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            muzzleFlash.PlayMuzzleFlash();
            ShootTracer(aimDirection);
        }

        // Flip the gun sprite based on the player's orientation
        Vector3 scale = Vector3.one;
        if (aimDirection.x < 0)
        {
            scale.y = -1f;
        }
        aimTransform.localScale = scale;
    }

    private void ShootTracer(Vector3 aimDirection)
    {
        GameObject tracer = Instantiate(tracerPrefab, muzzleFlashTransform.position, muzzleFlashTransform.rotation);
        SpriteRenderer tracerRenderer = tracer.GetComponent<SpriteRenderer>();
        tracerRenderer.sortingLayerName = muzzleFlash.GetComponent<SpriteRenderer>().sortingLayerName;
        tracerRenderer.sortingOrder = muzzleFlash.GetComponent<SpriteRenderer>().sortingOrder - 1;
        Rigidbody2D tracerRigidbody = tracer.GetComponent<Rigidbody2D>();
        tracerRigidbody.velocity = aimDirection * tracerSpeed;
    }
}



