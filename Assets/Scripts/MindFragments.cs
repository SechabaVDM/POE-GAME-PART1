using UnityEngine;

public class MindFragments : MonoBehaviour
{
    public static int mindCount = 0;

    [SerializeField] GameObject mindDisplay;
    [SerializeField] GameObject objectToSpawn; // The object you want to spawn
    [SerializeField] Transform spawnLocation;  // Where to spawn the object

    [Header("Audio Settings")]
    [SerializeField] private AudioClip pickupSound;
    private AudioSource audioSource;

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
        // Add AudioSource if not present
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
    private void Update()
    {
        // Update UI
        if (mindDisplay != null)
        {
            mindDisplay.GetComponent<TMPro.TMP_Text>().text = "Mind Fragment: " + mindCount;
        }

        // Spawn special object if 10 fragments are collected
        if (mindCount >= 10 && !hasSpawned)
        {
            if (playerController != null)
            {
                Debug.Log("playerController found, setting move speed.");
                playerController.SetMoveSpeed(12f);
            }
            else
            {
                Debug.LogError("playerController is NULL right before calling SetMoveSpeed!");
            }

            SpawnSpecialObject();
            hasSpawned = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mind"))
        {
            // Play sound
            if (pickupSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            mindCount++;
            Destroy(other.gameObject);
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
