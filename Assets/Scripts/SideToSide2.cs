using Unity.VisualScripting;
using UnityEngine;

public class SideToSide2 : MonoBehaviour
{

    public float speed = 4f; 
    public float distance = 8f;


    private Vector3 startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.Sin(Time.time * speed) * distance; 
        transform.position = new Vector3(startingPosition.x + movement, startingPosition.y, startingPosition.z);
    }
}
