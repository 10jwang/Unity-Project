using UnityEngine;
using UnityEngine.UI;

public class RedSafeHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 1000;
    public Slider slider;
    public Sprite[] redsafesprites;
    public SpriteRenderer redSafe;
    public GameObject winCanvas;

    private bool gameWon = false;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        winCanvas.SetActive(false);
    }

    void Update()
    {
        if (!gameWon)
        {
            slider.value = health;

            if (health <= 0)
            {
                // Death
                Destroy(gameObject);
                DisplayWinMessage();
                gameWon = true;
            }
            else
            {
                float healthPercentage = (float)health / maxHealth;
                int spriteIndex = Mathf.Clamp(Mathf.FloorToInt(healthPercentage * redsafesprites.Length - 1), 0, redsafesprites.Length - 1);
                redSafe.sprite = redsafesprites[spriteIndex];
            }
        }
    }

    void DisplayWinMessage()
    {
        // Show the "You Win" canvas
        winCanvas.SetActive(true);
        // Pause the game
        Time.timeScale = 0f;
    }
}



