using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public int Gap;

    // public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime * -1;



        // steer
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);


        // store position history
        PositionHistory.Insert(0, transform.position);

        // GrowSnake(transform);
        
    }

    // private void GrowSnake(Transform transform)
    // {
    // GameObject body = Instantiate(BodyPrefab, transform,true);
    // var newObj = GameObject.Instantiate(BodyPrefab, transform);
    // newObj.transform.parent = GameObject.Find("Body").transform;
    // newObj.transform.localScale *= Random.Range(0.9f, 1.1f);
    // }
}
