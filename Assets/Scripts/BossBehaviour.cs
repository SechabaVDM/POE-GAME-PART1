using UnityEngine;

public class BossBehav : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float leftLimit = -15f;
    public float rightLimit = 1f; // Boss moves between -xLimit and xLimit
    private int direction = 1;

    public GameObject projectilePrefab;
    public float shootInterval = 1.5f;
    public Transform shootPoint;

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 1f, shootInterval);
    }

    private void Update()
    {
        // Move boss left/right
        transform.Translate(Vector3.right * moveSpeed * direction * Time.deltaTime);

        // Flip direction when reaching boundaries
        if (transform.position.x >= 1f)
            direction = -1;
        else if (transform.position.x <= -15f)
            direction = 1;
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
    }
}
