using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        player.GetComponent<playerMovement>().waxNum++;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
