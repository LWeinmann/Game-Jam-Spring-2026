using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerPunchCounter : MonoBehaviour
{
    public int punchCount = 0;
    public TMP_Text counterText;

    public int npcsInRange = 0;

    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (npcsInRange > 0)
            {
                punchCount++;
                Debug.Log("PUNCHED NPC");
                UpdateText();
            }
            else
            {
                Debug.Log("No NPC in range");
            }
        }
    }

    public void AddNPCInRange()
    {
        npcsInRange++;
        Debug.Log("NPCs in range: " + npcsInRange);
    }

    public void RemoveNPCInRange()
    {
        npcsInRange = Mathf.Max(0, npcsInRange - 1);
        Debug.Log("NPCs in range: " + npcsInRange);
    }

    void UpdateText()
    {
        if (counterText != null)
        {
            counterText.text = "NPCs punched: " + punchCount;
        }
    }
}
