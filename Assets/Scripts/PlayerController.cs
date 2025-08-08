using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerShield shield;
    
    public float playerSpeed = 5;

    public float horizonatlSpeed = 3;
    public float rightLimit = 5.5f;
    public float leftlimit = -5.5f;

    public float jumpForce = 7f;
    public float jumpspeed = 1.5f;
    public bool isGrounded;
    public float maxJumpHeight = 5f;

    private Rigidbody rb;
    private float initialY;
    private bool controlsInverted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialY = transform.position.y;
        playerSpeed = 0f;
        shield = GetComponent<PlayerShield>();
    }

    void Update()
    {
        float direction = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction = 1f;

        if (controlsInverted)
            direction *= -1f;

        // Normal movement with limits
        float newX = transform.position.x + (direction * horizonatlSpeed * Time.deltaTime);

        if (newX >= leftlimit && newX <= rightLimit)
        {
            transform.Translate(Vector3.right * direction * horizonatlSpeed * Time.deltaTime);
        }

        // Jump
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            if (transform.position.y < initialY + maxJumpHeight)
            {
                rb.AddForce(Vector3.up * jumpForce * jumpspeed, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        // Toggle inverted controls
        if (Input.GetKeyDown(KeyCode.P))
        {
            controlsInverted = !controlsInverted;
            Debug.Log("Inversion toggled: " + controlsInverted);
        }

        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            initialY = transform.position.y;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered with: " + other.name);

        if (other.CompareTag("Hazard"))
        {
            if (shield != null && shield.isShieldActive)
            {
                Debug.Log("Shield active! Hazard ignored.");
                return;
            }

            Debug.Log("Hazard hit! Loading Scene 2...");
           
            SceneManager.LoadSceneAsync(2);
        }

        if (other.CompareTag("Mask"))
        {
            SceneManager.LoadSceneAsync(3);
        }
    }

    public void SetMoveSpeed(float newSpeed)
    {
        playerSpeed = newSpeed;
    }

    public void SetControlsInverted(bool state)
    {
        controlsInverted = state;
    }

}
