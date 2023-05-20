using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public Color lowColor;
    public Color highColor;
    public float yOffset = 5f;
    public Transform target;

    private void LateUpdate()
    {
        // Set the health bar position above the target's position
        Vector3 targetPosition = target.position + new Vector3(0f, yOffset, 0f);
        transform.position = targetPosition;

        // Update the health bar fill color based on the current health value
        float normalizedHealth = slider.value / slider.maxValue;
        fillImage.color = Color.Lerp(lowColor, highColor, normalizedHealth);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
    }
}
