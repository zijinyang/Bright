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
        if(other.tag == "Player"){
            GetComponent<BoxCollider2D>().enabled=false;
            Debug.Log("ok");
            // player.GetComponent<PlayerScript>().waxNum++;
            player.GetComponent<PlayerScript>().addWax();
            Debug.Log("should only run once");
            Debug.Log(player.GetComponent<PlayerScript>().waxNum);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
