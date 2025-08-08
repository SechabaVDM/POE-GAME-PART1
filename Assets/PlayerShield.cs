using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
using TMPro;

public class PlayerShield : MonoBehaviour
{
    public bool isShieldActive = false;
    public float shieldDuration = 5f;
    public GameObject shieldUI;

    public TextMeshProUGUI shieldTimerText;

    public AudioClip shieldPickupSound; // Drag your sound here in Inspector
    private AudioSource audioSource;

    private float timer = 0f;
    void Start()
    {
        //get the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShieldPickup"))
        {
            // Play sound
            if (shieldPickupSound != null)
            {
                audioSource.PlayOneShot(shieldPickupSound);
            }

            Destroy(other.gameObject);
            StartCoroutine(ActivateShield());
        }

        if (other.CompareTag("Hazard"))
        {
            if (isShieldActive)
            {
                Destroy(other.gameObject);
                Debug.Log("Hazard destroyed by shield");
            }
        }
    }
    IEnumerator ActivateShield()
    {
        isShieldActive = true;
        timer = shieldDuration;

        if (shieldUI != null) shieldUI.SetActive(true);

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (shieldTimerText != null)
            {
                shieldTimerText.text = "Shield: " + Mathf.Ceil(timer).ToString();
            }

            yield return null;
        }

        isShieldActive = false;
        if (shieldUI != null) shieldUI.SetActive(false);

        if (shieldTimerText != null)
        {
            shieldTimerText.text = "";
        }
    }
}
    
  

  

