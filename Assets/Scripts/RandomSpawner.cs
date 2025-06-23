using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class RandomSpawner : MonoBehaviour
{
    public GameObject obstacleObject;

    private Coroutine spawnRoutine;
    public float spawnInterval = 3f;
    public bool canMove = true; // New toggle to control movement
    public bool canSpawn = true; 

    private void Start()
    {
        spawnRoutine = StartCoroutine(SpawnObstacles()); StartCoroutine(SpawnObstacles());
    }
    void Update()
    {
        if (canMove)
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
        }
    }
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (canSpawn)
            {
                Vector3 localSpawnPosition = new Vector3(Random.Range(-19f, 0f), 3f, Random.Range(8f, 80f));
                GameObject newObstacle = Instantiate(obstacleObject, transform.position + localSpawnPosition, Quaternion.identity);
                newObstacle.transform.SetParent(transform);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    // Update is called once per frame
    public void StopSpawning()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
            spawnRoutine = null;
        }
    }
}
