using UnityEngine;

public class SafeController : MonoBehaviour
{
    public Sprite[] safeStates;  // Assign your six images to this array in the Inspector
    public int bulletCount = 0;  // Current bullet count

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check the bullet count and update the safe appearance
        UpdateSafeAppearance();
    }

    void UpdateSafeAppearance()
    {
        // Ensure the bullet count is within the range of available images
        int index = Mathf.Clamp(bulletCount, 0, safeStates.Length - 1);

        // Change the sprite based on the bullet count
        spriteRenderer.sprite = safeStates[index];
    }

    // Call this method when the safe receives a bullet
    public void ReceiveBullet()
    {
        bulletCount++;

        // Optional: Implement logic for when the safe is fully shattered
        if (bulletCount >= safeStates.Length)
        {
            // Safe is fully shattered, implement additional logic as needed
            Debug.Log("Safe is fully shattered!");
        }
    }
}

