using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationOffset = 270;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;

        // Calculate the direction from the current position to the target position
        Vector3 direction = targetPosition - transform.position;

        // Normalize the direction vector to ensure constant speed
        direction.Normalize();

        // Move the player towards the target position with the desired speed
        transform.position += direction * speed * Time.deltaTime;
    }
}