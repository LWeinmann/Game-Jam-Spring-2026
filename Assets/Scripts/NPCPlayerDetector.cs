using UnityEngine;

public class NPCPlayerDetector : MonoBehaviour
{
    public bool playerNearby;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            // Debug.Log("Player entered range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            // Debug.Log("Player left range");
        }
    }
}
