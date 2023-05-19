using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public float duration = 0.1f;
    public GameObject flashSprite;

    private void Start()
    {
        flashSprite.SetActive(false);
    }

    public void PlayMuzzleFlash()
    {
        flashSprite.SetActive(true);
        Invoke("DeactivateMuzzleFlash", duration);
    }

    private void DeactivateMuzzleFlash()
    {
        flashSprite.SetActive(false);
    }
}
