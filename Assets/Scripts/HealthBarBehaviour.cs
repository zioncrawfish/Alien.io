using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public Color lowColor;
    public Color highColor;
    public Vector3 offset;

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        float normalizedHealth = health / maxHealth;
        fillImage.color = Color.Lerp(lowColor, highColor, normalizedHealth);
    }

    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
