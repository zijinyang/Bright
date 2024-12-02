using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<GameObject> overTrigger;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            overTrigger.Add(other.gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Enemy"){
            overTrigger.Remove(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
