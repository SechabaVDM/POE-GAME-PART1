using UnityEngine;

public class CollectMindFragment : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MindFragments.mindCount += 1;
        Destroy(gameObject);
    }
}
