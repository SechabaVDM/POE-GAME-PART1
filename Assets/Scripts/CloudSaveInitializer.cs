using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;


public class CloudSaveInitializer : MonoBehaviour
{
    async void Awake()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Signed in anonymously with Player ID: " + AuthenticationService.Instance.PlayerId);
        }
    }
}
