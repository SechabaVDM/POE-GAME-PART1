using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float slowAmount = 3f;         
    public float slowDuration = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                StartCoroutine(SlowHorizontalTemporarily(player));
            }
        }
    }
    private System.Collections.IEnumerator SlowHorizontalTemporarily(PlayerController player)
    {
        float originalHorizontal = player.horizonatlSpeed;
        player.horizonatlSpeed = Mathf.Max(0f, originalHorizontal - slowAmount);

        yield return new WaitForSeconds(slowDuration);

        player.horizonatlSpeed = originalHorizontal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
