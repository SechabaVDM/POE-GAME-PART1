using UnityEngine;

public class ReverseScript : MonoBehaviour
{
    public bool invertOnEnter = true;
    public bool revertOnExit = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Detected! Inverting controls.");
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.SetControlsInverted(invertOnEnter);
            }
            else
            {
                Debug.LogWarning("PlayerController not found on object or parent.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (revertOnExit && other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetControlsInverted(false);
            }
        }
    }
}
