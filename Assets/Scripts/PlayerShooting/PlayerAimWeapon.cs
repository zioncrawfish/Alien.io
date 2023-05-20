// PlayerAimWeapon.cs
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
        // Get the mouse position in the world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the aim direction
        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        // Calculate the angle from the aim direction
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        // Set the aim transform rotation
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        // Check for input to trigger muzzle flash and shoot tracer
        if (Input.GetMouseButtonDown(0))
        {
            // Trigger the muzzle flash
            muzzleFlash.PlayMuzzleFlash();

            // Shoot tracer
            ShootTracer(aimDirection);
        }
    }

    private void ShootTracer(Vector3 aimDirection)
    {
        // Instantiate the tracer prefab at the position of the muzzle flash
        GameObject tracer = Instantiate(tracerPrefab, muzzleFlashTransform.position, muzzleFlashTransform.rotation);

        // Get the SpriteRenderer component of the tracer prefab
        SpriteRenderer tracerRenderer = tracer.GetComponent<SpriteRenderer>();

        // Set the sorting layer and order in layer to make the tracer appear under the muzzle flash
        tracerRenderer.sortingLayerName = muzzleFlash.GetComponent<SpriteRenderer>().sortingLayerName;
        tracerRenderer.sortingOrder = muzzleFlash.GetComponent<SpriteRenderer>().sortingOrder - 1;

        // Get the Rigidbody2D component of the tracer prefab
        Rigidbody2D tracerRigidbody = tracer.GetComponent<Rigidbody2D>();

        // Apply velocity to the tracer prefab based on aim direction and speed
        tracerRigidbody.velocity = aimDirection * tracerSpeed;
    }
}






