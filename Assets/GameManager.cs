using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen; // A reference to the game over UI
    private bool isGameOver = false;

    // This method is called when the game is over
    public void GameOver()
    {
        if (isGameOver) return; // Prevent GameOver from being called multiple times

        isGameOver = true;

        // Show Game Over UI
        gameOverScreen.SetActive(true);

        // Stop the game (e.g., stop movement or pause the game)
        Time.timeScale = 0f;  // Pauses the entire game
    }

    // Call this method to restart the game
    public void RestartGame()
    {
        // Reset time scale back to normal
        Time.timeScale = 1f;

        // Reload the current scene to restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

        public void QuitGame()
    {
        // Quit the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #else
            Application.Quit(); // Quit the game in a build
        #endif
    }
}
