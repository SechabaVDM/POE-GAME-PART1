using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen; // Assign in Inspector
    public Text strengthText;         // UI Text for strength (optional TMP_Text if using TMP)
    public GameObject pauseMenuUI;
    private bool isPaused = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update is running...");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("P key pressed!");
            if (isPaused) Resume();
            else Pause();
        }
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
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Unpause before loading
        SceneManager.LoadScene("MainMenu"); // Make sure your main menu scene is named this!
    }
}
