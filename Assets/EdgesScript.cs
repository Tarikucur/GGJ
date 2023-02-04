using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgesScript : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D trigger) {
        if(trigger.gameObject.CompareTag("Snake")) {
            gm.gameOver = true;
        }
        //gm.gameOver = true;
    }
}
