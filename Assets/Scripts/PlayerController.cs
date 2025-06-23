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


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialY = transform.position.y;
        playerSpeed = 0f;
        shield = GetComponent<PlayerShield>();
    }
    void Update()
    {
        // Move the player forward continuously
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Move left if 'A' or Left Arrow key is pressed and within left limit
            if (this.gameObject.transform.position.x > leftlimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizonatlSpeed);
            }
        }
        // Move right if 'D' or Right Arrow key is pressed and within right limit
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizonatlSpeed * -1);
            }
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
   


}
