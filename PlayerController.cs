using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 9.5f;
    [SerializeField] public float jumpForce = 11.0f;
    [SerializeField] public float fallMultiplier = 3.5f;
    [SerializeField] public float jumpTime = 1.0f;
    [SerializeField] public float drag = 2.0f;
    [SerializeField] public float airControl = 1.0f;
    [SerializeField] public int extraJumpsValue = 1; 
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;


    private PlayerMovement playerMovement;
    private PlayerJumping playerJumping;
    private PlayerDashing playerDashing;
    private float cooldownTimer;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        playerJumping = GetComponent<PlayerJumping>();
        playerMovement.Initialize(speed, drag);
        playerJumping.Initialize(jumpForce, extraJumpsValue);
        playerDashing = GetComponent<PlayerDashing>();
        playerDashing.Initialize(GetComponent<Rigidbody2D>());
    }

    private void Start()
    {
        rb.gravityScale = 2.5f;
        rb.drag = 0;
    }

private void Update()
{
    cooldownTimer -= Time.deltaTime;

    bool isGrounded = playerMovement.isGrounded;
    playerJumping.HandleJumping(isGrounded);

    // Only apply drag and handle movement if not currently dashing
    if (!playerDashing.IsDashing())
    {
        playerMovement.ApplyDrag();
        playerMovement.HandleMovement();
    }

    // Listen for dash input
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
        Vector2 dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;
        playerDashing.AttemptDash(dashDirection);
    }
}

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerMovement.SetGrounded(true);
            playerJumping.ResetExtraJumps();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            playerMovement.SetGrounded(false);
        }
    }
}