using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField] public int playerStrength = 30; // Player's health or strength
    [SerializeField] private Checkpoint checkpoint; // Reference to the checkpoint system
    [SerializeField] private GameObject player; // Reference to the player GameObject
    [SerializeField] private Text strengthDisplay; // Regular Text


    public GameManager gameManager;

    public AudioClip hitSound;
    private AudioSource audioSource;



    public int strength { get; internal set; }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        // Get the Checkpoint component attached to the same GameObject
        checkpoint = GetComponent<Checkpoint>();

        // Find the GameManager if not set manually
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collides with a hazard
        if (collision.gameObject.CompareTag("Hazard"))
        {

            audioSource.PlayOneShot(hitSound);

            playerStrength = playerStrength - 5; // Reduce player strength on hazard collision
            Debug.Log("Player Strength: " + playerStrength);

            
            if (playerStrength <= 0)
            {
                Die(); // Call death function if strength is 0
            }
            if (strengthDisplay != null)
            {
                if (gameManager != null)
                {
                    gameManager.UpdateStrengthUI(playerStrength);
                }
            }
            /* else
            {
               Respawn(); // Respawn if still alive
            }
            */
        }
    }


    /*
    private void Respawn()
    {
        // Move player to the last checkpoint position
        player.transform.position = checkpoint.GetLastCheckpointPosition();
        Debug.Log("Respawning at last checkpoint");
    }
    */
    private void Die()
    {
        gameManager.GameOver();
        Debug.Log("Player has died!");
      
    }
}
