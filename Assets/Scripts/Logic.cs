using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float faceSpeed = 10f;
    public Camera mainCamera;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        float direction = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.right * direction * faceSpeed);
        mainCamera.transform.position = new Vector3(0, transform.position.y, -10);
    }
}
