using UnityEngine;

public class NPCInteractRange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPunchCounter player = other.GetComponent<PlayerPunchCounter>();
        //if (player != null)
        //{
            player.AddNPCInRange();
            Debug.Log("NPC entered range");
        //}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerPunchCounter player = other.GetComponent<PlayerPunchCounter>();
        if (player != null)
        {
            player.RemoveNPCInRange();
            Debug.Log("NPC left range");
        }
    }
}
