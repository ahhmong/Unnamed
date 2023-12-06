using UnityEngine;
using System.Collections;

public class PlayerDashing : MonoBehaviour
{
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private TrailRenderer trailRenderer; // Assign in the editor

    private Rigidbody2D rb;
    private bool isDashing;
    private float dashCooldownTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Rigidbody2D rigidbody2D)
    {
        rb = rigidbody2D;
    }

    public bool IsDashing()
    {
        return isDashing;
    }

    public void AttemptDash(Vector2 direction)
    {
        if (dashCooldownTimer <= 0 && !isDashing)
        {
            StartCoroutine(PerformDash(direction));
        }
    }

    private IEnumerator PerformDash(Vector2 direction)
    {
        isDashing = true;
        dashCooldownTimer = dashCooldown;

        // Enable the trail renderer when dashing
        if (trailRenderer != null) 
        {
            trailRenderer.emitting = true;
        }

        // Store original values to be restored after dashing
        float originalGravity = rb.gravityScale;
        Vector2 originalVelocity = rb.velocity;

        // Temporarily modify Rigidbody for dash
        rb.gravityScale = 0;
        rb.velocity = new Vector2(direction.x * dashDistance, 0);

        yield return new WaitForSeconds(0.2f); // Dash duration

        // Restore original Rigidbody values
        rb.gravityScale = originalGravity;
        rb.velocity = originalVelocity;

        if (trailRenderer != null)
        {
            trailRenderer.emitting = false;
        }

        isDashing = false;
    }

    private void Update()
    {
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }
}
