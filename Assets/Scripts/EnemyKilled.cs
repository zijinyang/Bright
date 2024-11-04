using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Place this script inside the player's attack position object
public class EnemyKilled : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.tag == "Destroy Point")
        {
            Destroy(collision.gameObject);
        }
   }
}
