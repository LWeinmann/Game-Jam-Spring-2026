using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public Transform player;
    public Transform playerSpawnpoint;

    private PlayerHealth playerHealth;
    private Rigidbody2D playerRb;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Called by the UI Button
    public void OnClick()
    {
        Debug.Log("button clicked");
        // Reset player physics
        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector2.zero;
            playerRb.angularVelocity = 0f;
            playerRb.position = playerSpawnpoint.position;
        }
        else
        {
            player.position = playerSpawnpoint.position;
        }

        // Revive player (heals + unpauses + hides death screen)
        if (playerHealth != null)
        {
            playerHealth.Revive();
        }
    }
}
