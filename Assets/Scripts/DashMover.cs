using UnityEngine;

public class DashMover : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        // Move the shield backward along the Z-axis (toward player)
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
}
