using UnityEngine;

public class VoidGrunts : BaseEnemy
{
    // Additional properties specific to Void Grunts
    // Example: Speed, attack power, etc.
    public float speed = 3.0f;
    public int attackPower = 15;

    // Override the TakeDamage method to add specific behaviors for Void Grunts
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage); // Apply damage using the base class's logic

        // Add specific reactions to taking damage
        // Example: Play a specific sound or animation
        Debug.Log("Void Grunt took damage");
    }

    // Override the Die method for specific death behavior
    protected override void Die()
    {
        // Specific death behavior for Void Grunts
        // Example: Play a death animation, spawn items, etc.
        Debug.Log("Void Grunt died");

        base.Die(); // Ensure to call the base Die method for common behavior
    }

    // Example method for a special ability of the Void Grunts
    public void PerformSpecialAbility()
    {
        // Implement the special ability logic here
        // Example: A special attack or movement pattern
        Debug.Log("Void Grunt performs its special ability");
    }

    // Update is called once per frame (If needed for behavior logic)
    void Update()
    {
        // Implement any regular updates here
        // Example: Enemy movement or AI behavior
    }
}
