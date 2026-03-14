using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Stats")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private Animator anim;
    private float horizontal;
    private bool isGrounded;

    // --- NEW: Double Jump Variables ---
    private bool canDoubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = false;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = Mathf.Abs(rb.linearVelocity.y) < 0.01f;

        // Reset double jump when we touch the ground
        if (isGrounded)
        {
            canDoubleJump = true;
        }

        // 3. Jump Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false; // Use up the double jump

                // Trigger Nihal's double jump animation if he has a trigger named "doubleJump"
                anim.SetTrigger("doubleJump");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Gets the name of the current scene and reloads it
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        UpdateAnimations();

        if (horizontal > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    } 

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }

    void UpdateAnimations()
    {
        anim.SetBool("isRunning", horizontal != 0);
        anim.SetBool("isGrounded", isGrounded);
    }
}