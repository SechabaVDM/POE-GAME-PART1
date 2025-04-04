using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField] private int playerStrength = 30; // Player's health or strength
    [SerializeField] private Checkpoint checkpoint; // Reference to the checkpoint system
    [SerializeField] private GameObject player; // Reference to the player GameObject

    

    private void Start()
    {
        // Get the Checkpoint component attached to the same GameObject
        checkpoint = GetComponent<Checkpoint>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collides with a hazard
        if (collision.gameObject.CompareTag("Hazard"))
        {
            playerStrength = playerStrength - 5; // Reduce player strength on hazard collision
            Debug.Log("Player Strength: " + playerStrength);

            if (playerStrength <= 0)
            {
                Die(); // Call death function if strength is 0
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
        Debug.Log("Player has died!");

    }
}
