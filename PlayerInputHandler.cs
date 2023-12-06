using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerAttacks playerAttacks;

    private void Awake()
    {
        playerAttacks = GetComponent<PlayerAttacks>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // Replace KeyCode.X with your preferred key
        {
            playerAttacks.PerformBasicAttack();
        }
    }
}
