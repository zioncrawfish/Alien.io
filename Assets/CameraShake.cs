using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 originalPosition;

    private float shakeDuration = 0f;
    private float shakeMagnitude = 0f;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (shakeDuration > 0f)
        {
            cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = originalPosition;
        }
    }

    public void Shake(float duration, float magnitude)
    {
        originalPosition = cameraTransform.localPosition;
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }
}
