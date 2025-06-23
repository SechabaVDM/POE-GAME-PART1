using UnityEngine;

public class SpeedSlower : MonoBehaviour
{

    public float speed = 10f;             // Movement speed of the projectile
    public float slowDuration = 5f;       // How long the player slows down
    public float slowedHorizontalSpeed = 3.5f; // Slowed horizontal speed
    public float slowedPlayerSpeed = 5.5f;     // Slowed forward speed

    private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,2f);
    }
    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);  // Destroy if no target found
            return;
        }

        // Move toward the player position smoothly
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optional: rotate projectile to face the player (assuming 2D top-down)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Slow down the player on hit
                playerController.SlowDown(slowDuration, slowedHorizontalSpeed, slowedPlayerSpeed);
            }

            Destroy(gameObject); // Destroy projectile on hit
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            Destroy(gameObject); // Destroy projectile if it hits environment
        }
    }
}
