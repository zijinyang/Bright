using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waxShard: MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindWithTag("Player");     
    }

    private void OnTriggerEnter2D(Collider2D other) {
        player.GetComponent<PlayerScript>().waxNum++;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
