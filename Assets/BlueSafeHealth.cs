using UnityEngine;
using UnityEngine.UI;

public class BlueSafeHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 1000;
    public Slider slider;
    public Sprite[] bluesafesprites;
    public SpriteRenderer blueSafe;
    public GameObject loseCanvas;

    private bool gameLost = false;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        loseCanvas.SetActive(false);
    }

    void Update()
    {
        if (!gameLost)
        {
            slider.value = health;

            if (health <= 0)
            {
                Time.timeScale = 0f; // Pause the game
                Destroy(gameObject);
                DisplayLoseMessage();
                gameLost = true;
            }
            else
            {
                float healthPercentage = (float)health / maxHealth;
                int spriteIndex = Mathf.Clamp(Mathf.FloorToInt(healthPercentage * bluesafesprites.Length - 1), 0, bluesafesprites.Length - 1);
                blueSafe.sprite = bluesafesprites[spriteIndex];
            }
        }
    }

    void DisplayLoseMessage()
    {
        loseCanvas.gameObject.SetActive(true);
    }
}



