using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerShield shield; // reference to the shield script
    public float playerSpeed = 5;// Speed of forward movement

  
    public float horizonatlSpeed = 3;// Speed of horizontal movement (left/right)
    public float rightLimit = 5.5f;
    public float leftlimit = -5.5f;

    public float jumpForce = 7f; // Initial force applied for jumping
    public float jumpspeed = 1.5f;
    public bool isGrounded;       
    public float maxJumpHeight = 5f;// Maximum jump height allowed

    private Rigidbody rb;// Reference to the Rigidbody component
    private float initialY;// Stores the initial Y position to track jump height

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
        // Direction handling
        float direction = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction = 1f;

        if (controlsInverted)
            direction *= -1f;

        // Movement with limits
        float newX = transform.position.x + (direction * horizonatlSpeed * Time.deltaTime);

        if (newX >= leftlimit && newX <= rightLimit)
        {
            transform.Translate(Vector3.right * direction * horizonatlSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            controlsInverted = !controlsInverted;
            Debug.Log("Inversion toggled: " + controlsInverted);
        }
        // Jump when the Space key is pressed and the player is grounded
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)

        {       // Prevent exceeding max height
            if (transform.position.y < initialY + maxJumpHeight)
            {
                rb.AddForce(Vector3.up * jumpForce * jumpspeed, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }
    // Detect collision with the ground to reset jumping ability
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;// Player is now on the ground
            initialY = transform.position.y;// Reset initial Y position
        }
        
    }
    public void SetMoveSpeed(float newSpeed)
    {
        playerSpeed = newSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered with: " + other.name);

        if (other.CompareTag("Hazard"))
        {
            if (shield != null && shield.isShieldActive)
            {
                // Shield is active – don't trigger game over
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
    public void SetControlsInverted(bool state)
    {
        controlsInverted = state;
    }



}
