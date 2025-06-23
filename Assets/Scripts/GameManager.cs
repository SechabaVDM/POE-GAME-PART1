using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    // Assign in Inspector
    public GameObject pauseMenuScreen;
    public Text strengthText;         // UI Text for strength (optional TMP_Text if using TMP)

    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        if (pauseMenuScreen != null)
        {
            pauseMenuScreen.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        if (pauseMenuScreen != null)
        {
            pauseMenuScreen.SetActive(false);
        }
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
