using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    private GameManager gm;
    public CameraScript cam;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        Debug.Log(gm == null);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver) return;
        // move forward
        transform.position += (transform.forward * MoveSpeed * Time.deltaTime * -1);



        // steer
        float steerDirection = Input.GetAxis("Horizontal");

        Vector3 rotationVector = Vector3.up * steerDirection * SteerSpeed * Time.deltaTime;
            transform.Rotate(rotationVector);
        //block the root from going backwards
        /*
        if (transform.forward.y < 0)
        {
            transform.Rotate(-rotationVector);
        }
        */




        // store position history
        PositionHistory.Insert(0, transform.position);

        // GrowSnake(transform);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        Debug.Log(gm == null);
        gm.gameOver = true;
    }

}
