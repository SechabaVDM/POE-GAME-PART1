using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] Vector3 movement;
    [SerializeField] Vector3 rotation;

    [SerializeField] bool fullCycle = true;

    [SerializeField] float completionTime = 3f;
    [SerializeField] float endPointStallTime = 2f;

    [SerializeField] float endPointDistanceThreshold = 0.05f;

    float dwellTimer = 0f;
    float t = 0f;

    Vector3 startingPoint;
    Vector3 targetPoint;

    private void Start()
    {
        targetPoint = (transform.position+movement);

        if (fullCycle)
        {
            transform.position = (transform.position - movement);
           
        }
        startingPoint = transform.position;
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, targetPoint)<= endPointDistanceThreshold)
        {
            dwellTimer += Time.deltaTime;
            if(dwellTimer >= endPointStallTime)
            {
                Vector3 temp = targetPoint;
                targetPoint = startingPoint;
                startingPoint = temp;

                t = 0f;
                dwellTimer = 0f;
            }
        }
        t += (Time.deltaTime / completionTime);
        
        transform.position = Vector3.Lerp(startingPoint,targetPoint, t);

        transform.Rotate(rotation * Time.deltaTime);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (fullCycle)
        {
            Gizmos.DrawLine((transform.position - movement), (transform.position + movement));
        }
        else
        {
            Gizmos.DrawLine(transform.position,transform.position + movement);
        }
    }
    
}
