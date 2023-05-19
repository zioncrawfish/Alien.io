using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    private MuzzleFlash muzzleFlash;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        muzzleFlash = GetComponentInChildren<MuzzleFlash>();
    }

    private void Update()
    {
        // Get the mouse position in the world coordinates
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        // Calculate the aim direction
        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        // Calculate the angle from the aim direction
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        // Set the aim transform rotation
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        // Print the angle for debugging purposes
        Debug.Log(angle);

        // Check for input to trigger muzzle flash
        if (Input.GetMouseButtonDown(0))
        {
            // Trigger the muzzle flash
            muzzleFlash.PlayMuzzleFlash();
        }
    }
}






