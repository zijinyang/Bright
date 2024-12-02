using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 5f;

    private Rigidbody2D rb;

    public int damage = 0;
    
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        StartCoroutine(StartMovingAfterDelay(1.5f));
        player = GameObject.FindWithTag("Player");
    }

    // Coroutine to delay movement
    private IEnumerator StartMovingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector2.left * speed; // Start moving to the left
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("collision");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Damage");   
            player.GetComponent<PlayerScript>().TakeDamage();
            Destroy(gameObject);
        }
    }

}
