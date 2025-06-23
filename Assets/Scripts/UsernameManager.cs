using UnityEngine;
using TMPro;
public class UsernameManager : MonoBehaviour
{
    public TMP_InputField usernameInput;

    public void SaveUsername()
    {
        string username = usernameInput.text;
        if (!string.IsNullOrEmpty(username))
        {
            PlayerPrefs.SetString("Username", username);
            PlayerPrefs.Save();
            Debug.Log("Username saved: " + username);
        }
        else
        {
            Debug.LogWarning("Username is empty!");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
