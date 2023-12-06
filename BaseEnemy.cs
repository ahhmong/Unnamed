using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int health = 100;

    // Virtual method for taking damage, allowing derived classes to override it
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Protected method for handling the enemy's death
    protected virtual void Die()
    {
        // Common death behavior like playing a death animation or sound
        // Destroy the enemy object
        Destroy(gameObject);
    }
}
