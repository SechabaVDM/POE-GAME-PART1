using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.CloudSave;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Collections.Generic;

public class Username : MonoBehaviour
{
    public TMP_InputField usernameInputField;

    public async void SaveUsername()
    {
        string username = usernameInputField.text.Trim();

        if (!string.IsNullOrEmpty(username))
        {
            // 1?? Save locally
            PlayerPrefs.SetString("Username", username); // Removed ":" in key to avoid typos later
            PlayerPrefs.Save();
            Debug.Log("Username saved locally: " + username);

            // 2?? Save to cloud
            await SaveUsernameToCloud(username);
        }
        else
        {
            Debug.LogWarning("Username is empty!");
        }
    }
    public void SaveUsernameAndPlay()
    {
        SaveUsername();
        SceneManager.LoadScene(1);
    }
    private async System.Threading.Tasks.Task SaveUsernameToCloud(string username)
    {
        try
        {
            // Ensure Unity Services is ready
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
                await AuthenticationService.Instance.SignInAnonymouslyAsync();

            var data = new Dictionary<string, object>
            {
                { "username", username }
            };

            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log("Username saved to cloud: " + username);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Could not save username to cloud: " + e.Message);
        }
    }
}
