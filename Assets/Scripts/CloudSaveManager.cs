using UnityEngine;
using Unity.Services.CloudSave;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms.Impl;
public class CloudSaveManager : MonoBehaviour
{
    public static CloudSaveManager Instance { get; private set; }

    public string Username { get; private set; }
    public int Score { get; private set; }
    public static Task InitializationTask { get; private set; }

    private async void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializationTask = InitializeServices();
        await InitializeServices();
    }

    private async Task InitializeServices()
    {
        try
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
                await AuthenticationService.Instance.SignInAnonymouslyAsync();

            Debug.Log("Unity Services Initialized and Signed In");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error initializing Unity Services: " + e.Message);
        }
    }

    // Save to Cloud & PlayerPrefs
    public async Task SaveData(string username, int score)
    {
        Username = username;
        Score = score;

        // Local save
        PlayerPrefs.SetString("Username", username);
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();

        // Cloud save
        try
        {
            var data = new Dictionary<string, object>
            {
                { "username", username },
                { "score", score }
            };
            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log("Data saved to cloud");
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Could not save to cloud: " + e.Message);
        }
    }

    // Load from Cloud (fallback to PlayerPrefs)
    public async Task LoadData()
    {
        try
        {
            var keys = new HashSet<string> { "username", "score" };
            var savedData = await CloudSaveService.Instance.Data.LoadAsync(keys);

            if (savedData.TryGetValue("username", out var cloudUsername))
                Username = cloudUsername;

            if (savedData.TryGetValue("score", out var cloudScore))
                Score = int.TryParse(cloudScore, out var parsedScore) ? parsedScore : 0;

            Debug.Log("Data loaded from cloud");
        }
        catch
        {
            Username = PlayerPrefs.GetString("Username", "Player");
            Score = PlayerPrefs.GetInt("FinalScore", 0);
            Debug.LogWarning("Loaded local PlayerPrefs data");
        }
    }
}
