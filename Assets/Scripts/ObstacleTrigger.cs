using Unity.VisualScripting;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    //public GameObject section2;
    public GameObject[] sections;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Trigger"))
        {
            //Instantiate(section2, new Vector3(0, 0, 20) , Quaternion.identity);
            if (sections.Length > 0)
            {
                int randomIndex = Random.Range(0, sections.Length); // Pick a random section
                Instantiate(sections[randomIndex], new Vector3(0, 0, 18), Quaternion.identity);
            }

        }
    }
}
