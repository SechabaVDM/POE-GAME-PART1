using UnityEngine;

public class FlyPickup : MonoBehaviour
{
    public float jumpPower;
    public AudioClip pickupSound; // Assign this in the Inspector
    private AudioSource audioSource;
    private bool hasPlayed = false; // Prevents multiple triggers
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Add or get AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasPlayed) return;

        if (collision.gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(transform.up * jumpPower);

            // Play pickup sound
            if (pickupSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            hasPlayed = true;

            // Disable visuals immediately
            GetComponent<Collider>().enabled = false;
            if (GetComponent<MeshRenderer>() != null)
                GetComponent<MeshRenderer>().enabled = false;

            // Destroy the object after sound finishes
            Destroy(gameObject, pickupSound != null ? pickupSound.length : 0f);
        }
    }
}
