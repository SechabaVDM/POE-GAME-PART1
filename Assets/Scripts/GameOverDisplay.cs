using TMPro;
using UnityEngine;
using Unity.Services.CloudSave;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GameOverDisplay : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text scoreText;

    private async void Start()
    {
        bool cloudDataLoaded = await LoadFromCloud();
        
        if (!cloudDataLoaded)
        {
            // Fallback if cloud not loaded
            string username = PlayerPrefs.GetString("Username", "Player");
            int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

            usernameText.text = username;
            scoreText.text = "Score: " + finalScore;
        }
        
    }

    private async Task<bool> LoadFromCloud()
    {
        try
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
                await AuthenticationService.Instance.SignInAnonymouslyAsync();

            var keys = new HashSet<string> { "username", "score" };
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(keys);

            bool gotAnyData = false;

            // Always set username — use PlayerPrefs if cloud missing
            if (savedData.TryGetValue("username", out var cloudUsername) && !string.IsNullOrWhiteSpace(cloudUsername))
            {
                usernameText.text = cloudUsername;
                gotAnyData = true;
            }
            else
            {
                usernameText.text = PlayerPrefs.GetString("Username", "Player");
            }

            // Always set score — use PlayerPrefs if cloud missing
            if (savedData.TryGetValue("score", out var cloudScore) && !string.IsNullOrWhiteSpace(cloudScore))
            {
                scoreText.text = "Score: " + cloudScore;
                gotAnyData = true;
            }
            else
            {
                scoreText.text = "Score: " + PlayerPrefs.GetInt("FinalScore", 0);
            }

            return gotAnyData;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Could not load from cloud: " + e.Message);
            return false;
        }
    }
}
