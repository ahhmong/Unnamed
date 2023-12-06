using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // Assuming you have an Animator to handle animations
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformBasicAttack()
    {
        Debug.Log("Performed Basic Attack");
        // Trigger basic attack animation
        animator.SetTrigger("BasicAttack");

        // Define attack range and damage
        float attackRange = 1.0f;
        int attackDamage = 10;

        // Detect enemies within range
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRange, Vector2.zero);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                // Apply damage to the enemy
                // Enemy should have a method to handle getting hit
                hit.collider.GetComponent<BaseEnemy>().TakeDamage(attackDamage);
            }
        }
    }
}
