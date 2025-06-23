using UnityEngine;

public class ReverseScript : MonoBehaviour
{

    public bool swapOnEnter = true;
    public bool swapOnExit = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {

            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.SetControlsInverted(swapOnEnter);
            }
            else
            { 
                Debug.LogWarning("PlayerController component not found on the player object.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (swapOnExit && player != null)
            {
                player.SetControlsInverted(false);
            }
            else
            {
                Debug.LogWarning("PlayerController component not found on the player object.");
            }
        }
    }
}
