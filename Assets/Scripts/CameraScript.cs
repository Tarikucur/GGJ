using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float camSpeed = 5;
    public GameManager gm;
    public SnakeController sc;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver) return;
        camSpeed += gm.deltaSpeed * Time.deltaTime;
        //move the camera
        transform.position += Vector3.down * camSpeed * Time.deltaTime;
        //transform.position += new Vector3(0, sc.finalMoveSpeed,;
    }
}
