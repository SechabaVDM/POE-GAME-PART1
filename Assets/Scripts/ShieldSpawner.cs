using UnityEngine;
using System.Collections;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float spawnInterval = 25f;

    public Vector2 xRange = new Vector2(-0f, 0f); // Left-right range
    public Vector2 zOffset = new Vector2(40f, 70f); // How far in front of the player to spawn

    public Transform player; // Assign the player in the Inspector

    public bool canMove = true; // New toggle to control movement
    private void Start()
    {
        StartCoroutine(SpawnShieldRoutine());
    }

    IEnumerator SpawnShieldRoutine()
    {
        while (true)
        {
            SpawnShield();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnShield()
    {
        if (shieldPrefab == null || player == null) return;

        float randomX = Random.Range(xRange.x, xRange.y);
        float randomZ = Random.Range(zOffset.x, zOffset.y) + player.position.z;

        Vector3 spawnPos = new Vector3(randomX, 4f, randomZ);
        Instantiate(shieldPrefab, spawnPos, Quaternion.identity);
    }
    private void Update()
    {
        if (canMove)
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
        }
    }
}
