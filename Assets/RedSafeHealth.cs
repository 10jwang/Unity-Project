using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedSafeHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 500;
    // Start is called before the first frame update
    public Slider slider;
    
    void Start()
    {
        health = maxHealth;
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
    }
}
