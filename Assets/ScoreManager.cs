using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI Text component for displaying score
    private int score; // The player's score

    void Start()
    {
        score = 0; // Initialize score
        UpdateScoreText(); // Update the UI display
    }

    // Method to increase score
    public void AddScore(int points)
    {
        score += points; // Increase score by points
        UpdateScoreText(); // Update the displayed score
    }

    // Method to update the score text UI
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Display the score
    }

    // Optionally, a method to reset the score
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
