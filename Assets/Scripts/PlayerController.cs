using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
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
    private Animator animator;

    private bool isSlowed = false;
    private float slowTimer = 0f;

    // Store original speeds so we can restore them after slow ends
    private float originalHorizontalSpeed;
    private float originalPlayerSpeed;

    private bool controlsInverted = false;
    private void Start()
    {
        if (isSlowed)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0f)
            {
                Unslow();
            }
        }
        rb = GetComponent<Rigidbody>();
        initialY = transform.position.y;
        playerSpeed = 0.17f;

        originalHorizontalSpeed = horizonatlSpeed;
        originalPlayerSpeed = playerSpeed;
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
        if ((Input.GetKeyDown(KeyCode.J)) && isGrounded)

        {       // Prevent exceeding max height
            if (transform.position.y < initialY + maxJumpHeight) 
            {
                rb.AddForce(Vector3.up * jumpForce * jumpspeed, ForceMode.Impulse);
                isGrounded = false;
                animator.SetTrigger("isJumping");
                animator.SetBool("isGrounded", false);
            }
        }

    }
    public void SetControlsInverted(bool state)
    {
        controlsInverted = state;
    }
    // Detect collision with the ground to reset jumping ability
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;// Player is now on the ground
            initialY = transform.position.y;// Reset initial Y position
            animator.SetBool("isGrounded", true);
        }
    }
    public void SetMoveSpeed(float newSpeed)
    {
        playerSpeed = newSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
     
        Debug.Log("Player triggered: " + other.gameObject.name);
        if (other.CompareTag("Hazard"))
        {
            Debug.Log("Hazard hit! Resetting...");         
            ResetGame();
        }
        else
        {
            Debug.Log("Not a hazard. Ignored.");
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SlowDown(float duration, float newHorizontalSpeed, float newPlayerSpeed)
    {
        if (!isSlowed)
        {
            isSlowed = true;
            slowTimer = duration;

            horizonatlSpeed = newHorizontalSpeed;
            playerSpeed = newPlayerSpeed;

            Debug.Log($"Player slowed: HorizontalSpeed={horizonatlSpeed}, PlayerSpeed={playerSpeed}");
        }
        else
        {
            // Reset timer if slowing down again before previous effect ends
            slowTimer = duration;
        }
    }

    // Restore player speeds back to original values.
   
    private void Unslow()
    {
        isSlowed = false;
        horizonatlSpeed = originalHorizontalSpeed;
        playerSpeed = originalPlayerSpeed;
        Debug.Log("Player speed restored");
    }
}
