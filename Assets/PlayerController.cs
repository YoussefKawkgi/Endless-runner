using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public GameManager gameManager;
    public Rigidbody2D rb;
    private bool isGrounded = true; // Check if the player is on the ground
    private Animator animator; // Reference to the Animator
    public ScoreManager scoreManager; // Reference to the ScoreManager

        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager in the scene
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager in the scene
    }
    
   void Update()
    {
        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        
        // Update animation parameters
        animator.SetBool("isJumping", !isGrounded);  // True when the player is in the air
        animator.SetBool("isWalking", isGrounded);   // True when the player is on the ground (i.e., walking)
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force
        isGrounded = false; // Set grounded state to false after jumping
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Obstacle"))
    {
        gameManager.GameOver();
    }

    else if (collision.gameObject.CompareTag("Ground"))
    {
        // Reset grounded state when hitting the ground
        isGrounded = true; // Reset grounded state
    }
}

    private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;  // Reset when the player leaves the ground (jumping)
    }
}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // If the player jumps over an obstacle (trigger), add score
            scoreManager.AddScore(10); // Increase score by 10
        }
        else if (other.CompareTag("Ground"))
        {
            // Reset grounded state when hitting the ground
            isGrounded = true;
        }
    }
}
