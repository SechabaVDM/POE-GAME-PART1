using UnityEngine;

public class MindFragments : MonoBehaviour
{
    public static int mindCount = 0;

    [SerializeField] GameObject mindDisplay;
    [SerializeField] GameObject objectToSpawn; // The object you want to spawn
    [SerializeField] Transform spawnLocation;  // Where to spawn the object


    [SerializeField] PlayerController playerController; // Reference to player controller
    private bool hasSpawned = false; // To ensure it spawns only once

    private void Start()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
            if (playerController == null)
            {
                Debug.LogError("PlayerController not found in scene!");
            }
        }
    }
    private void Update()
    {
        mindDisplay.GetComponent<TMPro.TMP_Text>().text = "Mind Fragment:" + mindCount;

        // Check if player has 10 fragments and object hasn't been spawned
        if (mindCount >= 10 && !hasSpawned)
        {
            if (playerController == null)
            {
                Debug.LogError("playerController is NULL right before calling SetMoveSpeed!");
            }
            else
            {
                Debug.Log("playerController found, setting move speed.");
                playerController.SetMoveSpeed(12f);
            }

            SpawnSpecialObject();
           
            
            hasSpawned = true; // Prevent it from spawning again
        }

    }
    private void SpawnSpecialObject()
    {
        if (objectToSpawn != null && spawnLocation != null)
        {
            Vector3 spawnPosition = new Vector3(55, 24, 379);
            Instantiate(objectToSpawn, spawnLocation.position, spawnLocation.rotation);
           
        }
    }
  
}
