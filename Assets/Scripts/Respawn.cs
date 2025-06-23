using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard")) // Check if colliding with a hazard
        {
            //DeathScore.deathScore += 1;
            StrengthControl.strengthCount -= 5;
           // RespawnPlayer();
            ResetGame();
        }
    }
    /*
    private void RespawnPlayer()
    {
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position; // Move player to the respawn point
            Debug.Log("Player Respawned at: " + respawnPoint.position);
        }
        else
        {
            Debug.LogError("Respawn point is not assigned!");
        }
    }
    */
    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
