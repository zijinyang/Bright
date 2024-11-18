using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DynamicEnemy : MonoBehaviour
{
    AIPath agent;

    public Transform player;
    public float speed;
    public int damage = 0;
    public float autoChasingRange = 8;

    private Rigidbody2D rb;
    private float distanceToPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<AIPath>();
        if (agent != null) agent.enabled = false;

    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        // Debug.Log(distanceToPlayer);

        if (distanceToPlayer <= autoChasingRange)
        {
            Debug.Log("Within range");

            agent.enabled = true;

            /*
            // Calculate direction toward the player
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            // Rotate to face the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            // Move toward the player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            */

            agent.destination = player.position;
        }
        else
        {
            Debug.Log("Searching...");

            rb.velocity = Vector2.left * speed;
        }
        
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.takeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
    */
}
