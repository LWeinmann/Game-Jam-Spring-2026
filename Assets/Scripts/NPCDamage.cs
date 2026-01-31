using UnityEngine;
using System.Collections;

public class NPCDamage : MonoBehaviour
{
    public int damageAmount = 10;

    public Sprite idleSprite;
    public Sprite[] attackSprites; // size 3
    public float spriteFlashTime = 0.15f;

    private SpriteRenderer spriteRenderer;
    private bool canDamage = true;

    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!canDamage) return;

        if (other.CompareTag("Player"))
        {
            FacePlayer(other.transform);

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }

            StartCoroutine(SpriteReaction());
            canDamage = false;
        }
    }

    Transform player;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            FacePlayer(player);
        }
    }


    IEnumerator SpriteReaction()
    {
        // Pick a random attack sprite
        Sprite attackSprite = attackSprites[Random.Range(0, attackSprites.Length)];
        spriteRenderer.sprite = attackSprite;

        yield return new WaitForSeconds(spriteFlashTime);

        // Return to idle sprite
        spriteRenderer.sprite = idleSprite;

        // Small cooldown so it doesn't spam damage
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }

    void FacePlayer(Transform player)
    {
        if (player.position.x < transform.position.x)
        {
            // Player is to the left
            spriteRenderer.flipX = true;
        }
        else
        {
            // Player is to the right
            spriteRenderer.flipX = false;
        }
    }


}
