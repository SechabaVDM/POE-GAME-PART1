using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.back * speed;
        Destroy(gameObject, 5f); // Cleanup
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
