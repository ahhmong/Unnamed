using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    private float jumpForce;
    private int extraJumpsValue;
    private int extraJumps;
    private Rigidbody2D rb;

    // Coyote time variables
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float jumpForce, int extraJumpsValue)
    {
        this.jumpForce = jumpForce;
        this.extraJumpsValue = extraJumpsValue;
        extraJumps = extraJumpsValue;
    }

    public void HandleJumping(bool isGrounded)
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime; // Reset when on the ground
            extraJumps = extraJumpsValue;   // Reset extra jumps
        }
        else
        {
            // Count down the coyote time when in the air
            if (coyoteTimeCounter > 0)
            {
                coyoteTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || coyoteTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                // Reset coyote time once the jump is used
                coyoteTimeCounter = 0;
            }
            else if (extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
        }
    }

    public void ResetExtraJumps()
    {
        extraJumps = extraJumpsValue;
    }
}
