using UnityEngine;

public class CollectMindFragment : MonoBehaviour
{
    public AudioClip hitSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mind"))
        {
            audioSource.PlayOneShot(hitSound);
        }
       

        MindFragments.mindCount += 1;
        Destroy(gameObject);
    }
}
