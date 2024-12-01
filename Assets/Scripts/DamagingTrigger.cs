using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingTrigger : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
   player = GameObject.FindWithTag("Player");     
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(GameObject.ReferenceEquals(other.gameObject, player)){
            player.GetComponent<PlayerScript>().TakeDamage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
