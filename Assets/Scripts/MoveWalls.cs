using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-50, 0, 0) * Time.deltaTime;
    }
}
