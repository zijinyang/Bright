using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

<<<<<<< Updated upstream:Assets/Scripts/collectible.cs
=======
    private void OnTriggerEnter2D(Collider2D other) {
        player.GetComponent<PlayerScript>().waxNum++;
        Destroy(gameObject);
    }
>>>>>>> Stashed changes:Assets/Scripts/waxShard.cs
    // Update is called once per frame
    void Update()
    {
        
    }
}
