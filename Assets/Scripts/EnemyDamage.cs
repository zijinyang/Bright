using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Place this script inside the enemy object
public class EnemyDamage : MonoBehaviour
{
    public const int DAMAGE = 1;
    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")  // MIGHT NEED MODIFY THE TAG NAME
        {
            playerHealth.TakeDamage(DAMAGE);
        }
    }
}
