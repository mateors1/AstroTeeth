using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpSpeed = 2f;
    public bool canFly = false;

    private bool isGrounded = false;
    private bool isFlying = false;
    private Rigidbody2D rb;
    private GameControllerActions gameController;

    private void Awake()
    {
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
    }

    private void HandleMovement(Vector2 movement)
    {
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void HandleJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * jumpSpeed);
            CatFollowerRandomAnswer.onEncouragement?.Invoke();
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
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
