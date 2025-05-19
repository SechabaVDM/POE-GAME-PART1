using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen; // Assign in Inspector
    public Text strengthText;         // UI Text for strength (optional TMP_Text if using TMP)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateStrengthUI(int currentStrength)
    {
        if (strengthText != null)
        {
            strengthText.text = "Strength: " + currentStrength;
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f; // Pause the game (optional)
        gameOverScreen.SetActive(true);
        
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume normal time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Ensure this scene is added to Build Settings
    }
}
