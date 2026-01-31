using UnityEngine;
using System.Collections;

public class EnemyDanceMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float wanderTime = 2f;
    public float idleTime = 1f;

    public float bounceHeight = 0.1f;
    public float bounceSpeed = 6f;

    private Vector2 moveDirection;

    void Start()
    {
        StartCoroutine(BehaviorLoop());
    }

    IEnumerator BehaviorLoop()
    {
        while (true)
        {
            // Wander
            moveDirection = Random.insideUnitCircle.normalized;
            float timer = 0f;

            while (timer < wanderTime)
            {
                transform.position += (Vector3)(moveDirection * moveSpeed * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;
            }

            // Pause before dancing
            yield return new WaitForSeconds(0.3f);

            // Dance where they stopped
            yield return StartCoroutine(BounceInPlace());

            // Small pause after dance
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator BounceInPlace()
    {
        float timer = 0f;
        Vector3 basePosition = transform.position;

        while (timer < idleTime)
        {
            float offset = Mathf.Sin(timer * bounceSpeed) * bounceHeight;
            transform.position = new Vector3(
                basePosition.x,
                basePosition.y + offset,
                basePosition.z
            );

            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure exact return to base position
        transform.position = basePosition;
    }
}
