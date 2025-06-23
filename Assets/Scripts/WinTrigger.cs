using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject youWonScreen; // Reference to the UI panel

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has won the game!");
            youWonScreen.SetActive(true); // Show the win screen
            Time.timeScale = 0f; // Optional: Pause the game
        }
    }
}
