using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab in the Inspector
    public Transform spawnLocation;  // Optional: assign a specific spawn location

    private bool hasSpawned = false; // Ensure the object spawns only once

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawned && other.CompareTag("Player"))
        {
            Vector3 spawnPos = spawnLocation != null ? spawnLocation.position : transform.position;
            Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            hasSpawned = true;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
