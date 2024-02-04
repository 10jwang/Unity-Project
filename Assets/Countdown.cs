using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountdownController : MonoBehaviour
{
    public Button startButton;
    public TMP_Text countdownText;

    void Start()
    {
        // Start the countdown automatically when the game begins
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        // Display "START" and wait for a short duration
        countdownText.text = "START";
        yield return new WaitForSeconds(1.5f); // Adjust the duration as needed

        // Hide the countdown text
        countdownText.gameObject.SetActive(false);

        // Disable the start button after displaying "START"
        startButton.gameObject.SetActive(false);


    }


    
}



