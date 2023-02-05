// using System.Diagnostics;
// using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float MoveSpeed = 5;
    //public float finalMoveSpeed = 0f;
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
        //finalMoveSpeed = (MoveSpeed * Time.deltaTime * -1);
        //Mov
        MoveSpeed += 0.1f * Time.deltaTime;

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
        MoveSpeed += gm.deltaSpeed * Time.deltaTime;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        Debug.Log(gm == null);
        Debug.Log("triggred");
        if(collision.gameObject.CompareTag("Trash")) {
            gm.gameOver = true;
        }
        //gm.gameOver = true;
        //
        if (collision.gameObject.tag == "Trash1")
        {
            AudioManager.instance.PlaySound(7); //powerup
            gm.gameOver = true;
        }
        else if (collision.gameObject.tag == "Trash2")
        {
            AudioManager.instance.PlaySound(5);
            gm.gameOver = true;
        }
        else if (collision.gameObject.tag == "Trash3")
        {
            AudioManager.instance.PlaySound(6);
            gm.gameOver = true;
        }
        else if (collision.gameObject.tag == "Trash4")
        {
            AudioManager.instance.PlaySound(8);
            gm.gameOver = true;
        }
        else if (collision.gameObject.tag == "Trash5")
        {
            AudioManager.instance.PlaySound(9);
            gm.gameOver = true;
        }
        else if (collision.gameObject.tag == "Trash6")
        {
            AudioManager.instance.PlaySound(6);
            gm.gameOver = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D trigger){
        Debug.Log("triggred");
        
    }

    private void OnTriggerExit2D(Collider2D trigger){
        if (trigger.gameObject.tag == "MainCamera"){
                Debug.Log("triggred");
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision){
        Debug.Log("trigger exit");
    }
    

}
