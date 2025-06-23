using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
                spawner.canMove = false;
                spawner.StopSpawning(); // Stop the coroutine completely
                spawner.canMove = false;
            }

            Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);

            bossFightManager.StartBossFight(); // << Add this line

            bossSpawned = true;
        }
    }
}
