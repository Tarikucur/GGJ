using System.Runtime.CompilerServices;
//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormScript : MonoBehaviour
{

    float wormSpeed;
    // Start is called before the first frame update
    void Start()
    {      
        transform.Rotate(0, 0, 90);
        if(this.transform.position.x > 0) {
            this.wormSpeed = -2;      
            transform.Rotate(0, 0, 180);
        }
        else
            this.wormSpeed = 2;
    }
    public WormScript(){
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.right * wormSpeed * Time.deltaTime / 3);
    }
}
