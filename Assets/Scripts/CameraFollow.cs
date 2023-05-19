using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;

    private Vector3 initialOffset;

    private void Start()
    {
        initialOffset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + initialOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
        }
    }
}
