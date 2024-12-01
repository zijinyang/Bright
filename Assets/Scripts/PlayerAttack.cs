using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{  
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Deteced smth");
        if(other.tag == "Enemy"){
            Debug.Log("Deteched Enemy");
            Destroy(other.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
