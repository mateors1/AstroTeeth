
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpSpeed = 2f;
    public int maxJumps = 3;  // Maximum number of jumps (including the initial jump)
    public bool canFly = false;

    private int jumpsRemaining;
    private bool isGrounded = false;
    private bool isFlying = false;
    private Rigidbody2D rb;
    private GameControllerActions gameController;

    [SerializeField]
    float ceiling = 6.8f;
    private void Awake()
    {
        CatFollowersSystem.onDisconnect += IDied;
        gameController = new GameControllerActions();
        gameController.Player.Move.performed += ctx => HandleMovement(ctx.ReadValue<Vector2>());
        gameController.Player.Jump.performed += ctx => HandleJump();
        gameController.Player.Move.performed += ctx => HandleFlying(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        gameController.Enable();
    }

    private void OnDisable()
    {
        gameController.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    private void HandleMovement(Vector2 movement)
    {
        // Clamp the X-axis movement between -9.95 and 8
        float clampedX = Mathf.Clamp(transform.position.x + movement.x * moveSpeed * Time.deltaTime, -9.95f, 8f);
    
        // Set the new position with clamped X-axis
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }


    private void HandleJump()
    {
        if (jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * jumpSpeed);
            CatFollowerRandomAnswer.onEncouragement?.Invoke();
            jumpsRemaining--;

            // If the player can double jump, reset isGrounded to allow double jump even if not on the ground
            if (canFly)
            {
                isGrounded = false;
            }
        }
    }

    private void HandleFlying(Vector2 movement)
    {
        if (canFly)
        {
            isFlying = movement.y > 0;  // Check the vertical axis value from the Vector2 control
            rb.velocity = new Vector2(rb.velocity.x, movement.y * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isFlying = false;
            jumpsRemaining = maxJumps;  // Reset jumps when touching the ground
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        if (transform.position.y > ceiling)
        {
            transform.position = new Vector3(0, ceiling, 0);
        }
    }

    void IDied()
    {
        gameController.Disable();
    }
}
