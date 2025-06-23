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
    
    private float timer = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShieldPickup"))
        {
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
    
  

  

