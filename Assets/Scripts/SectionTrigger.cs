using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject veinyWalls;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(veinyWalls);
        }
    }
}
