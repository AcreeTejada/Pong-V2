using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 40.0f; // Initial time remaining in seconds
    public bool timerIsRunning = false;
    public Text timerText; // Reference to the UI Text element

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI(); // Update the UI Text element with the timer value
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                // Load the next scene
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    void UpdateTimerUI()
    {
        // Check if the timerText reference is set
        if (timerText != null)
        {
            // Update the text of the UI Text element with the timer value
            timerText.text = "Time: " + Mathf.RoundToInt(timeRemaining).ToString(); // Rounds the timer value to the nearest whole number
        }
    }
}