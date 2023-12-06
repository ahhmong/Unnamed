using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private float drag;
    public bool isGrounded { get; private set; }

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float speed, float drag)
    {
        this.speed = speed;
        this.drag = drag;
    }

    public void ApplyDrag()
    {
        if (isGrounded && rb.velocity.x != 0)
        {
            float newVelocityX = Mathf.Lerp(rb.velocity.x, 0, drag * Time.deltaTime);
            rb.velocity = new Vector2(newVelocityX, rb.velocity.y);
        }
    }

    public void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }

    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckForGroundCollision(collision, true);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        CheckForGroundCollision(collision, false);
    }

    private void CheckForGroundCollision(Collision2D collision, bool isGrounded)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            SetGrounded(isGrounded);
        }
    }
}
