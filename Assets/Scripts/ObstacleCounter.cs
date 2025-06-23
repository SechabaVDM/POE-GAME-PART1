using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCounter : MonoBehaviour
{
    
    public TextMeshProUGUI counterText;
    public GameObject bossPrefab;
    public Transform bossSpawnPoint; // Create empty GameObject at (-9, 2, 0) and assign here
    public RandomSpawner[] spawners; // Assign all spawners in the scene
    private int hazardsPassed = 0;
    private bool bossSpawned = false;
    public BossFightManager bossFightManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            if (++hazardsPassed <= 100)
                counterText.text = "SCORE : " + hazardsPassed;
        }

        if (hazardsPassed >= 100 && !bossSpawned)
        {
            counterText.text = "SCORE : BOSS FIGHT!";

            foreach (var spawner in spawners)
            {
                spawner.StopSpawning();              // Stop the coroutine and movement
                Destroy(spawner.gameObject);         //  Destroy the spawner object completely
            }

            Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);

            bossFightManager.StartBossFight(); // Optional logic

            bossSpawned = true;

            //  Start 40-second timer
            StartCoroutine(LoadSceneAfterDelay(40f));
        }
    }
    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Loading Scene 4 after 40 seconds...");
        SceneManager.LoadScene(4); // Replace with your actual scene index or name
    }
}
