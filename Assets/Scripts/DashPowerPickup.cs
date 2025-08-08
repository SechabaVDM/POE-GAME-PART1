using UnityEngine;

public class DashPowerPickup : MonoBehaviour
{
    public float powerDuration = 5f;
    public AudioClip pickupSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                

                // Play sound using detached object
                if (pickupSound != null)
                {
                    GameObject soundObj = new GameObject("PickupSound");
                    AudioSource tempSource = soundObj.AddComponent<AudioSource>();
                    tempSource.clip = pickupSound;
                    tempSource.Play();
                    Destroy(soundObj, pickupSound.length);
                }
            }

            // Disable visuals and collider
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;

            MeshRenderer mr = GetComponent<MeshRenderer>();
            if (mr != null) mr.enabled = false;

            // Destroy this pickup object
            Destroy(gameObject, pickupSound != null ? pickupSound.length : 0f);
        }
    }
}
    // Update is called once per frame
