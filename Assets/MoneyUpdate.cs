using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    public TMP_Text moneyText;  // Drag and drop the TMP Text component here in the Inspector
    private int money = 0;       // Player's money

    void Start()
    {
        // Check if the TMP Text component is properly assigned
        if (moneyText == null)
        {
            Debug.LogError("Please assign the TMP Text component in the Inspector.");
        }

        // Start increasing money over time
        InvokeRepeating("IncreaseMoney", 1f, 1f);  // Start after 1 second, repeat every 1 second
    }

    void UpdateMoneyDisplay()
    {
        // Update the displayed money value
        if (moneyText != null)
        {
            moneyText.text = "Your Money: $" + money.ToString();
        }
        else
        {
            Debug.LogError("TMP Text component not assigned.");
        }
    }

    void IncreaseMoney()
    {
        // Increase money by 5 every second
        money += 5;

        // Update the display
        UpdateMoneyDisplay();
    }
}

