using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameController : MonoBehaviour
{
    public TMP_Text countdownText;
    public Button startButton;
    public AudioSource audioSource;

    public AudioClip countdownSound;
    public AudioClip backgroundMusic;

    private int countdownDuration = 3;

    void Start()
    {
        // Start the countdown automatically when the game begins
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        // Display the countdown on the UI
        for (int i = countdownDuration; i > 0; i--)
        {
            countdownText.text = i.ToString();

            // Play countdown audio
            if (audioSource != null && countdownSound != null)
            {
                audioSource.clip = countdownSound;
                audioSource.Play();
            }

            yield return new WaitForSeconds(1f);
        }

        // Display "Go!" and hide the countdown text
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);

        // Stop the countdown audio
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        // Play background music
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }

        // Destroy the start button GameObject after the countdown
        if (startButton != null)
        {
            Destroy(startButton.gameObject);
        }

        // ... (rest of the code)
    }
}






