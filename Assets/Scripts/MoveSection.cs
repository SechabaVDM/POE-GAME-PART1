using UnityEngine;

public class MoveSection : MonoBehaviour
{
    public bool canMove = true; // New toggle to control movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position += new Vector3(0, 0, -12) * Time.deltaTime;
        }
    }
}
