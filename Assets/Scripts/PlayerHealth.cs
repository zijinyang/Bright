using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Place this script inside the player object
public class PlayerHealth : MonoBehaviour
{
    public const int MAXHEALTH = 5;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
