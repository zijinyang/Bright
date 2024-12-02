using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaxCounterScript : MonoBehaviour
{
    GameObject player; 
    int prevWaxNum;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
       if(player.GetComponent<PlayerScript>().waxNum != prevWaxNum){
            GetComponent<TMP_Text>().text = player.GetComponent<PlayerScript>().waxNum.ToString();
       } 
       prevWaxNum = player.GetComponent<PlayerScript>().waxNum;
    }
}
