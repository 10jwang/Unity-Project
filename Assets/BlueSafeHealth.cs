using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueSafeHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 1000;
    // Start is called before the first frame update
    public Slider slider;
    public Sprite[] bluesafesprite;
    public SpriteRenderer BlueSafe;
    
    
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        if (health <= 0)
        {
            // Death
            Destroy(gameObject);
        }
        else
        {
            float healthPercentage = (float)health/maxHealth;
            int spriteIndex = Mathf.FloorToInt(healthPercentage * bluesafesprite.Length);
            BlueSafe.sprite = bluesafesprite[spriteIndex];
        }
    }
}
