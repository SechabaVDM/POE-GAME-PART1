using UnityEngine;

public class CollectMindFragment : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
<<<<<<< Updated upstream
=======
        if (other.CompareTag("Mind"))
        {
            audioSource.PlayOneShot(hitSound);
        }
       
>>>>>>> Stashed changes
        MindFragments.mindCount += 1;
        Destroy(gameObject);
    }
}
