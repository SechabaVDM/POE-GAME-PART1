using Unity.VisualScripting;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    //public GameObject section2;
    public GameObject[] sections;
    public GameObject veinyWalls;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(veinyWalls, new Vector3(0, 6, 64),Quaternion.identity);
        }

        if (other.gameObject.CompareTag("Trigger"))
        {
            // Only spawn if mindCount is less than 10
            if (MindFragments.mindCount <= 10)
            {
                if (sections.Length > 0)
                {
                    int randomIndex = Random.Range(0, sections.Length); // Pick a random section
                    Instantiate(sections[randomIndex], new Vector3(0, 0, 100), Quaternion.identity);
                }
            }
            else
            {
                Debug.Log("Mind fragments reached 10 - stopping spawn.");
            }
        }
    }
   
}
