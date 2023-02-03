using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float faceSpeed = 1f;
    public Camera mainCamera;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        //float direction = Input.mousePosition.x;
        transform.position += new Vector3(direction * faceSpeed * Time.deltaTime, 0, 0);
        //transform.Rotate(Vector3.right * direction * faceSpeed);
    }
}
