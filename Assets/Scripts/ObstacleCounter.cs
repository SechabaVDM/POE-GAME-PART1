using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.CloudSave;
using System.Threading.Tasks;

public class ObstacleCounter : MonoBehaviour
{
    
    public TextMeshProUGUI counterText;
    public GameObject bossPrefab;
    public Transform bossSpawnPoint; // Create empty GameObject at (-9, 2, 0) and assign here
    public RandomSpawner[] spawners; // Assign all spawners in the scene
    private int hazardsPassed ;
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
                Destroy(spawner.gameObject);  //  Destroy the spawner object completely
            }

            Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);

            bossFightManager.StartBossFight(); 

            bossSpawned = true;

            //  Start 40-second timer
            StartCoroutine(LoadSceneAfterDelay(40f));
        }
    }
    public IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Save to cloud
        SaveScoreToCloud(hazardsPassed);

        SceneManager.LoadScene(4);
    }

    private async void SaveScoreToCloud(int score)
    {
        await CloudSaveManager.InitializationTask;
        string username = PlayerPrefs.GetString("Username", "Player");

        await CloudSaveManager.Instance.SaveData(username, score);
    
    }
}
