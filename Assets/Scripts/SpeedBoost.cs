using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speedIncrease = 19f;
    public float boostDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null)
            {
                StartCoroutine(BoostSpeed(playerController));
                Destroy(gameObject);
            }
        }
    }

    private System.Collections.IEnumerator BoostSpeed(PlayerController player)
    {
        player.playerSpeed += speedIncrease;
        yield return new WaitForSeconds(boostDuration);
        player.playerSpeed -= speedIncrease;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
