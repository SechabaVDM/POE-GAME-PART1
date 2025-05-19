using UnityEngine;

public class StrengthPickUp : MonoBehaviour
{
    public int strengthIncrease = 5;
    public GameObject particleEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             Damage playerController = other.GetComponent<Damage>();
            if (playerController != null) 
            {
                playerController.playerStrength += strengthIncrease;

                Destroy(gameObject);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
