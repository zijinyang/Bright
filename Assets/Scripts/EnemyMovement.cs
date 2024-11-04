using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform playerTransform;
    public float moveSpeed = 2f;
    public float chaseDistance = 5f;
    private int patrolDestination = 0;
    private bool isChasing = false;
    private bool isFacingRight = true;

    void Update()
    {
        // Check if the player is close enough to start chasing
        if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {
        // Move towards the player
        Vector3 direction = (playerTransform.position.x < transform.position.x) ? Vector3.left : Vector3.right;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Flip direction if needed
        FlipDirectionIfNeeded(direction.x);
    }

    void Patrol()
    {
        // Move towards the current patrol point
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);

        // Check if the object has reached the patrol point
        if (Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < 0.1f)
        {
            // Update the next patrol point
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
            // Flip direction if needed based on the next patrol point
            FlipDirectionIfNeeded(patrolPoints[patrolDestination].position.x - transform.position.x);
        }
    }

    void FlipDirectionIfNeeded(float directionX)
    {
        // Flip only if the direction changes
        bool shouldFaceRight = directionX > 0;
        if (shouldFaceRight != isFacingRight)
        {
            isFacingRight = shouldFaceRight;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;  // Flip the x scale to change direction
            transform.localScale = newScale;
        }
    }
}
