using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightManager : MonoBehaviour
{
    public float survivalTime = 40f;
    private float timer = 0f;
    private bool isBossFightActive = false;

    public void StartBossFight()
    {
        isBossFightActive = true;
        timer = 0f;
    }

    private void Update()
    {
        if (!isBossFightActive) return;

        timer += Time.deltaTime;

        if (timer >= survivalTime)
        {
            Debug.Log("Boss survived! You win!");
            SceneManager.LoadSceneAsync(4); // Replace 4 with your Win screen scene index
        }
    }
}
